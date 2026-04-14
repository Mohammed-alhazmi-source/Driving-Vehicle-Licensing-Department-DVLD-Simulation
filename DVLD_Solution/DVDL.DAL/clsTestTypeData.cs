using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeInfoByID(int ID, ref string Title, ref string Description, ref decimal Fees)
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM TestTypes WHERE TestTypeID = @ID;";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                Title = (string)reader["TestTypeTitle"];
                                Description = (string)reader["TestTypeDescription"];
                                Fees = (decimal)reader["TestTypeFees"];
                            }
                        }

                        return IsFind;
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - TestTypes", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static int AddNewTestType(string Title, string Description, decimal Fees)
        {
            int TestTypeID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"INSERT INTO TestTypes(TestTypeTitle, TestTypeDescription, TestTypeFees)
                                 VALUES(@Title,@Description,@Fees);
                                 SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            TestTypeID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        TestTypeID = -1;
                        clsEventLogHandler.LogException("DAL - TestTypes", sqlex.Message);
                    }
                }
            }

            return TestTypeID;
        }

        public static bool UpdateTestType(int ID, string Title,string Description, decimal Fees)
        {
            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE TestTypes
                                 SET TestTypeTitle = @Title,
                                     TestTypeDescription = @Description,
                                     TestTypeFees = @Fees
                                 WHERE TestTypeID = @ID";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();

                        return (RowsAffected > 0);
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - TestTypes", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool IsTestTypeExist(string Title)
        {
            object Result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM TestTypes WHERE TestTypeTitle = @Title;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - TestTypes", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dtAllTestTypes = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM TestTypes ORDER BY TestTypeTitle ASC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllTestTypes.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllTestTypes = null;
                        clsEventLogHandler.LogException("DAL - TestTypes", sqlex.Message);
                    }
                }
            }
            return dtAllTestTypes;
        }
    }
}