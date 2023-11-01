using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineStore_DataAccessLayer_
{
    public class clsProductImagesDataAccessLayer
    {

        public static bool GetProductImagesInfoByImageID(int ImageID,
            ref string ImageURL, ref short ImageOrder, ref int ProductID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ProductImages WHERE ID = @ImageID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImageID", ImageID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ImageURL = (string)reader["ImageURL"];
                    ImageOrder = (short)reader["ImageOrder"];
                    ProductID = (int)reader["ProductID"];
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

        public static int AddNewProductImage(string ImageURL, short ImageOrder, int ProductID)
        {
            int ImageID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Use `Case` in query to check if ImageOrder >= 0 or not
            string query = @"INSERT INTO ProductImages (ImageURL, ImageOrder, ProductID)
                             VALUES (@ImageURL, 
                             CASE WHEN @ImageOrder >= 0 THEN @ImageOrder ELSE 0 END, 
                             @ProductID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImageURL", ImageURL);
            command.Parameters.AddWithValue("@ImageOrder", ImageOrder);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ImageID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ImageID;
        }

        public static bool UpdateNewProductImage(int ImageID, string ImageURL, short ImageOrder, int ProductID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ProductImages
                             SET   ImageURL = @ImageURL,
                                   ImageOrder = @ImageOrder,
                                   ProductID = @ProductID
                             WHERE ID = @ImageID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImageURL", ImageURL);
            command.Parameters.AddWithValue("@ImageOrder", ImageOrder);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            command.Parameters.AddWithValue("@ImageID", ImageID);

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

        public static bool DeleteProductImage(int ImageID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM ProductImages WHERE ID = @ImageID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImageID", ImageID);

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

        public static bool IsImageExists(int ImageID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM ProductImages WHERE ID = @ImageID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImageID", ImageID);

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

        public static DataView GetAllImagesOfSpecificProduct(int ProductID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ProductImages WHERE ProductID = @ProductID ORDER BY ImageOrder;";

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
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;
        }

        public static DataView GetAllImages()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ProductImages";

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
