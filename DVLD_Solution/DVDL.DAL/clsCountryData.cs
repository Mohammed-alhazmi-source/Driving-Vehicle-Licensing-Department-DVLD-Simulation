using System;
using System.Data;
using System.Data.SqlClient;

namespace DVDL.DAL
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int ID,ref string Name)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Countries WHERE CountryID = @CountryID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@CountryID", ID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                Name = (string)reader["CountryName"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Countries", sqlex.Message);
                    }
                }
            }
            return IsFind;
        }

        public static bool GetCountryInfoByName(ref int ID, string Name)
        {
            bool IsFind = false;

            using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Countries WHERE CountryName = @CountryName;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@CountryName", Name);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IsFind = true;
                                ID = (int)reader["CountryID"];
                            }
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        IsFind = false;
                        clsEventLogHandler.LogException("DAL - Countries", sqlex.Message);
                    }
                }
            }
            return IsFind;
        }

        public static DataTable GetAllCountries()
        {
            DataTable CountriesNames = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Countries ORDER BY CountryName ASC;";

                using(SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                CountriesNames.Load(reader);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        CountriesNames = null;
                        clsEventLogHandler.LogException("DAL - Countries", sqlex.Message);
                    }
                }
            }
            return CountriesNames;
        }
    }
}