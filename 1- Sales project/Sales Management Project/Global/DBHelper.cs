using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Sales_Management_Project.Global
{
    public static class DBHelper
    {
        public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

        public static void SetDBLogonForReport(ReportDocument reportDocument)
        {
            var builder = new SqlConnectionStringBuilder(ConnectionString);

            foreach (Table table in reportDocument.Database.Tables)
            {
                var logOnInfo = table.LogOnInfo;

                logOnInfo.ConnectionInfo.ServerName = builder.DataSource;
                logOnInfo.ConnectionInfo.DatabaseName = builder.InitialCatalog;
                logOnInfo.ConnectionInfo.UserID = builder.UserID;
                logOnInfo.ConnectionInfo.Password = builder.Password;

                table.ApplyLogOnInfo(logOnInfo);
            }
        }
    }
}
