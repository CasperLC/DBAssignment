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

            //createDepartmentProcedure(ConnectionString, "TestingDepartment333", 333445555);

            //updateDepartmentName(ConnectionString, 12, "UpdatedDepartment");

            //updateDepartmentManager(ConnectionString, 12, 453453453);

            //deleteDepartmentProcedure(ConnectionString, 9);

            Console.ReadLine();
        }

        private static void createDepartmentProcedure(string ConnectionString, string DName, decimal MgrSSN)
        {
           using (SqlConnection connection =
           new SqlConnection(ConnectionString))
            {
                // Creating SQL Commands
                SqlCommand cmd = new SqlCommand("usp_CreateDepartment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DName", SqlDbType.NVarChar).Value = DName;
                cmd.Parameters.Add("@MgrSSN", SqlDbType.Decimal).Value = MgrSSN;

                string queryString = "SELECT DName, MgrSSN FROM  Department";

                SqlCommand cmdAfter = new SqlCommand(queryString, connection);


                Console.WriteLine("\n\nStored Procedure: CreateDepartment(DName, MgrSSN)");
                //Each reader[x] reads 1 column, so it needs to be equal to the columns selected
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader2 = cmdAfter.ExecuteReader();
                    while (reader2.Read())
                    {
                        Console.WriteLine("{0}\t{1}",
                            reader2[0], reader2[1]);
                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void updateDepartmentName(string ConnectionString, int DNumber, string DName)
        {
           using (SqlConnection connection =
           new SqlConnection(ConnectionString))
            {
                // Creating SQL Commands
                SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DName", SqlDbType.NVarChar).Value = DName;
                cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = DNumber;

                string queryString = "SELECT DName FROM  Department";

                SqlCommand cmdAfter = new SqlCommand(queryString, connection);


                Console.WriteLine("\n\nStored Procedure: UpdateDepartmentName(DNumber, DName)");
                //Each reader[x] reads 1 column, so it needs to be equal to the columns selected
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader2 = cmdAfter.ExecuteReader();
                    while (reader2.Read())
                    {
                        Console.WriteLine("{0}",
                            reader2[0]);
                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void updateDepartmentManager(string ConnectionString, int DNumber, decimal MgrSSn)
        {
            using (SqlConnection connection =
           new SqlConnection(ConnectionString))
            {
                // Creating SQL Commands
                SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentManager", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MgrSSN", SqlDbType.Decimal).Value = MgrSSn;
                cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = DNumber;

                string queryString = "SELECT DName, MgrSSN FROM  Department";

                SqlCommand cmdAfter = new SqlCommand(queryString, connection);


                Console.WriteLine("\n\nStored Procedure: UpdateDepartmentManager(DNumber, MgrSSN)");
                //Each reader[x] reads 1 column, so it needs to be equal to the columns selected
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader2 = cmdAfter.ExecuteReader();
                    while (reader2.Read())
                    {
                        Console.WriteLine("{0}\t{1}",
                             reader2[0], reader2[1]);
                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void deleteDepartmentProcedure(string ConnectionString, int DNumber)
        {
            using (SqlConnection connection =
            new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteDepartment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = DNumber;

                Console.WriteLine("\n\nStored Procedure DeleteDepartment");
                //Each reader[x] reads 1 column, so it needs to be equal to the columns selected
                try
                {
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine("Department number " + DNumber + " was deleted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}
