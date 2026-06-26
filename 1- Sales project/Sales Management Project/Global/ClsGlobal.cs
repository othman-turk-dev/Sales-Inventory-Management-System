using System;
using Microsoft.Win32;
using System.Reflection;

namespace Sales_Management_Project
{
    public static class ClsGlobal
    {
        public static ClsUsers CurrentUser;
        
        //
        public static bool WritingOnRegistry(string User = "", string Pass = "")
        {

            string ProjectName = Assembly.GetExecutingAssembly().GetName().Name;

            string Path = $"HKEY_CURRENT_USER\\SOFTWARE\\MyApplications\\{ProjectName}";

            string UserName = "Username";
            string Password = "Password";

            try
            {

                Registry.SetValue(Path, UserName, User, RegistryValueKind.String);
                Registry.SetValue(Path, Password, Pass, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {

                ClsErrorLog.HandleError(ex.ToString(), nameof(WritingOnRegistry));

                return false;
            }

        }
        public static bool ReadFromRegistry(ref string User, ref string Pass)
        {

            string ProjectName = Assembly.GetExecutingAssembly().GetName().Name;

            string Path = $"HKEY_CURRENT_USER\\SOFTWARE\\MyApplications\\{ProjectName}";

            string UserName = "Username";
            string Password = "Password";

            try
            {

                User = Registry.GetValue(Path, UserName, null) as string;
                Pass = Registry.GetValue(Path, Password, null) as string;

                if (User == null || Pass == null)
                    return false;


                return true;
            }
            catch (Exception ex)
            {

                ClsErrorLog.HandleError(ex.ToString(), nameof(ReadFromRegistry));

                return false;
            }

        }

    }
}
