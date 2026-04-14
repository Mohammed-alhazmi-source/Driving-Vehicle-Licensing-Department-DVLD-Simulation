using System;
using System.Configuration;

namespace DVDL.DAL
{
    public static class ConnectionSettings
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}