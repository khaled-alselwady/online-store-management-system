using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsShippingDataAccessLayer
    {
        public static bool GetShippingInfoByShippingID(int ShippingID, ref int OrderID,
            ref string CarrierName, ref string TrackingNumber, ref string ShippingStatus,
            ref DateTime EstimatedDeliveryDate, ref DateTime ActualDeliveryDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE ShippingID = @ShippingID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ShippingID", ShippingID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    OrderID = (int)reader["OrderID"];
                    CarrierName = (string)reader["CarrierName"];
                    TrackingNumber = (string)reader["TrackingNumber"];
                    ShippingStatus = (string)reader["ShippingStatus"];
                    EstimatedDeliveryDate = (DateTime)reader["EstimatedDeliveryDate"];

                    if (reader["ActualDeliveryDate"] != System.DBNull.Value)
                    {
                        ActualDeliveryDate = (DateTime)reader["ActualDeliveryDate"];
                    }
                    else
                    {
                        ActualDeliveryDate = new DateTime();
                    }

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


        public static bool GetShippingInfoByTrackingNumber(string TrackingNumber, ref int ShippingID,
                       ref int OrderID, ref string CarrierName, ref string ShippingStatus,
                      ref DateTime EstimatedDeliveryDate, ref DateTime ActualDeliveryDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE TrackingNumber = @TrackingNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrackingNumber", TrackingNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ShippingID = (int)reader["ShippingID"];
                    OrderID = (int)reader["OrderID"];
                    CarrierName = (string)reader["CarrierName"];
                    ShippingStatus = (string)reader["ShippingStatus"];
                    EstimatedDeliveryDate = (DateTime)reader["EstimatedDeliveryDate"];

                    if (reader["ActualDeliveryDate"] != System.DBNull.Value)
                    {
                        ActualDeliveryDate = (DateTime)reader["ActualDeliveryDate"];
                    }
                    else
                    {
                        ActualDeliveryDate = new DateTime();
                    }

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


        public static int AddNewShipping(int OrderID, string CarrierName, string TrackingNumber,
                string ShippingStatus, DateTime EstimatedDeliveryDate, DateTime ActualDeliveryDate)
        {
            int ShippingID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" IF NOT EXISTS (SELECT TOP 1 Found = 1 FROM Shippings WHERE TrackingNumber = @TrackingNumber)
                              BEGIN
                                     INSERT INTO Shippings (OrderID, CarrierName, TrackingNumber, ShippingStatus, EstimatedDeliveryDate, ActualDeliveryDate)
                                     VALUES (@OrderID, @CarrierName, @TrackingNumber, @ShippingStatus, @EstimatedDeliveryDate, @ActualDeliveryDate);
                                     SELECT SCOPE_IDENTITY();
                              END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@CarrierName", CarrierName);
            command.Parameters.AddWithValue("@TrackingNumber", TrackingNumber);
            command.Parameters.AddWithValue("@ShippingStatus", ShippingStatus);
            command.Parameters.AddWithValue("@EstimatedDeliveryDate", EstimatedDeliveryDate);

            if (ActualDeliveryDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ActualDeliveryDate", ActualDeliveryDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualDeliveryDate", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ShippingID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ShippingID;
        }

        public static bool UpdateShipping(int ShippingID, int OrderID,
             string CarrierName, string TrackingNumber, string ShippingStatus,
            DateTime EstimatedDeliveryDate, DateTime ActualDeliveryDate)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Shippings
                             SET    OrderID               = @OrderID,
                                    CarrierName           = @CarrierName,
                                    TrackingNumber        = @TrackingNumber,
                                    ShippingStatus        = @ShippingStatus,
                                    EstimatedDeliveryDate = @EstimatedDeliveryDate,
                                    ActualDeliveryDate    = @ActualDeliveryDate
                             WHERE  ShippingID            = @ShippingID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@CarrierName", CarrierName);
            command.Parameters.AddWithValue("@TrackingNumber", TrackingNumber);
            command.Parameters.AddWithValue("@ShippingStatus", ShippingStatus);
            command.Parameters.AddWithValue("@EstimatedDeliveryDate", EstimatedDeliveryDate);
            command.Parameters.AddWithValue("@ShippingID", ShippingID);

            if (ActualDeliveryDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ActualDeliveryDate", ActualDeliveryDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualDeliveryDate", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool DeleteShipping(int ShippingID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Shippings WHERE ShippingID = @ShippingID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ShippingID", ShippingID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool IsShippingExists(int ShippingID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM Shippings WHERE ShippingID = @ShippingID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ShippingID", ShippingID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch(Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsShippingExists(string TrackingNumber)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM Shippings WHERE TrackingNumber = @TrackingNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrackingNumber", TrackingNumber);

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

        public static DataView GetAllShippings()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings";

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
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;
        }

        public static DataView GetAllShippingStatus()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DISTINCT Shippings.ShippingStatus FROM Shippings;";

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

        public static DataView GetAllShippingsFromSpecificCompany(string CarrierName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE CarrierName = @CarrierName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarrierName", CarrierName);

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

        public static DataView GetAllShippingsOfSpecificCustomer(int CustomerID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Shippings.* FROM Shippings
                             INNER JOIN Orders ON Orders.OrderID = Shippings.OrderID
                             WHERE Orders.CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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

        public static DataView SearchShippingContainsByShippingID(string Contains)
        {
            
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE ShippingID LIKE '%' + @Contains + '%'";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

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

        public static DataView SearchShippingContainsByOrderID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE OrderID LIKE '%' + @Contains + '%'";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

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

        public static DataView SearchShippingContainsByTrackingNumber(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE TrackingNumber LIKE @Contains + '%'";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

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

        public static DataView SearchShippingContainsByShippingStatus(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Shippings WHERE ShippingStatus LIKE '%' + @Contains + '%'";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

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

        public static DataView SearchShippingContainsByShippingIDOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Shippings.* FROM Shippings
                             INNER JOIN Orders ON Orders.OrderID = Shippings.OrderID
                             WHERE Orders.CustomerID = @CustomerID 
                             AND   ShippingID LIKE @Contains + '%'
                             AND   (@ShippingStatus = 'All' OR ShippingStatus = @ShippingStatus)";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@ShippingStatus", ShippingStatus);

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

        public static DataView SearchShippingContainsByOrderIDOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Shippings.* FROM Shippings
                             INNER JOIN Orders ON Orders.OrderID = Shippings.OrderID
                             WHERE Orders.CustomerID = @CustomerID 
                             AND   Shippings.OrderID LIKE @Contains + '%'
                             AND   (@ShippingStatus = 'All' OR ShippingStatus = @ShippingStatus)";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@ShippingStatus", ShippingStatus);

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

        public static DataView SearchShippingContainsByTrackingNumberOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Shippings.* FROM Shippings
                             INNER JOIN Orders ON Orders.OrderID = Shippings.OrderID
                             WHERE Orders.CustomerID = @CustomerID 
                             AND   TrackingNumber LIKE @Contains + '%'
                             AND   (@ShippingStatus = 'All' OR ShippingStatus = @ShippingStatus)";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@ShippingStatus", ShippingStatus);

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

        public static DataView SearchShippingContainsByShippingStatusOfSpecificCustomer(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Shippings.* FROM Shippings
                             INNER JOIN Orders ON Orders.OrderID = Shippings.OrderID
                             WHERE Orders.CustomerID = @CustomerID 
                             AND   ShippingStatus LIKE '%' + @Contains + '%'";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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

        public static DataView GetAllOderIDThatDoNotHaveAShippng()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT OrderID FROM Orders
                             WHERE OrderID NOT IN (SELECT OrderID FROM Shippings)";

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
