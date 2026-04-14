using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL.DAL
{
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ID, ref int PersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees,
            ref int UserID)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("ApplicationID", ID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                PersonID = (int)reader["ApplicationPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                UserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dtAllApplications = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Applications BY ORDER ApplicationDate DESC;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllApplications.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllApplications = null;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }
            return dtAllApplications;
        }

        public static int AddNewApplication(int PersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  INSERT INTO Applications
                                             ( 
                                  		       ApplicationPersonID,ApplicationDate, ApplicationTypeID, 
                                  			   ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                                  		     )
                                       VALUES
                                             (
                                  		       @PersonID,@ApplicationDate,@ApplicationTypeID,
                                  		       @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID
                                  		     );
                                  SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            ApplicationID = InsertedID;

                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationID = -1;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }

                return ApplicationID;
            }
        }

        public static bool UpdateApplication(int ApplicationID, int PersonID, DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  UPDATE Applications
                                     SET ApplicationPersonID = @PersonID, 
                                         ApplicationDate = @ApplicationDate,
                                         ApplicationTypeID = @ApplicationTypeID,
                                         PaidFees = @PaidFees,
                                         ApplicationStatus = @ApplicationStatus,
                                         LastStatusDate = @LastStatusDate,
                                         CreatedByUserID = @CreatedByUserID
                                   WHERE ApplicationID = @ID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteApplication(int ID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "DELETE FROM Applications WHERE ApplicationID = @ID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT Found = 1 FROM Applications WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                IsFound = true;
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFound = false;

                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int GetApplicationIDByPersonID(int PersonID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT ApplicationID FROM Applications WHERE ApplicationPersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ApplicationID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationID = -1;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return ApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, int NewStatus)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  UPDATE Applications
                                     SET 
                                         ApplicationStatus = @NewStatus,
                                         LastStatusDate = @LastStatusDate
                                   WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@NewStatus", NewStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static int HasIncompleteRequestOfType(int PersonID, int ApplicationStatus, int LicenseClassID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT A.ApplicationID
                                  FROM Applications A JOIN LocalDrivingLicenseApplications LDLA
                                  ON A.ApplicationID = LDLA.ApplicationID	
                                  WHERE (ApplicationPersonID = @PersonID AND ApplicationStatus = @ApplicationStatus) AND 
                                        (LDLA.LicenseClassID = @LicenseClassID);";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ApplicationID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationID = -1;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }
            return ApplicationID;
        }

        public static bool HasLicenseInCategory(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            object Result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT Found = 1
                                    FROM Applications A
                                    JOIN LocalDrivingLicenseApplications LDLA
                                    ON A.ApplicationID = LDLA.ApplicationID
                                    WHERE 
                                        (
                                          (   
                                            A.ApplicationPersonID = @PersonID AND 
                                            A.ApplicationTypeID = @ApplicationTypeID
                                          ) AND
                                          LDLA.LicenseClassID = @LicenseClassID AND
                                          A.ApplicationStatus = 3
                                        );";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT ActiveApplicationID = ApplicationID FROM Applications
                                  WHERE ApplicationPersonID = @PersonID AND
                                  ApplicationTypeID = @ApplicationTypeID AND
                                  ApplicationStatus = 1;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int GetID))
                            ActiveApplicationID = GetID;
                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationTypeID = -1;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }
            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT ActiveApplicationID = Applications.ApplicationID
                                    FROM Applications
                                    JOIN LocalDrivingLicenseApplications
                                    ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                                    WHERE Applications.ApplicationPersonID = @PersonID AND
                                    Applications.ApplicationTypeID = @ApplicationTypeID AND
                                    LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID AND
                                    Applications.ApplicationStatus = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ActiveApplicationID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        ActiveApplicationID = -1;
                        clsEventLogHandler.LogException("Applications", sqlex.Message);
                    }
                }
            }
            
            return ActiveApplicationID;
        }
    }
}