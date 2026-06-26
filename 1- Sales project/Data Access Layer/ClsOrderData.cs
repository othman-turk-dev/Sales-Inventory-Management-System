using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsOrderData
    {
        public static bool AddNewOrders(int? OrderID, int CustomerID,
            string Description, int CreatedByUserID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Orders 
                                (OrderID, CustomerID, CreatedDate,
                                    Description, CreatedByUserID)
                                VALUES 
                                (@OrderID, @CustomerID, @CreatedDate,
                                    @Description, @CreatedByUserID)";
        

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                 
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewOrders));
                    }

                }
            }

            return rowsAffected > 0;
        
        }

        public static bool UpdateOrders(int? OrderID, int CustomerID,
            string Description, int CreatedByUserID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Orders 
                                SET
                                CustomerID = @CustomerID,
                                CreatedDate = @CreatedDate,
                                Description = @Description,
                                CreatedByUserID = @CreatedByUserID
                                WHERE
                                OrderID = @OrderID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateOrders));
                    }
                }
            }

            return rowsAffected > 0;
        
        }

        public static int GetNextOrderID()
        {

            int nextOrderID = 1; 

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT ISNULL(MAX(OrderID), 0) + 1 AS NextOrderID
                                 FROM Orders;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int value))
                        {
                            nextOrderID = value;
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetNextOrderID));
                    }
                }
            }

            return nextOrderID;
        }
        public static int GetLastOrderID()
        {

            int LastOrderID = 1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"Select Top 1 Orders.OrderID from Orders
                                    Order by Orders.OrderID Desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int value))
                        {
                            LastOrderID = value;
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(LastOrderID));
                    }
                }
            }

            return LastOrderID;

        }
        public static DataTable GetAllOrders()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT Orders.OrderID,
                                 Customers.FirstName + ' ' + Customers.LastName AS CustomerName,
                                 Orders.Description,
                                 Customers.Phone,
                                 Orders.CreatedDate,
                                 COUNT(OrderDetails.ProductID) AS ProductCount,
                                 Users.UserName
                                 FROM Orders

                                 INNER JOIN Users
                                 ON Orders.CreatedByUserID = Users.UserID

                                 INNER JOIN Customers
                                 ON Orders.CustomerID = Customers.CustomerID

                                 INNER JOIN OrderDetails
                                 ON Orders.OrderID = OrderDetails.OrderID

                                 GROUP BY 
                                 Orders.OrderID,
                                 Customers.FirstName + ' ' + Customers.LastName,
                                 Orders.Description,
                                 Customers.Phone,
                                 Orders.CreatedDate,
                                 Users.UserName
                                 ORDER BY Orders.OrderID DESC;";


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

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(GetAllOrders));
                    }
                }
            }

            return dt;

        }

    }
}
