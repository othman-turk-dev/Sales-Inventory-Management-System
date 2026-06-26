using System;
using System.Data;
using Data_Access_Layer;

public class ClsCustomers
{

    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
    public ClsCustomers()
    {

        this.CustomerID = null;
        this.Email = null;

        this.FirstName = "";
        this.LastName = "";
        this.Address = "";
        this.Phone = "";

        Mode = enMode.AddNew;
    
    }
    private ClsCustomers(int? CustomerID, string FirstName,
        string LastName, string Address, string Phone, string Email = null)
    {

        this.CustomerID = CustomerID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Address = Address;
        this.Phone = Phone;
        this.Email = Email;
        
        Mode = enMode.Update;
    
    }

    public bool Save()
    {

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

        this.CustomerID = ClsCustomerData.AddNewCustomers(this.FirstName,
            this.LastName, this.Address, this.Phone, this.Email);

        return this.CustomerID != null;
    }
    private bool _Update()
    {

        return ClsCustomerData.UpdateCustomers(this.CustomerID,this.FirstName,
            this.LastName, this.Address, this.Phone, this.Email);
    }

    public static ClsCustomers FindByCustomerID(int? CustomerID)
    {

        if(CustomerID == null) return null;

        string FirstName = "";
        string LastName = "";
        string Address = "";
        string Phone = "";
        string Email = "";

        bool IsFound = ClsCustomerData.GetCustomersByCustomerID(CustomerID,
            ref FirstName, ref LastName, ref Address, ref Phone, ref Email);

        if (IsFound)
            return new ClsCustomers(CustomerID, FirstName,
                LastName, Address, Phone, Email);
        
        else
            return null;
    
    }
    public static DataTable GetAllCustomers()
    {

        return ClsCustomerData.GetAllCustomers();
    }
    public bool DeleteCustomers()
    {

        if(CustomerID == null) return false;

        return ClsCustomerData.DeleteCustomers(this.CustomerID);
    }

}