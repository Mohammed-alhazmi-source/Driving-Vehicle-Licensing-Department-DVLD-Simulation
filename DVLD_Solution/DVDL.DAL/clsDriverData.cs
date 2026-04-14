using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsDriverData
    {
        public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID,
            ref DateTime CreatedDate)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM Drivers WHERE DriverID = @ID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ID", DriverID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                PersonID = (int)reader["PersonID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            }
                        }                        
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }
            
            return IsFind;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, 
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM Drivers WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                IsFind = true;
                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    INSERT INTO Drivers(PersonID,CreatedByUserID, CreatedDate)
                                    VALUES(@PersonID, @CreatedByUserID, @CreatedDate);
                                    SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out DriverID))
                            return DriverID;
                    }
                    catch (SqlException sqlex)
                    {
                        DriverID = -1;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }
            return DriverID;
        }

        public static bool UpdateDriver(int DriverID, DateTime CreatedDate)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "UPDATE Drivers SET CreatedDate = @CreatedDate WHERE DriverID = @DriverID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool IsPersonDriver(int PersonID)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT DriverID FROM Drivers WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
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
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }
            return (Result != null);
        }

        public static int GetDriverIDBy(int PersonID)
        {
            int DriverID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT DriverID FROM Drivers WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            DriverID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        DriverID = -1;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }
            return DriverID;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dtAllDrivers = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM Drivers_View;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllDrivers.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllDrivers = null;
                        clsEventLogHandler.LogException("DAL - Drivers", sqlex.Message);
                    }
                }
            }
            return dtAllDrivers;
        }        
    }
}