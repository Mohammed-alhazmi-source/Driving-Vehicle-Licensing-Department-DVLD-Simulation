using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsUserData
    {
        public static int AddNewUser(int PersonID,string UserName, string Password, bool IsActive)
        {
            int UserID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"INSERT INTO Users(PersonID,UserName,Password,IsActive)
                                VALUES(@PersonID,@UserName,@Password,@IsActive);
                                SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            UserID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        UserID = -1;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return UserID;
        }

        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "DELETE FROM Users WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(Query, connection)) 
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    UPDATE Users
                                    SET UserName = @UserName,
                                        PersonID = @PersonID,
                                        Password = @Password,
                                        IsActive = @IsActive
                                    WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFind = false;

            using(SqlConnection connection  = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Users WHERE UserID = @UserID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;

                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool GetUserInfoByUsernameAndPassword(ref int UserID, ref int PersonID, string UserName, string Password, ref bool IsActive)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM Users 
                                WHERE UserName = @UserName AND Password = @Password;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool GetUserInfoByPersonID(ref int UserID, int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Users WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;

                                UserID = (int)reader["UserID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsExist = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT Found = 1 FROM Users WHERE UserID = @UserID AND IsActive = @IsActive;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@IsActive", true);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int Value))
                            IsExist = true;
                    }
                    catch (SqlException sqlex)
                    {
                        IsExist = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }
            return IsExist;
        }

        public static bool IsUserExist(string UserName)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT Found = 1 FROM Users WHERE UserName = @UserName;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();


                        object Result = command.ExecuteScalar();

                        if(Result != null && int.TryParse(Result.ToString(), out int Value))
                            IsExist = true;
                    }
                    catch (SqlException sqlex)
                    {
                        IsExist = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }
            return IsExist;
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int Value))
                            IsExist = true;
                    }
                    catch (SqlException sqlex)
                    {
                        IsExist = false;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }
            return IsExist;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE Users
                                 SET Password = @NewPassword
                                     WHERE UserID = @UserID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllUsers()
        {
            DataTable dtAllUsers = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM MasterUsers_View ORDER BY UserID ASC;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllUsers.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllUsers = null;
                        clsEventLogHandler.LogException("Users", sqlex.Message);
                    }
                }
            }

            return dtAllUsers;
        }
    }
}