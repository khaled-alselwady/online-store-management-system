using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsReviewDataAccessLayer
    {
        public static bool GetReviewInfoByReviewID(int ReviewID,
            ref int ProductID, ref int CustomerID, ref string ReviewText,
             ref decimal Rating, ref DateTime ReviewDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews WHERE ReviewID = @ReviewID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReviewID", ReviewID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ProductID = (int)reader["ProductID"];
                    CustomerID = (int)reader["CustomerID"];
                    Rating = (decimal)reader["Rating"];
                    ReviewDate = (DateTime)reader["ReviewDate"];

                    if (reader["ReviewText"] != System.DBNull.Value)
                    {
                        ReviewText = (string)reader["ReviewText"];
                    }
                    else
                    {
                        ReviewText = "";
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

        public static int AddNewReview(int ProductID, int CustomerID,
             string ReviewText, decimal Rating, DateTime ReviewDate)
        {
            int ReviewID = -1;

            //To make sure that the value of Rating satisfies the data type `decimal(2, 1)` in SQL 
            if (Rating >= 1.0M && Rating <= 5.0M)
            {

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"INSERT INTO Reviews (ProductID, CustomerID, ReviewText, Rating, ReviewDate)
                             VALUES (@ProductID, @CustomerID, @ReviewText, @Rating, @ReviewDate);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@Rating", Rating);
                command.Parameters.AddWithValue("@ReviewDate", ReviewDate);

                if (string.IsNullOrWhiteSpace(ReviewText))
                {
                    command.Parameters.AddWithValue("@ReviewText", System.DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@ReviewText", ReviewText);
                }


                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertID))
                    {
                        ReviewID = InsertID;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }

            }

            return ReviewID;

        }

        public static bool UpdateReview(int ReviewID, int ProductID, int CustomerID,
             string ReviewText, decimal Rating, DateTime ReviewDate)
        {
            int AffectedRows = 0;

            //To make sure that the new value of Rating satisfies the data type `decimal(2, 1)` in SQL 
            if (Rating >= 1.0M && Rating <= 5.0M)
            {

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"UPDATE Reviews
                             SET    ProductID  = @ProductID,
                                    CustomerID = @CustomerID,
                                    ReviewText = @ReviewText,
                                    Rating     = @Rating,
                                    ReviewDate = @ReviewDate
                             WHERE  ReviewID   = @ReviewID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@Rating", Rating);
                command.Parameters.AddWithValue("@ReviewDate", ReviewDate);
                command.Parameters.AddWithValue("@ReviewID", ReviewID);

                if (string.IsNullOrWhiteSpace(ReviewText))
                {
                    command.Parameters.AddWithValue("@ReviewText", System.DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@ReviewText", ReviewText);
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

            }
            return (AffectedRows > 0);
        }

        public static bool DeleteReview(int ReviewID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Reviews WHERE ReviewID = @ReviewID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReviewID", ReviewID);

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

        public static bool IsReviewExists(int ReviewID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM Reviews WHERE ReviewID = @ReviewID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReviewID", ReviewID);

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

        public static DataView GetAllReviewsOfSpecificCustomer(int CustomerID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reviews.ReviewID, ProductCatalog.ProductName, Reviews.ReviewText,
                             Reviews.Rating, Reviews.ReviewDate
                             FROM Reviews 
                             INNER JOIN ProductCatalog ON Reviews.ProductID = ProductCatalog.ProductID
                             WHERE Reviews.CustomerID = @CustomerID";

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

        public static DataView GetAllReviewsOfSpecificProduct(int ProductID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static DataView GetAllReviews()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews";

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

        public static DataView SearchReviewsContainsByReviewID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews WHERE ReviewID LIKE '%' + @Contains + '%'";


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

        public static DataView SearchReviewsContainsByProductID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews WHERE ProductID LIKE '%' + @Contains + '%'";


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

        public static DataView SearchReviewsContainsByRating(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reviews WHERE Rating LIKE '%' + @Contains + '%'";


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

        public static DataView SearchReviewsContainsByReviewIDWithoutCustomerIDColumn(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reviews.ReviewID, ProductCatalog.ProductName, Reviews.ReviewText,
                             Reviews.Rating, Reviews.ReviewDate
                             FROM Reviews 
                             INNER JOIN ProductCatalog ON Reviews.ProductID = ProductCatalog.ProductID
                             WHERE Reviews.CustomerID = @CustomerID
                             AND   ReviewID LIKE '%' + @Contains + '%'";


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

        public static DataView SearchReviewsContainsByProductNameWithoutCustomerIDColumn(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reviews.ReviewID, ProductCatalog.ProductName, Reviews.ReviewText,
                             Reviews.Rating, Reviews.ReviewDate
                             FROM Reviews 
                             INNER JOIN ProductCatalog ON Reviews.ProductID = ProductCatalog.ProductID
                             WHERE Reviews.CustomerID = @CustomerID
                             AND   ProductCatalog.ProductName LIKE '%' + @Contains + '%'";


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

        public static DataView SearchReviewsContainsByReviewDateWithoutCustomerIDColumn(string Contains, int CustomerID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reviews.ReviewID, ProductCatalog.ProductName, Reviews.ReviewText,
                             Reviews.Rating, Reviews.ReviewDate
                             FROM Reviews 
                             INNER JOIN ProductCatalog ON Reviews.ProductID = ProductCatalog.ProductID
                             WHERE Reviews.CustomerID = @CustomerID
                             AND   Reviews.ReviewDate LIKE '%' + @Contains + '%'";


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

    }
}
