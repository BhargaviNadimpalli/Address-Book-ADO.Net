using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class ContactRapo
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDb)\localdb;Integrated Security=True");
        static SqlConnection connection;
        public static Contacts RetrieveData()
        {
            try
            {
                connection = new SqlConnection();

                Contacts contactsDB = new Contacts();

                string query = "select c.FirstName, c.LastName, c.City, c.PhoneNumber, bk.B_Name, bk.B_Type from Contacts c inner join BookNameType bk on c.B_ID=bk.B_ID where c.FirstName='Ruthik'";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contactsDB.first_name = reader.GetString(0);
                        contactsDB.last_name = reader.GetString(1);
                        contactsDB.city = reader.GetString(2);
                        contactsDB.phone = reader.GetString(3);
                        contactsDB.B_Name = reader.GetString(4);
                        contactsDB.B_Type = reader.GetString(5);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();

                return contactsDB;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
