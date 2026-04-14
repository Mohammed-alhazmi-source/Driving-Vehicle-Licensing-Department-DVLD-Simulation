using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsInternationalLicenseData
    {
        public static bool GetInternationalLicenseInfoByID
        (
            int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
            ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref bool IsActive, ref int CreatedByUserID
        )
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFound = true;
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFound = false;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            DataTable dtInternationalLicenses = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT 
                                    IL.InternationalLicenseID, IL.ApplicationID,
                                    L.LicenseID, IL.IssueDate,
                                    IL.ExpirationDate, IL.IsActive
                                    FROM InternationalLicenses IL
                                    JOIN Licenses L
                                    ON IL.IssuedUsingLocalLicenseID = L.LicenseID
                                    WHERE IL.DriverID = @DriverID;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtInternationalLicenses.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtInternationalLicenses = null;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return dtInternationalLicenses;
        }

        public static int AddNewInternationalLicense
            (
                int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
                DateTime ExpirationDate, bool IsActive, int CreatedByUserID
            )
        {
            int InternationalLicenseID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    UPDATE InternationalLicenses
                                    SET IsActive = 0 WHERE DriverID = @DriverID;

                                    INSERT INTO InternationalLicenses
                                               (
                                    			 ApplicationID
                                    			,DriverID
                                    			,IssuedUsingLocalLicenseID
                                    			,IssueDate
                                    			,ExpirationDate
                                    			,IsActive
                                    			,CreatedByUserID
                                    		   )
                                         VALUES
                                    		   (
                                    			  @ApplicationID
                                    			 ,@DriverID
                                    			 ,@IssuedUsingLocalLicenseID
                                    			 ,@IssueDate
                                    			 ,@ExpirationDate
                                    			 ,@IsActive
                                    			 ,@CreatedByUserID
                                    		   );
                                    SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            InternationalLicenseID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        InternationalLicenseID = -1;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return InternationalLicenseID;
        }

        public static bool UpdateInternationalLicense
            (
                int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, 
                DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID
            )
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  UPDATE InternationalLicenses
                                  SET ApplicationID = @ApplicationID,
                                  DriverID = @DriverID,
                                  IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                  IssueDate = @IssueDate,
                                  ExpirationDate = @ExpirationDate,
                                  IsActive = @IsActive,
                                  CreatedByUserID = @CreatedByUserID
                                  WHERE InternationalLicenseID = @InternationalLicenseID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();                     
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool DeactivateInternationalLicense(int InternationalLicenseID)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE InternationalLicenses SET IsActive = 0 WHERE InternationalLicenseID = @InternationalLicenseID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static int GetActiveInternationalLicenseByLicenseID(int DriverID)
        {
            int InternationalLicenseID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM InternationalLicenses 
                                 WHERE DriverID = @DriverID AND IsActive = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            InternationalLicenseID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        InternationalLicenseID = -1;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return InternationalLicenseID;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtAllInternationalLicenses = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT 
                                  IL.InternationalLicenseID, IL.ApplicationID, IL.DriverID,
                                  L.LicenseID, IL.IssueDate,
                                  IL.ExpirationDate, IL.IsActive
                                  FROM InternationalLicenses IL
                                  JOIN Licenses L
                                  ON IL.IssuedUsingLocalLicenseID = L.LicenseID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllInternationalLicenses.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllInternationalLicenses = null;
                        clsEventLogHandler.LogException("DAL - InternationalLicenses", sqlex.Message);
                    }
                }
            }

            return dtAllInternationalLicenses;
        }
    }
}