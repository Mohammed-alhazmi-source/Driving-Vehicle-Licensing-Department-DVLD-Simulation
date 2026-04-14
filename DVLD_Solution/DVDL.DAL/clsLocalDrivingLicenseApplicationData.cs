using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM LocalDrivingLicenseApplications
                                 WHERE LocalDrivingLicenseApplicationID = @ID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, 
            ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM LocalDrivingLicenseApplications
                                 WHERE ApplicationID = @ApplicationID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
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
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static int GetPersonIDByLocalDrivingLicenseApplicationID(int LDLAID)
        {
            int PersonID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT 
                                    P.PersonID
                                    FROM LocalDrivingLicenseApplications LDLA
                                    INNER JOIN Applications A
                                    ON LDLA.ApplicationID = A.ApplicationID
                                    INNER JOIN People P
                                    ON a.ApplicationPersonID = P.PersonID
                                    where LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int PersonId))
                            PersonID = PersonId;
                    }
                    catch (SqlException sqlex)
                    {
                        PersonID = -1;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return PersonID;
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  INSERT INTO LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                                  VALUES(@ApplicationID, @LicenseClassID);
                                  SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            LocalDrivingLicenseApplicationID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        LocalDrivingLicenseApplicationID = -1;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  UPDATE LocalDrivingLicenseApplications
                                  SET LicenseClassID = @LicenseClassID
                                  WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplication)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"DELETE FROM LocalDrivingLicenseApplications 
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplication;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplication", LocalDrivingLicenseApplication);

                    try
                    {
                        connection.Open();


                        RowsAffected = command.ExecuteNonQuery();

                        return (RowsAffected > 0);
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationsDetails()
        {
            DataTable dtAllLocalDrivingLicenseApplicationsDetails = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllLocalDrivingLicenseApplicationsDetails.Load(reader);
                        }

                        return dtAllLocalDrivingLicenseApplicationsDetails;
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllLocalDrivingLicenseApplicationsDetails = null;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return dtAllLocalDrivingLicenseApplicationsDetails;
        }        

        public static int GetApplicationIDBy(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT ApplicationID 
                                  FROM LocalDrivingLicenseApplications 
                                  WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int AppID))
                            ApplicationID = AppID;
                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationID = -1;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }
            
            return ApplicationID;
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"                                   
                                  SELECT T.TestResult
                                 FROM TestAppointments TA
                                 JOIN Tests T
                                 ON TA.TestAppointmentID = T.TestAppointmentID
                                 WHERE TA.TestAppointmentID = (
                                 SELECT   MAX(TestAppointmentID)
                                 FROM TestAppointments
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                   AND TestTypeID = @TestTypeID)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Result = (bool)reader["TestResult"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        Result = false;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return Result;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsAttend = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT TOP 1 Found = 1
                                    FROM TestAppointments TA
                                    WHERE TA.LocalDrivingLicenseApplicationID = @LocalAppID AND 
                                    TA.TestTypeID = @TestTypeID AND 
                                    TA.IsLocked = 1
                                    ORDER BY TA.TestAppointmentID DESC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalAppID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null)
                            IsAttend = true;
                    }
                    catch (SqlException sqlex)
                    {
                        IsAttend = false;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }
            return IsAttend;
        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TotalTrialsPerTest = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT COUNT(T.TestAppointmentID) AS TrialCount
                                  FROM TestAppointments TA
                                  JOIN
                                  	Tests T
                                  ON TA.TestAppointmentID = T.TestAppointmentID
                                  WHERE 
                                    TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TA.TestTypeID = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int TrialCount))
                            TotalTrialsPerTest = TrialCount;
                    }
                    catch (SqlException sqlex)
                    {
                        TotalTrialsPerTest = 0;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return TotalTrialsPerTest;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            object Result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT Found = 1 FROM TestAppointments WHERE TestAppointmentID = (
                                    SELECT  MAX(TestAppointmentID)
                                    FROM TestAppointments
                                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                    AND TestTypeID = @TestTypeID AND IsLocked = 0);";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - LocalDrivingLicenseApplications", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }
    }
}