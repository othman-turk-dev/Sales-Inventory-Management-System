using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsUserData
    {

        public static int? AddNewUsers(string UserName, string Password,
            int Permission, bool IsActive)
        {

            int? UserID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO Users 
                                (UserName, Password, Permission, IsActive)
                                VALUES 
                                (@UserName, @Password, @Permission, @IsActive);

                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Permission", Permission);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            UserID = insertedID;
                        }

                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewUsers));
                    }
                }
            }

            return UserID;
        
        }

        public static bool GetUsersByUserID(int? UserID, ref string UserName,
            ref string Password, ref int Permission, ref bool IsActive)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                Permission = (int)reader["Permission"];
                                IsActive = (bool)reader["IsActive"];

                            }
                            else
                            {

                                isFound = false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(GetUsersByUserID));
                    }
                }
            }

            return isFound;
        
        }

        public static bool GetUsersByUserNameAndPassword(ref int? UserID, string UserName,
            string Password, ref int Permission, ref bool IsActive)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM Users WHERE UserName = @UserName 
                                 And Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                UserID = (int)reader["UserID"];
                                Permission = (int)reader["Permission"];
                                IsActive = (bool)reader["IsActive"];

                            }
                            else
                            {

                                isFound = false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetUsersByUserNameAndPassword));
                    }
                }
            }

            return isFound;

        }

        public static bool GetUsersByUserName(ref int? UserID, string UserName,
            ref string Password, ref int Permission, ref bool IsActive)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM Users WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                UserID = (int)reader["UserID"];
                                Password = (string)reader["Password"];
                                Permission = (int)reader["Permission"];
                                IsActive = (bool)reader["IsActive"];

                            }
                            else
                            {

                                isFound = false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetUsersByUserName));
                    }
                }
            }

            return isFound;

        }

        public static bool UpdateUsers(int? UserID, string UserName,
            string Password, int Permission, bool IsActive)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users 
                                SET
                                UserName = @UserName,
                                Password = @Password,
                                Permission = @Permission,
                                IsActive = @IsActive

                                WHERE
                                UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Permission", Permission);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateUsers));
                    }
                }
            }

            return rowsAffected > 0;
        
        }

        public static bool SetInActiveUser(int? UserID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users 
                                SET
                                IsActive = 0

                                WHERE
                                UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(SetInActiveUser));
                    }
                }
            }

            return rowsAffected > 0;

        }
        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT UserID, UserName,
                                 CASE WHEN Users.Permission = -1 THEN 'Admin'
                                 WHEN Users.Permission = 0 THEN 'User' END AS  Permission,

                                 CASE WHEN Users.IsActive = 0 THEN 'No' 
                                 WHEN Users.IsActive = 1 THEN 'Yes' END AS  IsActive

                                FROM     Users";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(GetAllUsers));
                    }
                }
            }

            return dt;

        }
        
    }
}
