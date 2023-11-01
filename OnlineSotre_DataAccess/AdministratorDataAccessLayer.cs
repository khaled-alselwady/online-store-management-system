using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccessLayer_
{
    public class clsAdministratorDataAccessLayer
    {
        public static bool GetAdministratorInfoByAdministratorID(int AdministratorID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Administrators WHERE AdministratorID = @AdministratorID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorID", AdministratorID);

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

                reader.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return IsFound;

        }

        public static int GetAdministratorIDByPersonID(int PersonID)
        {
            int AdministratorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT AdministratorID FROM Administrators WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    AdministratorID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return AdministratorID;
        }

        public static int GetPersonIDByAdministratorID(int AdministratorID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID FROM Administrators WHERE AdministratorID = @AdministratorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorID", AdministratorID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PersonID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static int AddNewAdministrator(int PersonID)
        {
            int AdministratorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Administrators (PersonID)
                             VALUES (@PersonID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command  = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int ID))
                {
                    AdministratorID = ID;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AdministratorID;

        }

        public static bool DeleteAdministrator(int AdministratorID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Administrators WHERE AdministratorID = @AdministratorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorID", AdministratorID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool IsAdministratorExistsByID(int AdministratorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Administrators WHERE AdministratorID = @AdministratorID";
             
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorID", AdministratorID);

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

        public static DataView GetAllAdministrators()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Administrators.AdministratorID, Persons.Name,
                             Persons.Email, Persons.Address, Persons.Username, Persons.Password
                             FROM Administrators
                             INNER JOIN Persons
                             ON Administrators.PersonID = Persons.PersonID;";

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

        public static DataView SearchAdministratorsContainsByAdministratorID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Administrators.AdministratorID, Persons.Name,
                                    Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Administrators
                                    INNER JOIN Persons
                                    ON Administrators.PersonID = Persons.PersonID
                                    WHERE (Administrators.AdministratorID) LIKE '%' + @Contains + '%'
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

        public static DataView SearchAdministratorsContainsByName(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Administrators.AdministratorID, Persons.Name,
                                    Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Administrators
                                    INNER JOIN Persons
                                    ON Administrators.PersonID = Persons.PersonID
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

        public static DataView SearchAdministratorsContainsByUsername(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    SELECT Administrators.AdministratorID, Persons.Name,
                                    Persons.Email, Persons.Address, Persons.Username, Persons.Password
                                    FROM Administrators
                                    INNER JOIN Persons
                                    ON Administrators.PersonID = Persons.PersonID
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
