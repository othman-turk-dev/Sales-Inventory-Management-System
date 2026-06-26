using System;
using System.Data;
using Data_Access_Layer;

public class ClsErrorLog
{

    public enum enStatus { New = 1, Complete = 2 };

    public int? ErrorID { get; set; }
    public string ErrorMessage { get; set; }
    public string ErrorPlace { get; set; }
    public DateTime ErrorDate { get; set; }
    public enStatus Status { get; set; }
    
    public string StatusMessage 
    { 
        get
        {
            switch(this.Status)
            {
                case enStatus.New:
                    return "New";

                case enStatus.Complete:
                    return "Complete";

                default:
                    return "Unknow";

            }
        }
    
    }
    public ClsErrorLog()
    {

        this.ErrorID = null;

        this.ErrorMessage = "";
        this.ErrorPlace = "";
        this.ErrorDate = DateTime.Now;
        this.Status = enStatus.New;

    }

    private ClsErrorLog(int? ErrorID, string ErrorMessage, string ErrorPlace,
        DateTime ErrorDate, enStatus Status)
    {

        this.ErrorID = ErrorID;
        this.ErrorMessage = ErrorMessage;
        this.ErrorPlace = ErrorPlace;
        this.ErrorDate = ErrorDate;
        this.Status = Status;
        
    }

    public static bool HandleError(string ErrorMessage, string ErrorPlace)
    {

        int ? ErrorID = null;
        ErrorID = ClsErrorLogData.AddNewErrorLog(ErrorMessage, ErrorPlace);
        
        return ErrorID != null;
    }
    public static ClsErrorLog FindByErrorID(int? ErrorID)
    {

        string ErrorMessage = "";
        string ErrorPlace = "";

        DateTime ErrorDate = DateTime.Now;
        int Status = (int)enStatus.New;

        bool IsFound = ClsErrorLogData.GetErrorByErrorID(ErrorID, ref ErrorMessage,
            ref ErrorPlace, ref ErrorDate, ref Status);

        if (IsFound)
            return new ClsErrorLog(ErrorID, ErrorMessage, ErrorPlace, ErrorDate, (enStatus)Status);
        
        else
            return null;
    
    }
    public static DataTable GetAllErrorLogs()
    {

        return ClsErrorLogData.GetAllErrorsLog();
    }
    public static bool SetComplete(int? ErrorID)
    {

        return ClsErrorLogData.SetComplete(ErrorID);
    }

}