using System;
using System.Data;
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
            DataSet result = db.ExecuteQuery(userQuery, userParams);
            if (result.Tables[0].Rows.Count == 0)
            {
                return false; // Insertion failed, no result
            }

            // Access the UserID from the first row, first column of the result
            int userId = Convert.ToInt32(result.Tables[0].Rows[0][0]);

            // Define the SQL query for inserting login credentials
            string loginQuery = @"INSERT INTO Login (UserName, Password, UserID) 
                          VALUES (@UserName, @Password, @UserID)";

            // Parameters for the login query
            SqlParameter[] loginParams = {
        new SqlParameter("@UserName", username),
        new SqlParameter("@Password", Convert.ToBase64String(passwordHash.ToArray())), // Store the hashed password
        new SqlParameter("@UserID", userId)  // Use the int value for UserID
    };

            // Execute the query to insert login credentials
            int rowsAffected = db.ExecuteNonQuery(loginQuery, loginParams);

            // Return true if the account creation was successful
            return rowsAffected > 0;
        }

        // Method to authenticate a user during login
        // Method to authenticate a user during login
        public bool AuthenticateUser(string username, string password)
        {
            // Query to retrieve the stored password hash for the given username
            string query = "SELECT Password FROM Login WHERE UserName = @UserName";
            SqlParameter[] parameters = {
        new SqlParameter("@UserName", username)
    };

            // Execute the query
            DataSet result = db.ExecuteQuery(query, parameters);

            // Check if a user was found and retrieve the stored password
            if (result.Tables[0].Rows.Count > 0)
            {
                // Retrieve the stored password as a byte array
                byte[] storedHashBytes = Convert.FromBase64String(result.Tables[0].Rows[0]["Password"].ToString());

                // Create a PasswordHash instance using the stored hash bytes
                PasswordHash storedPasswordHash = new PasswordHash(storedHashBytes);

                // Use the Verify method to check if the entered password matches the stored hash
                return storedPasswordHash.Verify(password);
            }

            return false; // Return false if no matching user found or password verification fails
        }

        // Method to update user role (optional, if you have an admin dashboard for role management)
        public bool UpdateUserRole(int userId, string newRole)
        {
            // Query to update the role of a user in the UserDetails table
            string query = "UPDATE UserDetails SET Role = @Role WHERE UserID = @UserID";
            SqlParameter[] parameters = {
                new SqlParameter("@Role", newRole),
                new SqlParameter("@UserID", userId)
            };

            // Execute the query to update role
            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0; // Return true if the role update was successful
        }
    }
}
