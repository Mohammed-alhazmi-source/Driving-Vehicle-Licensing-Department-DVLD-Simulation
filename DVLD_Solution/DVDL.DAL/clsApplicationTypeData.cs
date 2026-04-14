using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsApplicationTypeData
    {

        public static bool GetApplicationTypeInfoByID(int ID, ref string Title, ref decimal Fees)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                Title = (string)reader["ApplicationTypeTitle"];
                                Fees = (decimal)reader["ApplicationFees"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int ApplicationTypeID = -1;
            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"INSERT INTO ApplicationTypes(ApplicationTypeTitle,ApplicationFees)
                                VALUES (@Title,@Fees);
                                SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            ApplicationTypeID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        ApplicationTypeID = -1;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return ApplicationTypeID;
        }

        public static bool UpdateApplicationType(int ID, string Title, decimal Fees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE ApplicationTypes
                                 SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                     ApplicationFees = @ApplicationFees
                                 WHERE ApplicationTypeID = @ApplicationTypeID;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ID);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
                    command.Parameters.AddWithValue("@ApplicationFees", Fees);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool IsApplicationTypeExist(string ApplicationTypeTitle)
        {
            object Result = null;
            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM ApplicationTypes 
                                 WHERE ApplicationTypeTitle = @ApplicationTypeTitle;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtAllApplicationsTypes = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM ApplicationTypes ORDER BY ApplicationTypeTitle ASC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllApplicationsTypes.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllApplicationsTypes = null;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return dtAllApplicationsTypes;
        }

        public static decimal GetFeesByApplicationType(int ApplicationTypeID)
        {
            decimal Fees = 0m;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

                using( SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && decimal.TryParse(Result.ToString(), out decimal PriceFees))
                            Fees = PriceFees;    
                    }
                    catch (SqlException sqlex)
                    {
                        Fees = 0m;
                        clsEventLogHandler.LogException("ApplicationTypes", sqlex.Message);
                    }
                }
            }

            return Fees;
        }
    }
}