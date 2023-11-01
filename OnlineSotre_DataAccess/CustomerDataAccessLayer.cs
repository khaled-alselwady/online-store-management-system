using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsCustomerDataAccessLayer
    {

        public static bool FindCustomerByCustomerID(int CustomerID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
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

        public static int GetCustomerIDByPersonID(int PersonID)
        {
            int CustomerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CustomerID FROM Customers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int customerID))
                {
                    CustomerID = customerID;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return CustomerID;

        }

        public static int GetPersonIDByCustomerID(int CustomerID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int personID))
                {
                    PersonID = personID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;

        }

        public static int AddNewCustomer(int PersonID)
        {
            int CustomerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Customers (PersonID)
                             VALUES (@PersonID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int customerID))
                {
                    CustomerID = customerID;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }

            return CustomerID;
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            int RowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                connection.Open();

                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);

        }

        public static bool IsCustomerExistsByID(int CustomerID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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

        public static DataTable GetAllCustomers()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Customers.CustomerID, Persons.Name, Persons.Email, Persons.Address, Persons.Username, Persons.Password
                             FROM Customers
                             INNER JOIN Persons
                             ON Customers.PersonID = Persons.PersonID;";

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

            return dt;
        }

        public static DataView SearchCustomersContainsByCustomerID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Customers.CustomerID, Persons.Name, Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Customers
                                    INNER JOIN Persons
                                    ON Customers.PersonID = Persons.PersonID
                                    WHERE (Customers.CustomerID) LIKE '%' + @Contains + '%'
                                  ) AS subQuery;";


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

        public static DataView SearchCustomersContainsByName(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Customers.CustomerID, Persons.Name, Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Customers
                                    INNER JOIN Persons
                                    ON Customers.PersonID = Persons.PersonID
                                    WHERE (Persons.Name) LIKE '%' + @Contains + '%'
                                  ) AS subQuery;";


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

        public static DataView SearchCustomersContainsByUsername(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Customers.CustomerID, Persons.Name, Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Customers
                                    INNER JOIN Persons
                                    ON Customers.PersonID = Persons.PersonID
                                    WHERE (Persons.Username) LIKE '%' + @Contains + '%'
                                  ) AS subQuery;";


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
