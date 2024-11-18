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
            DataSet dataSet = new DataSet(); // Create a new DataSet to hold results

            using (SqlConnection conn = new SqlConnection(DBconnectionString)) // Open a connection
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn)) // Create a SqlCommand
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters); // Add parameters if provided

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) // Create a SqlDataAdapter
                        {
                            adapter.Fill(dataSet); // Fill the DataSet with the query results
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle or log exception
                    throw; // Re-throwing for higher-level handling
                }
            }

            return dataSet; // Return the filled DataSet
        }

        // Method for executing commands that do not return data (e.g., INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            int affectedRows = 0; // Initialize affected rows counter

            using (SqlConnection conn = new SqlConnection(DBconnectionString)) // Open a connection
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn)) // Create a SqlCommand
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters); // Add parameters if provided

                        affectedRows = cmd.ExecuteNonQuery(); // Execute the command
                    }
                }
                catch (Exception ex)
                {
                    // Handle or log exception
                    throw; // Re-throwing for higher-level handling
                }
            }

            return affectedRows; // Return the number of affected rows
        }
    }
}
