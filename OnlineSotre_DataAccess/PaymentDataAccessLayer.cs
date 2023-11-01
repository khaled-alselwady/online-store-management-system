using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsPaymentDataAccessLayer
    {
        public static bool GetPaymentInfoByPaymentID(int PaymentID, ref int OrderID,
            ref decimal Amount, ref string PaymentMethod, ref DateTime TransactionDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    OrderID = (int)reader["OrderID"];
                    Amount = (decimal)reader["Amount"];
                    PaymentMethod = (string)reader["PaymentMethod"];
                    TransactionDate = (DateTime)reader["TransactionDate"];
                }
                else
                {
                    IsFound = false;
                }

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


        public static int AddNewPayment(int OrderID, decimal Amount,
               string PaymentMethod, DateTime TransactionDate)
        {
            int PaymentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Payments (OrderID, Amount, PaymentMethod, TransactionDate)
                             VALUES (@OrderID, @Amount, @PaymentMethod, @TransactionDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PaymentID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PaymentID;
        }


        public static bool UpdatePayment(int PaymentID, int OrderID, decimal Amount,
               string PaymentMethod, DateTime TransactionDate)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Payments
                             SET    OrderID         = @OrderID,
                                    Amount          = @Amount,
                                    PaymentMethod   = @PaymentMethod,
                                    TransactionDate = @TransactionDate
                             WHERE  PaymentID       = @PaymentID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                Connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool DeletePayment(int PaymentID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                Connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool IsPaymentExists(int PaymentID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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

        public static DataView GetAllPaymentsOfSpecificPaymentMethod(string PaymentMethod)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments WHERE PaymentMethod = @PaymentMethod";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);

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

        public static DataView GetAllPaymentsOfSpecificTransactionDate(DateTime TransactionDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments WHERE TransactionDate = @TransactionDate";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);

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

        public static DataView GetAllPaymentsOfSpecificCustomerID(int CustomerID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Payments.* from Payments
                             inner join Orders on Orders.OrderID = Payments.OrderID
                             where Orders.CustomerID = @CustomerID";

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

        public static DataView GetAllPayments()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments";

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

        public static DataView GetAllPaymentMethod()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select distinct Payments.PaymentMethod from Payments";

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

        public static DataView SearchPaymentContainsByPaymentID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments
                             WHERE (Payments.PaymentID) LIKE '%' + @Contains + '%'";



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

        public static DataView SearchPaymentContainsByOrderID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments
                             WHERE (Payments.OrderID) LIKE '%' + @Contains + '%'";



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

        public static DataView SearchPaymentContainsByPaymentIDOfSpecificCustomer(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Payments.* from Payments
                             inner join Orders on Orders.OrderID = Payments.OrderID
                             where Orders.CustomerID = @CustomerID
                             and   (Payments.PaymentID) LIKE @Contains + '%'";



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

        public static DataView SearchPaymentContainsByOrderIDOfSpecificCustomer(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Payments.* from Payments
                             inner join Orders on Orders.OrderID = Payments.OrderID
                             where Orders.CustomerID = @CustomerID
                             and   (Payments.OrderID) LIKE '%' + @Contains + '%'";



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

        public static DataView SearchPaymentContainsByPaymentMethod(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments
                             WHERE (Payments.PaymentMethod) LIKE '%' + @Contains + '%'";



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

        public static DataView SearchPaymentContainsByTransactionDate(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Payments
                             WHERE (Payments.TransactionDate) LIKE '%' + @Contains + '%'";



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

    }
}
