using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID
            (
                int ID, ref int TestTypeID, ref int LocalAppID, ref DateTime AppointmentDate,
                ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, 
                ref int RetakeTestApplicationID
            )
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM TestAppointments WHERE TestAppointmentID = @ID;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                TestTypeID = (int)reader["TestTypeID"];
                                LocalAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];

                                if (reader["RetakeTestApplicationID"] != DBNull.Value)
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                else
                                    RetakeTestApplicationID = -1;
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        // جلب معلومات اخر موعد للطلب على نوع الاختبار المعين اما فحص النظر او الورق او العملي
        public static bool GetLastTestAppointment
            (
                int LocalAppID,int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate,
                ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked,
                ref int? RetakeTestApplicationID
            )
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                  SELECT TOP 1 * FROM TestAppointments
                                  WHERE LocalDrivingLicenseApplicationID = @LocalAppID AND 
                                  TestTypeID = @TestTypeID
                                  ORDER BY TestAppointmentID DESC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    command.Parameters.AddWithValue("TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];

                                if (reader["RetakeTestApplicationID"] != DBNull.Value)
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                else
                                    RetakeTestApplicationID = null;
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }
            return IsFind;
        }

        public static int AddNewTestAppointment
            (
              int TestTypeID, int LocalAppID, DateTime AppointmentDate,
              decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID
            )
        {
            int TestAppointmentID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"
                                     INSERT INTO TestAppointments
                                                (TestTypeID ,LocalDrivingLicenseApplicationID ,AppointmentDate,
                                                 PaidFees,CreatedByUserID ,IsLocked ,RetakeTestApplicationID)
                                          VALUES
                                                (@TestTypeID, @LocalAppID, @AppointmentDate,
                                     		   @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                                     SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(NonQuery,connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    if (RetakeTestApplicationID == -1)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            TestAppointmentID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        TestAppointmentID = -1;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(
                int ID, int TestTypeID, int LocalAppID, DateTime AppointmentDate,
                decimal PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"UPDATE TestAppointments 
                                    SET TestTypeID = @TestTypeID,
                                        LocalDrivingLicenseApplicationID = @LocalAppID,
                                        AppointmentDate = @AppointmentDate,
                                        PaidFees = @PaidFees,
                                        CreatedByUserID = @CreatedByUserID,
                                        IsLocked = @IsLocked,
                                        RetakeTestApplicationID = @RetakeTestApplicationID
                                    WHERE TestAppointmentID = @TestAppointmentID";

                using(SqlCommand command = new SqlCommand(NonQuery,connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    if (RetakeTestApplicationID == -1)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                    command.Parameters.AddWithValue("@TestAppointmentID", ID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        // ملغية لاتتدخل في عمل عليها ملاحظة تجاهلها
        public static bool UpdateTestAppointmentDate(int TestAppointmentID, DateTime AppointmentDate)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"UPDATE TestAppointments 
                                    SET AppointmentDate = @AppointmentDate,                                      
                                    WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(NonQuery, connection))
                {                    
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);                    
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool UpdateStatus(int TestAppointmentID, bool IsLocked)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"UPDATE TestAppointments 
                                    SET IsLocked = @IsLocked                                   
                                    WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(NonQuery, connection))
                {
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);                  
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        // ملغية لاتتدخل في عمل عليها ملاحظة تجاهلها
        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT Found = 1 FROM TestAppointments 
                                 WHERE TestAppointmentID = @TestAppointmentID AND IsLocked = 1;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static DataTable GetAllTestAppointments()
        {
            DataTable dtAllTestAppointments = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM TestAppointments_View ORDER BY AppointmentDate DESC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllTestAppointments.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllTestAppointments = null;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return dtAllTestAppointments;
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalAppID, int TestTypeID)
        {
            DataTable dtAllTestAppointments = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT 
                                  TestAppointmentID,AppointmentDate,PaidFees,IsLocked
                                 FROM TestAppointments
                                 WHERE LocalDrivingLicenseApplicationID = @LocalAppID AND TestTypeID = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllTestAppointments.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllTestAppointments = null;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return dtAllTestAppointments;
        }

        public static bool IsLastTestAppointmentNotLocked(int LocalAppID, int TestTypeID, ref bool IsLocked)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"
                                    SELECT IsLocked FROM TestAppointments WHERE TestAppointmentID = (
                                    SELECT   MAX(TestAppointmentID)
                                    FROM TestAppointments
                                    WHERE LocalDrivingLicenseApplicationID = @LocalAppID AND TestTypeID = @TestTypeID);";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                IsLocked = (bool)reader["IsLocked"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }
        // جلب معرف الاختبار التابع للموعد عدلتها اضتفها من الدكتور لغرض استخدام
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT T.TestID FROM Tests T WHERE T.TestAppointmentID = @TestAppointmentID;";

                using(SqlCommand command  = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            TestID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        TestID = -1;
                        clsEventLogHandler.LogException("DAL - TestAppointments", sqlex.Message);
                    }
                }
            }
            return TestID;
        }
    }
}