using System;
using System.Data;
using Data_Access_Layer;

public class ClsCategories
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int? CategoryID { get; set; }
    public string Description { get; set; }
    public ClsCategories()
    {

        this.CategoryID = null;
        
        this.Description = "";
        Mode = enMode.AddNew;
    }
    private ClsCategories(int? CategoryID, string Description)
    {

        this.CategoryID = CategoryID;
        this.Description = Description;
        
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

        this.CategoryID = ClsCategoryData.AddNewCategories(this.Description);
        return this.CategoryID != null;
    }
    private bool _Update()
    {

        return ClsCategoryData.UpdateCategories(this.CategoryID, this.Description);
    }

    public static ClsCategories FindByCategoryID(int? CategoryID)
    {

        string Description = "";

        bool IsFound = ClsCategoryData.GetCategoriesByCategoryID(CategoryID, ref Description);

        if (IsFound)
            return new ClsCategories(CategoryID, Description);
        
        else
            return null;
    
    }
    public static ClsCategories FindByCategoryDescription(string Description)
    {

        int? CategoryID = null;

        bool IsFound = ClsCategoryData.GetCategoriesByCategoryDescription
            (ref CategoryID, Description);

        if (IsFound)
            return new ClsCategories(CategoryID, Description);

        else
            return null;

    }
    public static DataTable GetAllCategoriess()
    {

        return ClsCategoryData.GetAllCategories();
    }
    public bool DeleteCategories()
    {

        return ClsCategoryData.DeleteCategories(this.CategoryID);
    }

}