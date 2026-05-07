using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace ConnectionsLibrary
{
    public struct ConnectionTest
    {
        public bool Connected;
        public string Message;
    }
    public static class DbConnector
    {
        // Static dictionary to store connection strings by name
        public static readonly List<string> Names;
        public static readonly Dictionary<string, string> Connections;
        public static readonly Dictionary<string, string> Providers;

        static DbConnector()
        {

            // Populate the Connections dictionary from app.config/web.config
            Names = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .Select(cs => cs.Name).ToList();

            // Populate the Connections dictionary from app.config/web.config
            Connections = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(cs => cs.Name, cs => cs.ConnectionString);

            // Populate the Providers dictionary from app.config/web.config
            Providers = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(cs => cs.Name, cs => cs.ProviderName);
        }

        public static ConnectionTest HasConnection(string providerName, string connectionString) 
        {
            ConnectionTest result;
            result.Connected = false;
            result.Message = "";
            switch (providerName)
            {
                case "System.Data.SQLite":
                    result = HasSqLiteConnection(connectionString); break;
                case "System.Data.SqlClient":
                    result = HasSqlServerConnection(connectionString); break;
            }
            return result;
        }

        // Check if you have SQL Server connection
        public static ConnectionTest HasSqlServerConnection(string connectionString)
        {
            ConnectionTest result;
            result.Connected = false;
            result.Message = "";
            if (!string.IsNullOrEmpty(connectionString))
            {
                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        connection.Close();
                        result.Connected = true;
                        result.Message = "Connected successfully to SQL Server database!!";
                    }
                }
                catch (Exception ex)
                {
                    result.Connected = false;
                    result.Message = ex.ToString();
                }                                  
            }
            return result;
        }

        // Check if you have SQLite connection
        public static ConnectionTest HasSqLiteConnection(string connectionString)
        {
            ConnectionTest result;
            result.Connected = false;
            result.Message = "";
            if (!string.IsNullOrEmpty(connectionString))
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        connection.Close();
                        result.Connected = true;
                        result.Message = "Connected successfully to SQLite database!!";
                    }
                }
                catch (Exception ex)
                {
                    result.Connected = false;
                    result.Message = ex.ToString();
                }                   
            }
            return result;
        }
    }
}
