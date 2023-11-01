using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsOrderItemsDataAccessLayer
    {

        public static bool GetOrderItemsInfoByOrderItemID(int OrderItemID,
            ref int OrderID, ref int ProductID, ref int Quantity,
            ref decimal PricePerItem, ref decimal TotalItemsPrice)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM OrderItems WHERE OrderItemID = @OrderItemID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderItemID", OrderItemID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    OrderID = (int)reader["OrderID"];
                    ProductID = (int)reader["ProductID"];
                    Quantity = (int)reader["Quantity"];
                    PricePerItem = (decimal)reader["PricePerItem"];
                    TotalItemsPrice = (decimal)reader["TotalItemsPrice"];
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetOrderItemsInfoByOrderIDAndProductID(int OrderID, int ProductID,
            ref int OrderItemID, ref int Quantity,
            ref decimal PricePerItem, ref decimal TotalItemsPrice)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM OrderItems WHERE OrderID = @OrderID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    OrderItemID = (int)reader["OrderItemID"];                  
                    Quantity = (int)reader["Quantity"];
                    PricePerItem = (decimal)reader["PricePerItem"];
                    TotalItemsPrice = (decimal)reader["TotalItemsPrice"];
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static DataView GetAllOrderItemsInfoByOrderID(int OrderID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT OrderItems.OrderItemID, OrderItems.OrderID,
                             ProductCatalog.ProductName,OrderItems.Quantity,
                             OrderItems.PricePerItem,OrderItems.TotalItemsPrice
                             FROM OrderItems
                             INNER JOIN ProductCatalog
                             ON OrderItems.ProductID = ProductCatalog.ProductID
                             WHERE OrderID = @OrderID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;
        }


        public static int AddNewOrderItem(int OrderID, int ProductID, int Quantity,
             decimal PricePerItem, decimal TotalItemsPrice)
        {
            int OrderItemID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, PricePerItem, TotalItemsPrice)
                             VALUES (@OrderID, @ProductID, @Quantity, @PricePerItem, @TotalItemsPrice);
                             SELECT SCOPE_IDENTITY();
                             
                             UPDATE ProductCatalog 
                             SET QuantityInStock = QuantityInStock - @Quantity
                             WHERE ProductCatalog.ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@PricePerItem", PricePerItem);
            command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    OrderItemID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return OrderItemID;
        }

        public static bool UpdateOrderItem(int OrderItemID, int OrderID, int ProductID,
             int Quantity, decimal PricePerItem, decimal TotalItemsPrice)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DECLARE @DifferentQuantity INT;
                             SELECT @DifferentQuantity = @Quantity - OrderItems.Quantity FROM OrderItems
                             WHERE OrderItemID = @OrderItemID;
                             
                             UPDATE OrderItems
                             SET    OrderID         = @OrderID,
                                    ProductID       = @ProductID,
                                    Quantity        = @Quantity,
                                    PricePerItem    = @PricePerItem,
                                    TotalItemsPrice = @TotalItemsPrice
                             WHERE  OrderItemID     = @OrderItemID;
                             
                             
                             UPDATE ProductCatalog
                             SET QuantityInStock = QuantityInStock - @DifferentQuantity
                             WHERE ProductCatalog.ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@PricePerItem", PricePerItem);
            command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);
            command.Parameters.AddWithValue("@OrderItemID", OrderItemID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteOrderItem(int OrderItemID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM OrderItems WHERE OrderItemID = @OrderItemID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderItemID", OrderItemID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);


        }

        public static bool IsOrderItemExistsByOrderItemID(int OrderItemID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM OrderItems WHERE OrderItemID = @OrderItemID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderItemID", OrderItemID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsOrderItemExistsByOrderID(int OrderID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM OrderItems WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataView GetAllOrderItems()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT OrderItems.OrderItemID, OrderItems.OrderID, ProductCatalog.ProductName,OrderItems.Quantity,OrderItems.PricePerItem,OrderItems.TotalItemsPrice
                             FROM OrderItems
                             INNER JOIN ProductCatalog
                             ON OrderItems.ProductID = ProductCatalog.ProductID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;

        }
    }
}
