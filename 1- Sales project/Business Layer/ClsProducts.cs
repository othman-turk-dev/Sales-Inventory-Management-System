using System;
using System.Data;
using Data_Access_Layer;

public class ClsProducts
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? ProductID { get; set; }
    public int? CategoryID { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }

    ClsCategories CategoryInfo;

    public ClsProducts()
    {

        this.ProductID = null;
        this.Image = null;
        
        this.CategoryID = -1;
        this.ProductName = "";
        this.Quantity = -1;
        this.Price = 0;

        Mode = enMode.AddNew;
    }

    private ClsProducts(int? ProductID, int CategoryID, string ProductName,
        int Quantity, decimal Price, string Image = null)
    {

        this.ProductID = ProductID;
        this.CategoryID = CategoryID;
        this.ProductName = ProductName;
        this.Quantity = Quantity;
        this.Price = Price;
        this.Image = Image;
        
        this.CategoryInfo = ClsCategories.FindByCategoryID(CategoryID);

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

        this.ProductID = ClsProductData.AddNewProducts((int)this.CategoryID,
            this.ProductName, this.Quantity, this.Price, this.Image);
        return this.ProductID != null;
    }
    private bool _Update()
    {

        return ClsProductData.UpdateProducts(this.ProductID, (int)this.CategoryID,
            this.ProductName, this.Quantity, this.Price, this.Image);
    }

    public static ClsProducts FindByProductID(int? ProductID)
    {

        int CategoryID = -1;
        string ProductName = "";
        int Quantity = -1;
        decimal Price = 0;
        string Image = null;

        bool IsFound = ClsProductData.GetProductsByProductID(ProductID,
            ref CategoryID, ref ProductName, ref Quantity, ref Price, ref Image);

        if (IsFound)
            return new ClsProducts(ProductID, CategoryID, ProductName,
                Quantity, Price, Image);
        
        else
            return null;
    
    }
    public static bool UpdateQuantityProduct(int ProductID,int Quantity)
    {

        return ClsProductData.UpdateQuantityProduct(ProductID, Quantity);
    }
    public static DataTable GetAllProductss()
    {

        return ClsProductData.GetAllProducts();
    }
    public bool DeleteProducts()
    {

        return ClsProductData.DeleteProducts(this.ProductID);
    }

}