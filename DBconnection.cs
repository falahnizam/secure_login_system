using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace login
{
    internal class DBconnection
    {
        private static DBconnection instances; // Singleton instance
        private string DBconnectionString; // Connection string

        // Private constructor
        private DBconnection()
        {
            DBconnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\pinterst\\login\\Login.mdf; Integrated Security = True; Connect Timeout = 30"; // Initialize the connection string
        }

        // Method to get the singleton instance of DBconnection
        public static DBconnection getInstanceOfDBconnection()
        {
            if (instances == null)
                instances = new DBconnection(); // Create a new instance if it doesn't exist
            return instances; // Return the singleton instance
        }

        // Method for executing queries that return data 
        public DataSet ExecuteQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conn = new SqlConnection(DBconnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // Log the SQL query and parameters for debugging
                        Console.WriteLine("Executing Query: " + sqlQuery);
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                Console.WriteLine($"Parameter: {param.ParameterName} = {param.Value}");
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataSet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;  // Re-throw the exception for higher-level handling
                }
            }

            return dataSet;
        }


        // Method for executing commands that do not return data (e.g., INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(DBconnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // Log the SQL query and parameters for debugging
                        Console.WriteLine("Executing NonQuery: " + sqlQuery);
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                Console.WriteLine($"Parameter: {param.ParameterName} = {param.Value}");
                            }
                        }

                        affectedRows = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;  // Re-throw the exception for higher-level handling
                }
            }

            return affectedRows;
        }

    }
}
