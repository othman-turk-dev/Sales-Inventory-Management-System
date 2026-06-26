using System;
using System.Data;
using Data_Access_Layer;


// Encrypt Password when Save
// Decrypt Password when Find

public class ClsUsers
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Permission { get; set; }
    public bool IsActive { get; set; }

    public ClsUsers()
    {

        this.UserID = null;
        
        this.UserName = "";
        this.Password = "";
        this.Permission = -1;
        this.IsActive = true;
        
        Mode = enMode.AddNew;
    
    }
    private ClsUsers(int? UserID, string UserName, string Password, int Permission, bool IsActive)
    {

        this.UserID = UserID;
        this.UserName = UserName;
        this.Password = Password;
        this.Permission = Permission;
        this.IsActive = IsActive;

        Mode = enMode.Update;
    }

    public bool Save()
    {

        this.Password = ClsTools.EncryptText(this.Password);

        switch (Mode)
        {
            case enMode.AddNew:
         
                if (_AddNew())
                {
                    Mode = enMode.Update;
                
                    return true;
                }
                else return false;

            case enMode.Update:
                return _Update();

        }

        return false;
    
    }
    private bool _AddNew()
    {

        this.UserID = ClsUserData.AddNewUsers(this.UserName,
            this.Password, this.Permission, this.IsActive);
        
        return this.UserID != null;
    }
    private bool _Update()
    {

        return ClsUserData.UpdateUsers(this.UserID ,this.UserName,
            this.Password, this.Permission, this.IsActive);
    }

    public static bool SetInActiveUser(int? UserID)
    {

        return ClsUserData.SetInActiveUser(UserID);
    }
    public static ClsUsers FindByUserID(int? UserID)
    {

        string UserName = "";
        string Password = "";
        int Permission = -1;
        bool IsActive = true;

        bool IsFound = ClsUserData.GetUsersByUserID(UserID, ref UserName,
            ref Password, ref Permission, ref IsActive);

        Password = ClsTools.DecryptText(Password);

        if (IsFound)
            return new ClsUsers(UserID, UserName, 
                Password, Permission, IsActive);
        
        else
            return null;
    
    }
    public static ClsUsers FindByUserNameAndPassword(string UserName,string Password)
    {

        int? UserID = null;
        int Permission = -1;
        bool IsActive = true;

        // Encrypt password entered during the login process
        // For it matches the information in the database

        Password = ClsTools.EncryptText(Password);

        bool IsFound = ClsUserData.GetUsersByUserNameAndPassword(ref UserID, UserName,
            Password, ref Permission, ref IsActive);

        Password = ClsTools.DecryptText(Password);

        if (IsFound)
            return new ClsUsers(UserID, UserName,
                Password, Permission, IsActive);

        else
            return null;

    }
    public static ClsUsers FindByUserName(string UserName)
    {

        int? UserID = null;
        int Permission = -1;
        bool IsActive = true;
        string Password = "";

        bool IsFound = ClsUserData.GetUsersByUserName(ref UserID, UserName,
            ref Password, ref Permission, ref IsActive);

        Password = ClsTools.DecryptText(Password);

        if (IsFound)
            return new ClsUsers(UserID, UserName,
                Password, Permission, IsActive);

        else
            return null;

    }
    public static DataTable GetAllUserss()
    {

        return ClsUserData.GetAllUsers();
    }

}