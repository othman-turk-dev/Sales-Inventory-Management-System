using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsProductData
    {
        public static int? AddNewProducts(int CategoryID, string ProductName,
            int Quantity, decimal Price, string Image)
        {

            int? ProductID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Products 
                                (CategoryID, ProductName, Quantity, Price, Image)
                                VALUES 
                                (@CategoryID, @ProductName, @Quantity, @Price, @Image);
        
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);

                    if (Image != "" && Image != null)
                        command.Parameters.AddWithValue("@Image", Image);
                    else
                        command.Parameters.AddWithValue("@Image", System.DBNull.Value);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ProductID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewProducts));
                    }
                }
            }

            return ProductID;
        
        }

        public static bool GetProductsByProductID(int? ProductID, ref int CategoryID,
            ref string ProductName, ref int Quantity, ref decimal Price, ref string Image)
        {
         
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = "SELECT * FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                isFound = true;

                                CategoryID = (int)reader["CategoryID"];
                                ProductName = (string)reader["ProductName"];
                                Quantity = (int)reader["Quantity"];
                                Price = (decimal)reader["Price"];

                                Image = reader["Image"] != DBNull.Value ? (string)reader["Image"] : null;

                            }
                            else
                            {

                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(GetProductsByProductID));
                    }
                }
            }

            return isFound;
        
        }

        public static bool UpdateProducts(int? ProductID, int CategoryID,
            string ProductName, int Quantity, decimal Price, string Image)
        {
            
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Products 
                             SET
                             CategoryID = @CategoryID,
                             ProductName = @ProductName,
                             Quantity = @Quantity,
                             Price = @Price,
                             Image = @Image
                             WHERE  
                             ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);

                    command.Parameters.AddWithValue("@Image", Image ?? (object)System.DBNull.Value);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateProducts));
                    }
                }
            }

            return rowsAffected > 0;
        
        }
        
        public static bool UpdateQuantityProduct(int? ProductID, int Quantity)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Products 
                                 SET Quantity += @Quantity
                                 where Products.ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateQuantityProduct));
                    }
                }
            }

            return rowsAffected > 0;

        }
        public static DataTable GetAllProducts()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT Products.ProductID,
                                        Products.ProductName,
                                        Categories.Description As ProductCategory,
                                        Products.Quantity,
                                        Products.Price,
                                        Products.Image
                                FROM    Products
                                INNER JOIN Categories 
                                ON Products.CategoryID = Categories.CategoryID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetAllProducts));
                    }
                }
            }

            return dt;

        }
        public static bool DeleteProducts(int? ProductID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"DELETE FROM Products 
                                 WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(DeleteProducts));
                    }
                }
            }

            return rowsAffected > 0;
        
        }
        
    }
}
