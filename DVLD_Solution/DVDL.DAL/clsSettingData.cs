using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsSettingData
    {
        public static bool GetSettingInfoByID(int SettingID, ref int InternationalLicenseValidityLength)
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Settings WHERE SettingID = @SettingID;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@SettingID", SettingID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFound = true;
                                InternationalLicenseValidityLength = (int)reader["InternationalLicenseValidityLength"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFound = false;
                        clsEventLogHandler.LogException("DAL - Settings", sqlex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static int AddNewInternationalLicenseValidityLength(int InternationalLicenseValidityLength)
        {
            int SettingID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"INSERT INTO Settings(InternationalLicenseValidityLength) 
                                 VALUES(@InternationalLicenseValidityLength);
                                 SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseValidityLength", InternationalLicenseValidityLength);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            SettingID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        SettingID = -1;
                        clsEventLogHandler.LogException("DAL - Settings", sqlex.Message);
                    }
                }
            }

            return SettingID;
        }

        public static bool UpdateInternationalLicenseValidityLength(int SettingID, int InternationalLicenseValidityLength)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  UPDATE Settings 
                                  SET InternationalLicenseValidityLength = @InternationalLicenseValidityLength 
                                  WHERE SettingID = @SettingID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@SettingID", SettingID);
                    command.Parameters.AddWithValue("@InternationalLicenseValidityLength", InternationalLicenseValidityLength);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - Settings", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllInternationalLicenseValidityLength()
        {
            DataTable dtAllInternationalLicenseValidityLength = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Settings;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllInternationalLicenseValidityLength.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllInternationalLicenseValidityLength = null;
                        clsEventLogHandler.LogException("DAL - Settings", sqlex.Message);
                    }
                }
            }

            return dtAllInternationalLicenseValidityLength;
        }
    }
}