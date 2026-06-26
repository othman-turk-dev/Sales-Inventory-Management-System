using System.Configuration;

namespace Data_Access_Layer
{
    public class ClsDataAccessSettings
    {
        public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
    }
}
