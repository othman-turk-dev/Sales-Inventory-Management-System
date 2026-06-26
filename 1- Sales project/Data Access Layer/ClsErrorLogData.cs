using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsErrorLogData
    {
        enum enStatus { New = 1, Complete = 2 };

        public static bool GetErrorByErrorID(int? ErrorID, ref string ErrorMessage,
            ref string ErrorPlace, ref DateTime ErrorDate, ref int Status)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM ErrorLog 
                                 WHERE ErrorID = @ErrorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ErrorID", ErrorID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                isFound = true;

                                ErrorMessage = (string)reader["ErrorMessage"];
                                ErrorPlace = (string)reader["ErrorPlace"];
                                ErrorDate = (DateTime)reader["ErrorDate"];
                                Status = (byte)reader["Status"];

                            }
                            else
                            {

                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetErrorByErrorID));
                    }
                }
            }

            return isFound;

        }
        
        public static int? AddNewErrorLog(string ErrorMessage,string ErrorPlace = null)
        {

            int? ErrorID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO ErrorLog 
                                (ErrorMessage, ErrorPlace, ErrorDate, Status)
                                VALUES 
                                (@ErrorMessage, @ErrorPlace, @ErrorDate, @Status);
        
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
                    command.Parameters.AddWithValue("@ErrorPlace", ErrorPlace ?? (object)System.DBNull.Value);
                    command.Parameters.AddWithValue("@ErrorDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Status", (int)enStatus.New);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ErrorID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

            return ErrorID;
        
        }
        public static DataTable GetAllErrorsLog()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT ErrorID, ErrorMessage, ErrorPlace, ErrorDate,
                                CASE WHEN ErrorLog.Status = 1 THEN 'New'
                                WHEN ErrorLog.Status = 2 THEN 'Completed' END AS  Status
                                FROM     ErrorLog
                                Order by ErrorID Desc";


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

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetAllErrorsLog));
                    }
                }
            }

            return dt;

        }
        public static bool SetComplete(int? ErrorID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"Update ErrorLog
                                 SET Status = 2
                                 where ErrorLog.ErrorID = @ErrorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ErrorID", ErrorID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(SetComplete));
                    }
                }
            }

            return rowsAffected > 0;
        }

    }
}
