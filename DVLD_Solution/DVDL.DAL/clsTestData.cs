using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsTestData
    {
        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, 
                                           ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;

            using(SqlConnection  connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM Tests WHERE TestID = @TestID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else Notes = "";

                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static bool GetTestInfoByTestAppointmentID(int TestAppointmentID, ref int TestID, ref bool TestResult,
                                           ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM Tests WHERE TestAppointmentID = @TestAppointmentID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                TestID = (int)reader["TestID"];
                                TestResult = (bool)reader["TestResult"];

                                if (reader["Notes"] != DBNull.Value) Notes = (string)reader["Notes"];
                                else Notes = "";

                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }
            return IsFind;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"INSERT INTO Tests(TestAppointmentID,TestResult,Notes, CreatedByUserID)
                                    VALUES(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);

                                    UPDATE TestAppointments SET IsLocked = 1 
                                    WHERE TestAppointmentID = @TestAppointmentID;

                                    SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(NonQuery, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);

                    if (string.IsNullOrEmpty(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    else command.Parameters.AddWithValue("@Notes", Notes);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            TestID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        TestID = -1;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }

            return TestID;
        }

        public static bool UpdateTest(int TestID, string Notes)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE Tests 
                                 SET Notes = @Notes
                                 WHERE TestID = @TestID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);

                    if (string.IsNullOrEmpty(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    else command.Parameters.AddWithValue("@Notes", Notes);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllTests()
        {
            DataTable dtAllTests = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Tests;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllTests.Load(reader);
                        }                       
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllTests = null;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }

            return dtAllTests;
        }

        public static int GetPassedTestsCount(int LocalAppID)
        {
            int PassedTestsCount = 0;

            using(SqlConnection connection  = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                //string Query = @"SELECT COUNT(TestAppointmentID)
                //                 FROM Tests
                //                 WHERE TestResult = @TestResult AND TestAppointmentID = @TestAppointmentID;";

                string Query = @"
                                  SELECT 
                                  COUNT (T.TestAppointmentID) AS PassedTestsCount
                                  FROM TestAppointments TA
                                  JOIN Tests T
                                  ON TA.TestAppointmentID = T.TestAppointmentID
                                  JOIN
                                  LocalDrivingLicenseApplications LDLA
                                  ON
                                  	LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                  WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalAppID
                                  AND T.TestResult = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    //command.Parameters.AddWithValue("@TestResult", true);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int Count))
                            PassedTestsCount = Count;
                    }
                    catch (SqlException sqlex)
                    {
                        PassedTestsCount = 0;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }
            return PassedTestsCount;
        }

        public static bool GetLastTestByPersonIDAndTestTypeIDAndLicenseClassID(
            int PersonID, int TestTypeID,int LicenseClassID,
            ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref int CreatedByUserID,
            ref string Notes)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT TOP 1
                                    T.TestID, T.TestAppointmentID, T.TestResult, T.CreatedByUserID, T.Notes
                                    FROM Tests T
                                    JOIN TestAppointments TA
                                    ON T.TestAppointmentID = TA.TestAppointmentID
                                    JOIN LocalDrivingLicenseApplications LDLA
                                    ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                                    JOIN Applications A
                                    ON A.ApplicationID = LDLA.ApplicationID
                                    JOIN People P
                                    ON A.ApplicationPersonID = P.PersonID
                                    WHERE P.PersonID = @PersonID AND TA.TestTypeID = @TestTypeID AND 
                                    LDLA.LicenseClassID = @LicenseClassID 
                                    AND A.ApplicationStatus = 1
                                    ORDER BY TA.TestAppointmentID DESC



";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                TestID = (int)reader["TestID"];
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                if (reader["Notes"] == DBNull.Value) Notes = "";

                                else Notes = (string)reader["Notes"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Tests", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }
    }
}