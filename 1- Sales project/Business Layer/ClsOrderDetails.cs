using System;
using System.Data;
using Data_Access_Layer;

public class ClsOrderDetails
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? OrderDetailID { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal TotalAmount { get; set; }

    public ClsProducts ProductInfo;
    public ClsOrderDetails()
    {

        this.OrderDetailID = null;
        
        this.OrderID = -1;
        this.ProductID = -1;
        this.Quantity = 0;
        this.UnitPrice = 0;
        this.Discount = 0;
        this.AmountPaid = 0;
        this.TotalAmount = 0;
        
        Mode = enMode.AddNew;
    }

    private ClsOrderDetails(int? OrderDetailID, int OrderID, int ProductID,
        int Quantity, decimal UnitPrice, decimal Discount,
        decimal AmountPaid, decimal TotalAmount)
    {
        
        this.OrderDetailID = OrderDetailID;
        this.OrderID = OrderID;
        this.ProductID = ProductID;
        this.Quantity = Quantity;
        this.UnitPrice = UnitPrice;
        this.Discount = Discount;
        this.AmountPaid = AmountPaid;
        this.TotalAmount = TotalAmount;
        
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

        this.OrderDetailID = ClsOrderDetailsData.AddNewOrderDetails(this.OrderID,
            this.ProductID, this.Quantity, this.UnitPrice,this.Discount
            ,this.AmountPaid,this.TotalAmount);

        return this.OrderDetailID != null;
    }
    private bool _Update()
    {

        return ClsOrderDetailsData.UpdateOrderDetails(this.OrderDetailID,
            this.OrderID, this.ProductID, this.Quantity, this.UnitPrice,
            this.Discount, this.AmountPaid, this.TotalAmount);
    }
    public static DataTable GetAllByOrderID(int orderID)
    {

        return ClsOrderDetailsData.GetAllByOrderID(orderID);
    }

}