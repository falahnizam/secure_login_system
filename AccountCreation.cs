using System;
using System.Data.SqlClient;

namespace login
{
    public class AccountService
    {
        private DBconnection db;

        public AccountService()
        {
            db = DBconnection.getInstanceOfDBconnection();
        }

        // Method to create an account (register user)
        public bool CreateAccount(string username, string password, string firstName, string lastName, DateTime dob)
        {
            // Hash the password using your custom PasswordHash class
            PasswordHash passwordHash = new PasswordHash(password);

            // Set the default role during registration
            string defaultRole = "Free";  // Set default role (e.g., Free, Pending, etc.)

            // Define the SQL query for inserting user details
            string userQuery = @"INSERT INTO UserDetails (FirstName, LastName, Role, DOB) 
                                 VALUES (@FirstName, @LastName, @Role, @DOB);
                                 SELECT SCOPE_IDENTITY();"; // Get the new UserID

            // Parameters for the user details query
            SqlParameter[] userParams = {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Role", defaultRole),  // Insert the default role here
                new SqlParameter("@DOB", dob)
            };

            // Execute the query and get the new UserID
            object userIdObj = db.ExecuteQuery(userQuery, userParams);
            if (userIdObj == null)
            {
                return false; // Insertion failed
            }

            // Convert the returned UserID to an integer
            int userId = Convert.ToInt32(userIdObj);

            // Define the SQL query for inserting login credentials
            string loginQuery = @"INSERT INTO Login (UserName, Password, UserID) 
                                  VALUES (@UserName, @Password, @UserID)";

            // Parameters for the login query
            SqlParameter[] loginParams = {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", Convert.ToBase64String(passwordHash.ToArray())), // Store the hashed password
                new SqlParameter("@UserID", userId)
            };

            // Execute the query to insert login credentials
            int rowsAffected = db.ExecuteNonQuery(loginQuery, loginParams);

            // Return true if the account creation was successful
            return rowsAffected > 0;
        }
    }
}
