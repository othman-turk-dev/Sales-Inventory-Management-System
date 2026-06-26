using System;
using Data_Access_Layer;
using System.Data.SqlClient;

public static class ClsBackupAndRestorData
{

    //If s database is deleted,it can be recovered
    //For this reason selected (Database=master) in RestoreDB

    public static bool BackupDB(string FileName)
    {

        using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
        {

            string query = $@"Backup Database Sales_ManagementDB
                                to Disk = '{FileName}'";

            using (SqlCommand command = new SqlCommand(query, connection))
            {

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(BackupDB));

                    return false;
                }
            }
        }

    }
    public static bool RestoreDB(string FileName)
    {


        string ConnectionString = ClsDataAccessSettings.ConnectionString.Replace(
        "Initial Catalog=Sales_ManagementDB",
        "Initial Catalog=master");

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {

            //Check if databsae exists or not 
            //For Alter or Restore Operation 

            string checkDbQuery = @"SELECT COUNT(*) FROM sys.databases 
                                    WHERE name = 'Sales_ManagementDB'";

            try
            {

                connection.Open();

                bool dbExists;

                using (SqlCommand checkCmd = new SqlCommand(checkDbQuery, connection))
                {
                    dbExists = (int)checkCmd.ExecuteScalar() > 0;
                }

                string query;

                if (dbExists)
                {

                    query = $@"
                    ALTER DATABASE Sales_ManagementDB 
                    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

                    RESTORE DATABASE Sales_ManagementDB
                    FROM DISK = '{FileName}' WITH REPLACE;

                    ALTER DATABASE Sales_ManagementDB 
                    SET MULTI_USER;";

                }
                else
                {

                    query = $@"
                    RESTORE DATABASE Sales_ManagementDB
                    FROM DISK = '{FileName}' WITH REPLACE;";

                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                return true;

            }
            catch (Exception ex)
            {
                ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(RestoreDB));
                
                return false;
            }

        }
    }

}
