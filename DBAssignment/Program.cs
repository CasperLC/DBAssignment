using System;
using System.Data;
using System.Data.SqlClient;

namespace DBAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DB Compulsory Assignment");

            // Create a Connection Object
            string ConnectionString = "Integrated Security=SSPI;" + "Initial Catalog=Company;" + "Data Source = localhost;";

            using (SqlConnection connection =
            new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("TestSP123", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentNumber", SqlDbType.Int).Value = 4;

                Console.WriteLine("\n\nStored Procedure 1");
                //Each reader[x] reads 1 column, so it needs to be equal to the columns selected
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
