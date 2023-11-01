using System;
using System.Data.SqlClient;
using System.Data;

namespace OnlineStore_DataAccessLayer_
{
    public class clsPersonDataAccessLayer
    {
        public static bool GetPersonInfoByID(int PersonID, ref string Name, ref string Email,
            ref string Address, ref string Username, ref string Password)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    Name = (string)reader["Name"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
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

        public static bool GetPersonInfoByEmail(string Email, ref int PersonID, ref string Name,
            ref string Address, ref string Username, ref string Password)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
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

        public static bool GetPersonInfoByUsername(string Username, ref int PersonID,
            ref string Name, ref string Email, ref string Address, ref string Password)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    Email = (string)reader["Email"];
                    Password = (string)reader["Password"];
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

        public static bool GetPersonInfoByUsernameAndPassword(string Username, string Password,
            ref int PersonID, ref string Name, ref string Email, ref string Address)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons 
                             WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    Email = (string)reader["Email"];
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

        public static bool GetPersonInfoByEmailAndPassword(string Email, string Password,
            ref int PersonID, ref string Name, ref string Username, ref string Address)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons 
                             WHERE Email = @Email
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    Username = (string)reader["Username"];
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


        public static int AddNewPerson(string Name, string Email,
             string Address, string Username, string Password)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" IF NOT EXISTS (SELECT Found = 1 FROM Persons WHERE Email = @Email)
                              BEGIN
                                        
                                     IF NOT EXISTS (SELECT Found = 1 FROM Persons WHERE Username = @Username)
                                     BEGIN
                                             INSERT INTO Persons (Name, Email, Address, Username, Password)
                                             VALUES (@Name, @Email, @Address, @Username, @Password);
                                             SELECT SCOPE_IDENTITY()
                                     END;
                              
                              END;";

                             

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    PersonID = insertID;
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


        public static bool UpdatePerson(int PersonID, string Name, string Email,
             string Address, string Username, string Password)
        {
            int RowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Persons
                             SET   Name = @Name,
                                   Email = @Email,
                                   Address = @Address,
                                   Username = @Username,
                                   Password = @Password
                             WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool DeletePerson(int PersonID)
        {
            int RowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Phones WHERE PersonID = @PersonID;
                             DELETE FROM Persons WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExistsByID(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Persons WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static bool IsPersonExistsByEmail(string Email, string NameOfTable)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $@"SELECT Found = 1 FROM Persons
                             INNER JOIN {NameOfTable}
                             ON Persons.PersonID = {NameOfTable}.PersonID
                             WHERE Persons.Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

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
        public static bool IsPersonExistsByUsername(string Username, string NameOfTable)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $@"SELECT Found = 1 FROM Persons
                             INNER JOIN {NameOfTable}
                             ON Persons.PersonID = {NameOfTable}.PersonID
                             WHERE Persons.Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

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
        public static bool IsPersonExistsByEmailAndPassword(string Email, string Password, string NameOfTable)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $@"SELECT Found = 1 FROM Persons
                             INNER JOIN {NameOfTable}
                             ON Persons.PersonID = {NameOfTable}.PersonID
                             WHERE Email = @Email
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

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
        public static bool IsPersonExistsByUsernameAndPassword(string Username, string Password, string NameOfTable)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $@"SELECT Found = 1 FROM Persons
                             INNER JOIN {NameOfTable}
                             ON Persons.PersonID = {NameOfTable}.PersonID
                             WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

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

        public static DataTable GetAllPersons()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons";

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
    }
}
