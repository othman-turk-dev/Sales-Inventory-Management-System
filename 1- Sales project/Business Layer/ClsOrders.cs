using System;
using System.Data;
using Data_Access_Layer;

public class ClsOrders
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public int CreatedByUserID { get; set; }

    public ClsUsers UserInfo;

    public ClsCustomers CustomerInfo;
    public ClsOrders()
    {

        this.OrderID = null;

        this.CustomerID = -1;
        this.CreatedDate = DateTime.Now;
        this.Description = string.Empty;
        this.CreatedByUserID = -1;

        Mode = enMode.AddNew;
    }

    private ClsOrders(int? OrderID, int CustomerID,
        DateTime CreatedDate, string Description, int CreatedByUserID)
    {

        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.CreatedDate = CreatedDate;
        this.Description = Description; 
        this.CreatedByUserID = CreatedByUserID;

        this.UserInfo = ClsUsers.FindByUserID(CreatedByUserID);
        this.CustomerInfo = ClsCustomers.FindByCustomerID(CustomerID);

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

        return ClsOrderData.AddNewOrders(this.OrderID, this.CustomerID,
            this.Description, this.CreatedByUserID);

    }
    private bool _Update()
    {
        
        return ClsOrderData.UpdateOrders(this.OrderID, this.CustomerID,
           this.Description, this.CreatedByUserID);
    }
    public static int GetNextOrderID()
    {

        return ClsOrderData.GetNextOrderID();
    }
    public static int GetLastOrderID()
    {

        return ClsOrderData.GetLastOrderID();
    }
    public static DataTable GetAllOrders()
    {

        return ClsOrderData.GetAllOrders();
    }

}