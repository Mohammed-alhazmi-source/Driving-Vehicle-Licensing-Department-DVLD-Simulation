using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByID
            (
                int DetainID , ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees,
                ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate,
                ref int ReleasedByUserID, ref int ReleaseApplicationID
            )
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFound = true;
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];

                                if (reader["ReleaseDate"] == DBNull.Value)
                                    ReleaseDate = null;
                                else
                                    ReleaseDate = (DateTime?)reader["ReleaseDate"];

                                if (reader["ReleasedByUserID"] == DBNull.Value)
                                    ReleasedByUserID = -1;
                                else
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];

                                if (reader["ReleaseApplicationID"] == DBNull.Value)
                                    ReleaseApplicationID = -1;
                                else
                                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFound = false;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID
            (
                int LicenseID,ref int DetainID, ref DateTime DetainDate, ref decimal FineFees,
                ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate,
                ref int ReleasedByUserID, ref int ReleaseApplicationID
            )
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM DetainedLicenses 
                                WHERE LicenseID = @LicenseID AND IsReleased = 0;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];
                                ReleaseDate = null;
                                ReleasedByUserID = -1;
                                ReleaseApplicationID = -1;
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFound = false;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }

                return IsFound;
            }
        }

        public static int AddNewDetainedLicense
            (
              int LicenseID, DateTime DetainDate, decimal FineFees,
              int CreatedByUserID
            )
        {
            int DetainID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"                                                                
                                  INSERT INTO DetainedLicenses
                                             (LicenseID
                                             ,DetainDate
                                             ,FineFees
                                             ,CreatedByUserID                                            
                                  		   )
                                       VALUES
                                             (@LicenseID
                                             ,@DetainDate
                                             ,@FineFees
                                             ,@CreatedByUserID
                                             );
                                  SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            DetainID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        DetainID = -1;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return DetainID;
        }

        public static bool UpdateDetainedLicense
            (
               int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
              int CreatedByUserID
            )
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"                                                                  
                                  UPDATE DetainedLicenses
                                     SET LicenseID            = @LicenseID
                                        ,DetainDate           = @DetainDate
                                        ,FineFees             = @FineFees
                                        ,CreatedByUserID      = @CreatedByUserID                                        
                                   WHERE DetainID = @DetainID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool ReleaseDetainLicense(int DetainID,int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                   UPDATE DetainedLicenses 
                                   SET IsReleased = 1,
                                   ReleaseDate = @ReleaseDate,
                                   ReleasedByUserID = @ReleasedByUserID,
                                   ReleaseApplicationID = @ReleaseApplicationID
                                   WHERE DetainID = @DetainID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool IsDetainedLicense(int LicenseID)
        {
            bool IsDetained = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 Found = 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int DetainID))
                            IsDetained = true;
                    }
                    catch (SqlException sqlex)
                    {
                        IsDetained = false;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return IsDetained;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dtAllDetainedLicenses = new DataTable();

            using(SqlConnection connection  = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM DetainedLicenses_View;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllDetainedLicenses.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllDetainedLicenses = null;
                        clsEventLogHandler.LogException("DAL - DetainedLicenses", sqlex.Message);
                    }
                }
            }

            return dtAllDetainedLicenses;
        }
    }
}