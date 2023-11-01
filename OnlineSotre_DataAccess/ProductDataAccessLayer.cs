using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsProductDataAccessLayer
    {
        public static bool GetProductInfoByID(int ProductID,
            ref string ProductName, ref string Description,
            ref decimal Price, ref int QuantityInStock, ref int CategoryID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ProductCatalog WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ProductName = (string)reader["ProductName"];
                    Description = (string)reader["Description"];
                    Price = (decimal)reader["Price"];
                    QuantityInStock = (int)reader["QuantityInStock"];
                    CategoryID = (int)reader["CategoryID"];
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


        public static bool GetProductInfoByName(string ProductName,
            ref int ProductID, ref string Description, ref decimal Price,
             ref int QuantityInStock, ref int CategoryID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ProductCatalog WHERE ProductName = @ProductName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", ProductName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ProductID = (int)reader["ProductID"];
                    Description = (string)reader["Description"];
                    Price = (decimal)reader["Price"];
                    QuantityInStock = (int)reader["QuantityInStock"];
                    CategoryID = (int)reader["CategoryID"];
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



        public static int AddNewProduct(string ProductName, string Description,
             decimal Price, int QuantityInStock, int CategoryID)
        {
            int ProductID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT Top 1 Found = 1 FROM ProductCatalog WHERE ProductName = @ProductName)
                             BEGIN
                                    INSERT INTO ProductCatalog (ProductName, Description, Price, QuantityInStock, CategoryID)
                                    VALUES (@ProductName, @Description, @Price, @QuantityInStock, @CategoryID);
                                    SELECT SCOPE_IDENTITY();
                             END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ProductID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ProductID;
        }

        public static bool UpdateProduct(int ProductID, string ProductName, string Description,
             decimal Price, int QuantityInStock, int CategoryID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ProductCatalog
                             SET   ProductName = @ProductName,
                                   Description = @Description,
                                   Price = @Price,
                                   QuantityInStock = @QuantityInStock,
                                   CategoryID = @CategoryID
                             WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

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


        public static bool DeleteProduct(int ProductID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT TOP 1 Found = 1 FROM Reviews WHERE Reviews.ProductID = @ProductID)
                             BEGIN
                             		IF NOT EXISTS (SELECT TOP 1 Found = 1 FROM OrderItems WHERE OrderItems.ProductID = @ProductID)
                             		BEGIN
                             			
                             			    DELETE FROM ProductImages WHERE ProductImages.ProductID = @ProductID;
                             			    DELETE FROM ProductCatalog WHERE ProductCatalog.ProductID = @ProductID;
                                            
                             			
                             		END;
                             END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static bool IsProductExists(int ProductID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 Found = 1 FROM ProductCatalog WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", ProductID);

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
        public static bool IsProductExists(string ProductName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 Found = 1 FROM ProductCatalog WHERE ProductName = @ProductName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", ProductName);

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

        public static DataView GetAllProducts()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                             ProductCatalog.Description, ProductCatalog.Price,
                             ProductCatalog.QuantityInStock, ProductCategory.CategoryName
                             FROM ProductCatalog
                             INNER JOIN ProductCategory
                             ON ProductCatalog.CategoryID = ProductCategory.CategoryID;";

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

        public static DataView GetAllProductsWithoutQuantity()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                             ProductCatalog.Description, ProductCatalog.Price,
                             ProductCategory.CategoryName, 
                             CASE
                                    WHEN ProductCatalog.QuantityInStock > 0 THEN 'Available'
                                    WHEN ProductCatalog.QuantityInStock <= 0 THEN 'Unavailable'
                                    ELSE 'Unknown'
                             END AS Availability
                             FROM ProductCatalog
                             INNER JOIN ProductCategory
                             ON ProductCatalog.CategoryID = ProductCategory.CategoryID;";

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

        public static DataView GetAllProductsWithSpecificCategory(string CategoryName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                             ProductCatalog.Description, ProductCatalog.Price,
                             ProductCatalog.QuantityInStock, ProductCategory.CategoryName
                             FROM ProductCatalog
                             INNER JOIN ProductCategory
                             ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                             WHERE ProductCategory.CategoryName = @CategoryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView GetAllProductsWithSpecificCategoryWithoutQuantity(string CategoryName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                             ProductCatalog.Description, ProductCatalog.Price,
                             ProductCategory.CategoryName, 
                             CASE
                                    WHEN ProductCatalog.QuantityInStock > 0 THEN 'Available'
                                    WHEN ProductCatalog.QuantityInStock <= 0 THEN 'Unavailable'
                                    ELSE 'Unknown'
                             END AS Availability
                             FROM ProductCatalog
                             INNER JOIN ProductCategory
                             ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                             WHERE ProductCategory.CategoryName = @CategoryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductID(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                 ProductCatalog.Description, ProductCatalog.Price,
                                 ProductCatalog.QuantityInStock, ProductCategory.CategoryName
                                 FROM ProductCatalog
                                 INNER JOIN ProductCategory
                                 ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                 WHERE (ProductCatalog.ProductID) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductName(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                 ProductCatalog.Description, ProductCatalog.Price,
                                 ProductCatalog.QuantityInStock, ProductCategory.CategoryName
                                 FROM ProductCatalog
                                 INNER JOIN ProductCategory
                                 ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                 WHERE (ProductCatalog.ProductName) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductCategory(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                 ProductCatalog.Description, ProductCatalog.Price,
                                 ProductCatalog.QuantityInStock, ProductCategory.CategoryName
                                 FROM ProductCatalog
                                 INNER JOIN ProductCategory
                                 ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                 WHERE (ProductCategory.CategoryName) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductIDWithoutQuantity(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                  SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                  ProductCatalog.Description, ProductCatalog.Price,
                                  ProductCategory.CategoryName, 
                                  CASE
                                         WHEN ProductCatalog.QuantityInStock > 0 THEN 'Available'
                                         WHEN ProductCatalog.QuantityInStock <= 0 THEN 'Unavailable'
                                         ELSE 'Unknown'
                                  END AS Availability
                                  FROM ProductCatalog
                                  INNER JOIN ProductCategory
                                  ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                  WHERE (ProductCatalog.ProductID) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductNameWithoutQuantity(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                  SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                  ProductCatalog.Description, ProductCatalog.Price,
                                  ProductCategory.CategoryName, 
                                  CASE
                                         WHEN ProductCatalog.QuantityInStock > 0 THEN 'Available'
                                         WHEN ProductCatalog.QuantityInStock <= 0 THEN 'Unavailable'
                                         ELSE 'Unknown'
                                  END AS Availability
                                  FROM ProductCatalog
                                  INNER JOIN ProductCategory
                                  ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                  WHERE (ProductCatalog.ProductName) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        public static DataView SearchProductsContainsByProductCategoryWithoutQuantity(string Contains, string CategoryName)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                  SELECT ProductCatalog.ProductID, ProductCatalog.ProductName,
                                  ProductCatalog.Description, ProductCatalog.Price,
                                  ProductCategory.CategoryName, 
                                  CASE
                                         WHEN ProductCatalog.QuantityInStock > 0 THEN 'Available'
                                         WHEN ProductCatalog.QuantityInStock <= 0 THEN 'Unavailable'
                                         ELSE 'Unknown'
                                  END AS Availability
                                  FROM ProductCatalog
                                  INNER JOIN ProductCategory
                                  ON ProductCatalog.CategoryID = ProductCategory.CategoryID
                                  WHERE (ProductCategory.CategoryName) LIKE '%' + @Contains + '%' AND (ProductCategory.CategoryName = @CategoryName OR @CategoryName = 'All')
                             ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);

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
