using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsCategoryData
    {

        public static int? AddNewCategories(string Description)
        {

            int? CategoryID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Categories (Description)
                                 VALUES (@Description);
                                 
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", Description);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CategoryID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewCategories));
                    }
                }
            }

            return CategoryID;
        
        }
        public static bool GetCategoriesByCategoryID(int? CategoryID, ref string Description)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;
                                Description = (string)reader["Description"];
                            }
                            else
                            {

                                isFound = false;
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetCategoriesByCategoryID));
                    }
                }
            }

            return isFound;
        
        }
        public static bool GetCategoriesByCategoryDescription(ref int? CategoryID, string Description)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Categories WHERE Description = @Description";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", Description);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;
                                CategoryID = (int)reader["CategoryID"];

                            }
                            else
                            {

                                isFound = false;
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetCategoriesByCategoryDescription));
                    }
                }
            }

            return isFound;

        }
        public static bool UpdateCategories(int? CategoryID, string Description)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Categories 
                                 SET
                                 Description = @Description
                                 WHERE
                                 CategoryID = @CategoryID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@Description", Description);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateCategories));
                    }
                }
            }

            return rowsAffected > 0;
        
        }
        public static bool DeleteCategories(int? CategoryID)
        {
            
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"DELETE FROM Categories 
                                 WHERE CategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(DeleteCategories));
                    }
                }
            }
            
            return rowsAffected > 0;

        }
        public static DataTable GetAllCategories()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * From Categories";


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

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetAllCategories));
                    }
                }
            }

            return dt;

        }

    }
}
