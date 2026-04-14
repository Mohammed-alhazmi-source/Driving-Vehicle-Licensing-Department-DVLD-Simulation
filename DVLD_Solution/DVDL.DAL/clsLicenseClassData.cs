using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID
            (
              int ID, ref string Name, ref string Description, ref byte MinimumAllowedAge,
              ref byte DefaultValidityLength, ref decimal Fees
            )
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @" SELECT TOP 1 * FROM LicenseClasses WHERE LicenseClassID = @ID;";

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
                                Name = (string)reader["ClassName"];
                                Description = (string)reader["ClassDescription"];
                                MinimumAllowedAge = (byte)reader["MinimunAllowedAge"];
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                Fees = (decimal)reader["ClassFees"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }
            return IsFind;
        }

        public static bool GetLicenseClassInfoByClassName
            (
                string ClassName, ref int LicenseClassID, ref string Description,
                ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees
            )
        {
            bool IsFind = false;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 * FROM LicenseClasses WHERE ClassName = @ClassName;";

                using(SqlCommand command  = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                IsFind = true;
                                LicenseClassID = (int)reader["LicenseClassID"];
                                Description = (string)reader["Description"];
                                MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                ClassFees = (decimal)reader["ClassFees"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return IsFind;
        }

        public static int AddNewLicenseClass
            (
              string Name, string Description, byte MinimumAllowedAge,
              byte DefaultValidityLength,  decimal Fees
            )
        {
            int LicenseClassID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string NonQuery = @"
                                    INSERT INTO LicenseClasses
                                    	(
                                    		ClassName,ClassDescription,MinimunAllowedAge,
                                    		DefaultValidityLength,ClassFees
                                    	)
                                    	VALUES
                                    	(
                                    		@Name, @Description, @MinimumAllowedAge,
                                    		@DefaultValidityLength, @Fees
                                    	);
                                    	SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(NonQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            LicenseClassID = InsertedID;
                    }
                    catch (SqlException sqlex)
                    {
                        LicenseClassID = -1;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return LicenseClassID;
        }

        public static bool UpdateLicenseClass(int ID, string Name, string Description, byte MinimumAllowedAge,
            byte DefaultValidityLength, decimal Fees
            )
        {

            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"UPDATE LicenseClasses
                                 SET ClassName = @Name,
                                     ClassDescription = @Description,
                                     MinimumAllowedAge = @MinimumAllowedAge,
                                     DefaultValidityLength = @DefaultValidityLength,
                                     ClassFees = @Fees
                                 WHERE LicenseClassID = @ID;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlex)
                    {
                        RowsAffected = 0;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }


        public static bool IsLicenseClassExist(string ClassName)
        {
            object Result = null;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT TOP 1 * FROM LicenseClasses WHERE ClassName = @ClassName;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        connection.Open();

                        Result = command.ExecuteScalar();
                    }
                    catch (SqlException sqlex)
                    {
                        Result = null;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return (Result != null);
        }

        public static int GetLicenseClassIDBy(string Name)
        {
            int LicenseClassID = -1;

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT LicenseClassID FROM LicenseClasses WHERE ClassName = @Name;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            LicenseClassID = ID;
                    }
                    catch (SqlException sqlex)
                    {
                        LicenseClassID = -1;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return LicenseClassID;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtAllLicenseClasses = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = @"SELECT * FROM LicenseClasses;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtAllLicenseClasses.Load(reader);
                        }

                        return dtAllLicenseClasses;
                    }
                    catch (SqlException sqlex)
                    {
                        dtAllLicenseClasses = null;
                        clsEventLogHandler.LogException("DAL - LicenseClasses", sqlex.Message);
                    }
                }
            }

            return dtAllLicenseClasses;
        }
    }
}