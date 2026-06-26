using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsOrderDetailsData
    {

        public static int? AddNewOrderDetails(int OrderID, int ProductID,
            int Quantity, decimal UnitPrice, decimal Discount,
            decimal AmountPaid, decimal TotalAmount)
        {

            int? OrderDetailID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO OrderDetails 
                                (OrderID, ProductID, Quantity, UnitPrice, Discount,
                                    AmountPaid, TotalAmount)
                                VALUES 
                                (@OrderID, @ProductID, @Quantity, @UnitPrice, @Discount,
                                @AmountPaid, @TotalAmount);
        
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                    command.Parameters.AddWithValue("@Discount", Discount);
                    command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                    command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            OrderDetailID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewOrderDetails));
                    }
                }
            }

            return OrderDetailID;
        
        }
        
        public static bool UpdateOrderDetails(int? OrderDetailID, int OrderID,
            int ProductID, int Quantity, decimal UnitPrice, decimal Discount,
            decimal AmountPaid, decimal TotalAmount)
        {
         
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = @"UPDATE OrderDetails 
                                 SET
                                 OrderID = @OrderID,
                                 ProductID = @ProductID,
                                 Quantity = @Quantity,
                                 UnitPrice = @UnitPrice,
                                 Discount = @Discount,
                                 AmountPaid = @AmountPaid,
                                 TotalAmount = @TotalAmount

                                 WHERE 
                                 OrderDetailID = @OrderDetailID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                    command.Parameters.AddWithValue("@Discount", Discount);
                    command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                    command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateOrderDetails));
                    }
                }
            }

            return rowsAffected > 0;
        
        }

        public static DataTable GetAllByOrderID(int OrderID)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT OrderDetails.OrderDetailID, OrderDetails.OrderID,
                                OrderDetails.ProductID, Products.ProductName, OrderDetails.Quantity,
                                OrderDetails.UnitPrice, OrderDetails.Discount, OrderDetails.AmountPaid,
                                OrderDetails.TotalAmount, Orders.CreatedDate, Orders.Description, Users.UserName,
                                Orders.CustomerID, Customers.FirstName+ ' ' + Customers.LastName as FullName,
                                Customers.Phone, Customers.Address
                                FROM     Customers
                                INNER JOIN
                                Orders ON Customers.CustomerID = Orders.CustomerID 
                                INNER JOIN
                                OrderDetails ON Orders.OrderID = OrderDetails.OrderID 
                                INNER JOIN
                                Products ON OrderDetails.ProductID = Products.ProductID 
                                INNER JOIN
                                Users ON Orders.CreatedByUserID = Users.UserID
                                where Orders.OrderID = @OrderID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;

        }

    }
}
