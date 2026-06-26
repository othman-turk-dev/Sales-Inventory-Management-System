using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public static class ClsCustomerData
    {

        public static int? AddNewCustomers(string FirstName, string LastName,
            string Address, string Phone, string Email = null)
        {

            int? CustomerID = null;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Customers 
                                (FirstName, LastName, Address, Phone, Email)
                                VALUES 
                                (@FirstName, @LastName, @Address, @Phone, @Email);

                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    command.Parameters.AddWithValue("@Email", Email ?? (object)System.DBNull.Value);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CustomerID = insertedID;
                        }

                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(AddNewCustomers));
                    }

                }
                return CustomerID;

            }


        }

        public static bool GetCustomersByCustomerID(int? CustomerID, ref string FirstName,
            ref string LastName, ref string Address, ref string Phone, ref string Email)
        {
            
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];

                                Email = reader["Email"] as string;

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(GetCustomersByCustomerID));
                    }

                }
            }

            return isFound;
        
        }

        public static bool UpdateCustomers(int? CustomerID, string FirstName,
            string LastName, string Address, string Phone, string Email = null)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Customers 
                                 SET
                                 FirstName = @FirstName,
                                 LastName = @LastName,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email
                                 WHERE 
                                 CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    command.Parameters.AddWithValue("@Email", Email ?? (object)System.DBNull.Value);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ClsErrorLogData.AddNewErrorLog(ex.ToString(), nameof(UpdateCustomers));
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllCustomers()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * From Customers";


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
                        
                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(GetAllCustomers));
                    }
                }
            }

            return dt;

        }
        public static bool DeleteCustomers(int? CustomerID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"DELETE FROM Customers 
                                 WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    try
                    {

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ClsErrorLogData.AddNewErrorLog(ex.ToString(),nameof(DeleteCustomers));
                    }
                }
            }

           return rowsAffected > 0;
            
        }

    }
}
