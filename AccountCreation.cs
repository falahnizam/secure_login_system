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

        // Method to create an account (register user) with "Pending" role
        public bool CreateAccount(string username, string password, string firstName, string lastName, DateTime dob)
        {
            try
            {
                // Hash the password using your custom PasswordHash class
                PasswordHash passwordHash = new PasswordHash(password);

                // Define the default RoleID for "Pending" (Assuming RoleID 4 is for "Pending")
                int pendingRoleID = 4;

                // Define the SQL query for inserting user details
                string userQuery = @"INSERT INTO UserDetails (FirstName, LastName, DOB, RoleID) 
                                 VALUES (@FirstName, @LastName, @DOB, @RoleID);
                                 SELECT SCOPE_IDENTITY();"; // Get the new UserID

                // Parameters for the user details query
                SqlParameter[] userParams = {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@DOB", dob),
                new SqlParameter("@RoleID", pendingRoleID)  // Insert the "Pending" role ID
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
            catch (Exception ex)
            {
                // Log the exception details (consider logging to a file or system)
                Console.WriteLine($"Error creating account: {ex.Message}");
                // Log stack trace for debugging
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }

        public class UserAuthenticationResult
        {
            public bool IsAuthenticated { get; set; }
            public int RoleID { get; set; }

        }

        // Method to authenticate a user during login
        public UserAuthenticationResult AuthenticateUser(string username, string password)
        {
            // Query to retrieve the stored password hash and RoleID for the given username
            string query = @"SELECT L.Password, UD.RoleID 
                     FROM Login L
                     INNER JOIN UserDetails UD ON L.UserID = UD.UserID
                     WHERE L.UserName = @UserName";
            SqlParameter[] parameters = {
        new SqlParameter("@UserName", username)
    };

            // Execute the query
            DataSet result = db.ExecuteQuery(query, parameters);

            // Check if a user was found and retrieve the stored password and role
            if (result.Tables[0].Rows.Count > 0)
            {
                // First check if the RoleID and Password columns are not null
                if (!Convert.IsDBNull(result.Tables[0].Rows[0]["RoleID"]) && !Convert.IsDBNull(result.Tables[0].Rows[0]["Password"]))
                {
                    // Get the RoleID (e.g., 1 = Admin, 2 = User, 4 = Pending)
                    int roleId = Convert.ToInt32(result.Tables[0].Rows[0]["RoleID"]);

                    // Retrieve the stored password as a byte array
                    byte[] storedHashBytes = Convert.FromBase64String(result.Tables[0].Rows[0]["Password"].ToString());

                    // Create a PasswordHash instance using the stored hash bytes
                    PasswordHash storedPasswordHash = new PasswordHash(storedHashBytes);

                    // Verify the entered password
                    if (storedPasswordHash.Verify(password))
                    {
                        // If password matches, return authentication success and RoleID
                        return new UserAuthenticationResult
                        {
                            IsAuthenticated = true,
                            RoleID = roleId  // Return the RoleID for redirection logic
                        };
                    }
                }
            }

            // Return failed authentication
            return new UserAuthenticationResult
            {
                IsAuthenticated = false,
                RoleID = 0  // Invalid or no role for failed login
            };
        }


        // Method to get a list of users with the "Pending" role for the admin to review
        public DataSet GetPendingUsers()
        {
            string query = "SELECT UserID, FirstName, LastName, DOB FROM UserDetails WHERE RoleID = 4"; // Assuming RoleID 4 is "Pending"
            return db.ExecuteQuery(query);
        }

        // Method for admin to update a user's role (authorize users)
        public bool AuthorizeUser(int userId, int newRoleId)
        {
            // Query to update the role of a user in the UserDetails table
            string query = "UPDATE UserDetails SET RoleID = @RoleID WHERE UserID = @UserID";
            SqlParameter[] parameters = {
                new SqlParameter("@RoleID", newRoleId),  // Assign new role
                new SqlParameter("@UserID", userId)
            };

            // Execute the query to update the user's role
            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0; // Return true if the role update was successful
        }

        // Method to update user role manually (for admin role management)
        public bool UpdateUserRole(int userId, int newRoleId)
        {
            // Similar to the AuthorizeUser method but for general role updates
            return AuthorizeUser(userId, newRoleId);
        }
        public bool RejectUser(int userId, string reason)
        {
            try
            {
                // Insert a record into the RejectedUsers table
                string query = @"INSERT INTO RejectedUsers (UserID, Reason) 
                         VALUES (@UserID, @Reason)";
                SqlParameter[] parameters = {
            new SqlParameter("@UserID", userId),
            new SqlParameter("@Reason", reason)
        };

                int rowsAffected = db.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    // Only delete from UserDetails if the rejection record is successfully inserted
                    string deleteQuery = "DELETE FROM UserDetails WHERE UserID = @UserID";
                    db.ExecuteNonQuery(deleteQuery, new SqlParameter[] { new SqlParameter("@UserID", userId) });
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error rejecting user: {ex.Message}");
                return false;
            }
        }

    }
}