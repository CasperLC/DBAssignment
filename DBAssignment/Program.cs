using System;
using System.Data;
using System.Data.SqlClient;

namespace DBAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create a Connection Object
            string ConnectionString = "Integrated Security=SSPI;" + "Initial Catalog=Company;" + "Data Source = localhost;";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("TestSP123", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepartmentNumber", SqlDbType.Int).Value = 5;

            using (SqlConnection connection =
            new SqlConnection(ConnectionString))
            {
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
                Console.ReadLine();
            }
        }
    }
}
