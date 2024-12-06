using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
        public bool CreateAccount(string username, string password, string firstName, string lastName, DateTime dob, string gender)
        {
            try
            {
                // Hash the password using your custom PasswordHash class
                PasswordHash passwordHash = new PasswordHash(password);

                // Define the default RoleID for "Pending" (Assuming RoleID 4 is for "Pending")
                int pendingRoleID = 4;



                // Define the SQL query for inserting user details (including gender)
                string userQuery = @"INSERT INTO UserDetails (FirstName, LastName, DOB, Gender, RoleID) 
                             VALUES (@FirstName, @LastName, @DOB, @Gender, @RoleID);
                             SELECT SCOPE_IDENTITY();"; // Get the new UserID

                SqlParameter[] userParams = {
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@DOB", dob),
            new SqlParameter("@Gender", gender),
            new SqlParameter("@RoleID", pendingRoleID)
        };

                // Execute the query and get the new UserID
                DataSet result = db.ExecuteQuery(userQuery, userParams);
                if (result.Tables[0].Rows.Count == 0)
                {
                    Console.WriteLine("User details insertion failed.");
                    return false; // Insertion failed
                }

                int userId = Convert.ToInt32(result.Tables[0].Rows[0][0]);

                string loginQuery = @"INSERT INTO Login (UserName, Password, UserID) 
                              VALUES (@UserName, @Password, @UserID)";

                SqlParameter[] loginParams = {
            new SqlParameter("@UserName", username),
            new SqlParameter("@Password", Convert.ToBase64String(passwordHash.ToArray())),
            new SqlParameter("@UserID", userId)
        };

                // Execute the query to insert login credentials
                int rowsAffected = db.ExecuteNonQuery(loginQuery, loginParams);
                if (rowsAffected <= 0)
                {
                    Console.WriteLine("Login credentials insertion failed.");
                    return false; // Insertion failed
                }

                return true; // Account creation successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        public class UserAuthenticationResult
        {
            public bool IsAuthenticated { get; set; }
            public int RoleID { get; set; }
            public int UserID { get; set; }
        }

        // Method to authenticate a user during login
        public UserAuthenticationResult AuthenticateUser(string username, string password)
        {
            // Query to retrieve the stored password hash and RoleID for the given username
            string query = @"SELECT L.Password, UD.RoleID, L.UserID
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
                // Check if the RoleID and Password columns are not null
                if (!Convert.IsDBNull(result.Tables[0].Rows[0]["RoleID"]) && 
                    !Convert.IsDBNull(result.Tables[0].Rows[0]["Password"])&& 
                    !Convert.IsDBNull(result.Tables[0].Rows[0]["UserID"]))
                {
                    // Get the RoleID (e.g., 1 = Admin, 2 = User, 4 = Pending) and UserID
                    int roleId = Convert.ToInt32(result.Tables[0].Rows[0]["RoleID"]);
                    int userId = Convert.ToInt32(result.Tables[0].Rows[0]["UserID"]);

                    // Retrieve the stored password as a byte array
                    byte[] storedHashBytes = Convert.FromBase64String(result.Tables[0].Rows[0]["Password"].ToString());

                    // Create a PasswordHash instance using the stored hash bytes
                    PasswordHash storedPasswordHash = new PasswordHash(storedHashBytes);

                    // Verify the entered password
                    if (storedPasswordHash.Verify(password))
                    {
                        // If password matches, return authentication success, RoleID
                        return new UserAuthenticationResult
                        {
                            IsAuthenticated = true,
                            RoleID = roleId, // Return the RoleID
                            UserID = userId,//Return the UserID
                        };
                    }
                }
            }

            // Return failed authentication if password verification or user lookup failed
            return new UserAuthenticationResult
            {
                IsAuthenticated = false,
                RoleID = 0,  // Invalid or no role for failed login
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
                // Update the user's RoleID to 'Rejected' (assuming RoleID = 3 for 'Rejected' users)
                string updateQuery = "UPDATE UserDetails SET RoleID = 3 WHERE UserID = @UserID";

                SqlParameter[] updateParams = {
            new SqlParameter("@UserID", userId)
        };

                int rowsAffected = db.ExecuteNonQuery(updateQuery, updateParams);

                // If the user's role was successfully updated, insert the rejection reason into RejectedUsers table
                if (rowsAffected > 0)
                {
                    string insertQuery = @"INSERT INTO RejectedUsers (UserID, Reason) 
                                   VALUES (@UserID, @Reason)";
                    SqlParameter[] insertParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Reason", reason)
            };

                    db.ExecuteNonQuery(insertQuery, insertParams);

                    return true;  // Return success
                }

                return false;  // Return failure if no rows were affected
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error rejecting user: {ex.Message}");
                return false;
            }
        }


    }
}
