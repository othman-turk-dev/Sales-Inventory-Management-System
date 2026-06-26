using System;

namespace Business_Layer
{
    public static class ClsBackupAndRestor
    {
        public static bool IsBackupComplete(string FileName)
        {

            return ClsBackupAndRestorData.BackupDB(FileName);
        }
        public static bool IsRestoreComplete(string FileName)
        {

            return ClsBackupAndRestorData.RestoreDB(FileName);
        }

    }
}
