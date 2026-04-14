using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(
                                      int PersonID, ref string nationalNo, ref string firstName, 
                                      ref string secondName, ref string thirdName, ref string lastName,
                                      ref DateTime dateOfBirth, ref byte gender, ref string address,
                                      ref string phone, ref string email, ref int nationalityCountryID, 
                                      ref string imagePath
                                    )
        {

            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM People WHERE PersonID = @PersonID;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {                        
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                nationalNo = (string)reader["NationalNo"];
                                firstName = (string)reader["FirstName"];
                                secondName = (string)reader["SecondName"];

                                if (reader["ThirdName"] == DBNull.Value) thirdName = "";
                                else thirdName = (string)reader["ThirdName"];

                                lastName = (string)reader["LastName"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                gender = (byte)reader["Gendor"];
                                address = (string)reader["Address"];
                                phone = (string)reader["Phone"];

                                if (reader["Email"] == DBNull.Value) email = "";
                                else email = (string)reader["Email"];

                                nationalityCountryID = (int)reader["NationalityCountryID"];

                                if (reader["ImagePath"] == DBNull.Value) imagePath = "";
                                else imagePath = (string)reader["ImagePath"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }


        public static bool GetPersonInfoByNationalNo(
                              string nationalNo, ref int PersonID, ref string firstName,
                              ref string secondName, ref string thirdName, ref string lastName,
                              ref DateTime dateOfBirth, ref byte gender, ref string address,
                              ref string phone, ref string email, ref int nationalityCountryID,
                              ref string imagePath
                            )
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM People WHERE NationalNo = @NationalNo;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                PersonID = (int)reader["PersonID"];
                                firstName = (string)reader["FirstName"];
                                secondName = (string)reader["SecondName"];

                                if (reader["ThirdName"] == DBNull.Value) thirdName = "";
                                else thirdName = (string)reader["ThirdName"];

                                lastName = (string)reader["LastName"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                gender = (byte)reader["Gendor"];
                                address = (string)reader["Address"];
                                phone = (string)reader["Phone"];

                                if (reader["Email"] == DBNull.Value) email = "";
                                else email = (string)reader["Email"];

                                nationalityCountryID = (int)reader["NationalityCountryID"];

                                if (reader["ImagePath"] == DBNull.Value) imagePath = "";
                                else imagePath = (string)reader["ImagePath"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool IsPersonPhoneExist(string Phone)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT 1 FROM People WHERE Phone = @Phone";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", Phone);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();

                        return (Result != null);
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static bool IsPersonEmailExist(string Email)
        {
            object Result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT 1 FROM People WHERE Email = @Email;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static int AddNewPerson
                                       (
                                         string NationalNo,
                                         string FirstName, string SecondName, string ThirdName, string LastName,
                                         DateTime DateOfBirth, int Gendor,
                                         string Address, string Phone, string Email,
                                         int NationalityCountryID, string ImagePath
                                       )
        {
            SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString);

            SqlCommand command = new SqlCommand();

            command.CommandText = @"
                                    INSERT INTO People
                                               (NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                DateOfBirth ,Gendor, Address, Phone, Email,
                                                NationalityCountryID, ImagePath)
                                         VALUES
                                               (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,
                                    		    @DateOfBirth,@Gendor,@Address, @Phone, @Email,
                                    			@NationalityCountryID, @ImagePath);
                                    SELECT SCOPE_IDENTITY();";

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrWhiteSpace(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrWhiteSpace(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            command.Connection = connection;

            object Result;
            int PersonID = -1;

            try
            {
                connection.Open();

                Result = command.ExecuteScalar();

                if (int.TryParse(Result.ToString(), out int InsertedID))
                    PersonID = InsertedID;
            }
            catch (SqlException sqlex)
            {
                PersonID = -1;
                clsEventLogHandler.LogException("DAL - People", sqlex.Message);
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson
                                (
                                  int PersonID, string NationalNo, string FirstName, string SecondName, 
                                  string ThirdName, string LastName, DateTime DateOfBirth, int Gendor,
                                  string Address, string Phone, string Email,
                                  int NationalityCountryID, string ImagePath
                                )

        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    UPDATE People
                                       SET NationalNo = @NationalNo, FirstName = @FirstName,
                                           SecondName = @SecondName, ThirdName = @ThirdName,
                                           LastName = @LastName, DateOfBirth = @DateOfBirth,
                                           Gendor = @Gendor, Address = @Address,
                                           Phone = @Phone, Email = @Email,
                                           NationalityCountryID = @NationalityCountryID,
                                           ImagePath = @ImagePath WHERE PersonID = @PersonID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (string.IsNullOrWhiteSpace(Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (string.IsNullOrWhiteSpace(ImagePath))
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }              
            }

            return (RowsAffected > 0);
        }



        public static bool IsPersonExist(int PersonID)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM People WHERE PersonID = @PersonID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            object Result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM People WHERE NationalNo = @NationalNo;";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
         
            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "DELETE FROM People WHERE PersonID = @PersonID;";
                
                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - People", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString);

            SqlCommand command = new SqlCommand();

            command.CommandText = @"SELECT * FROM MasterPeople_View ORDER BY FirstName;";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtPeople.Load(reader);

                reader.Close();
            }
            catch (SqlException sqlex)
            {
                dtPeople = null;
                clsEventLogHandler.LogException("DAL - People", sqlex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtPeople;
        }
    }
}