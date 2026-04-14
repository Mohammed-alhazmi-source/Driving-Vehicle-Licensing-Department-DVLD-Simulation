using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID
            (
               int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID,
               ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
               ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID
            )
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM Licenses WHERE LicenseID = @LicenseID;";

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
                                IsFind = true;
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else Notes = "";

                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }


        public static bool GetLicenseInfoByApplicationID
            (
               int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClassID,
               ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
               ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID
            )
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM Licenses WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                LicenseID = (int)reader["LicenseID"];                                
                                DriverID = (int)reader["DriverID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else Notes = "";

                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool GetLicenseInfoByDriverID
           (
              int DriverID, ref int LicenseID, ref int ApplicationID, ref int LicenseClassID,
              ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
              ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID
           )
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM Licenses WHERE DriverID = @DriverID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else Notes = "";

                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }


        public static int AddNewLicense
            (
                int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID
            )
        {
            int LicenseID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string InsertStatement = @"
                                            INSERT INTO Licenses
                                                       (
                                            		     ApplicationID, DriverID, LicenseClassID, IssueDate,
                                                         ExpirationDate, Notes, PaidFees, IsActive,
                                                         IssueReason, CreatedByUserID
                                            			)
                                                 VALUES
                                                       (
                                            		     @ApplicationID, @DriverID, @LicenseClassID, @IssueDate,
                                            		     @ExpirationDate, @Notes, @PaidFees, @IsActive,
                                            		     @IssueReason, @CreatedByUserID
                                            		   );
                                            SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(InsertStatement,connection)) 
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    if (string.IsNullOrEmpty(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);

                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            LicenseID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        LicenseID = -1;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }
            return LicenseID;
        }


        public static bool UpdateLicense
            (
                int LicenseID,
                int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID
            )
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string InsertStatement = @"
                                            UPDATE Licenses SET                                                    
                                            		     ApplicationID = @ApplicationID,
                                                         DriverID = @DriverID, 
                                                         LicenseClass = @LicenseClassID,
                                                         IssueDate = @IssueDate,
                                                         ExpirationDate = @ExpirationDate,
                                                         Notes = @Notes,
                                                         PaidFees = @PaidFees,
                                                         IsActive = @IsActive,
                                                         IssueReason = @IssueReason, 
                                                         CreatedByUserID = @CreatedByUserID
                                            WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(InsertStatement, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dtAllLicenses = new DataTable();

            using(SqlConnection connection  = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Licenses;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllLicenses.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllLicenses = null;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }
            return dtAllLicenses;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dtLocalLicensesHistory = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT 
                                  	L.LicenseID,
                                  	L.ApplicationID,
                                  	LC.ClassName,
                                  	L.IssueDate,
                                  	L.ExpirationDate,
                                  	L.IsActive
                                  FROM Licenses L
                                  JOIN LicenseClasses LC
                                  ON	L.LicenseClassID = LC.LicenseClassID
                                  WHERE L.DriverID = @DriverID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtLocalLicensesHistory.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtLocalLicensesHistory = null;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return dtLocalLicensesHistory;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT L.LicenseID
                                    FROM Licenses L
                                    JOIN Applications A
                                    ON L.ApplicationID = A.ApplicationID
                                    WHERE A.ApplicationPersonID = @PersonID
                                    AND L.LicenseClassID = @LicenseClassID
                                    AND A.ApplicationStatus = 3 AND L.IsActive = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static int GetActiveLicenseIDByPersonID(int ApplicationPersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {               
                string Query = @"
                                  SELECT 
                                   L.LicenseID
                                  FROM Licenses L
                                   JOIN Drivers D
                                   ON L.DriverID = D.DriverID
                                  WHERE D.PersonID = @ApplicationPersonID AND L.LicenseClassID = @LicenseClassID 
                                   AND  L.IsActive = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            LicenseID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        LicenseID = -1;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }
            return LicenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE Licenses SET IsActive = 0 WHERE LicenseID  = @LicenseID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - Licenses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }
    }
}