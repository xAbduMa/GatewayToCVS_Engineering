using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace ConnectionsLibrary
{
    public static class DbConnector
    {
        // Static dictionary to store connection strings by name
        public static readonly Dictionary<string, string> Connections;
        public static readonly Dictionary<string, string> Providers;

        static DbConnector()
        {
            // Populate the Connections dictionary from app.config/web.config
            Connections = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(cs => cs.Name, cs => cs.ConnectionString);

            // Populate the Providers dictionary from app.config/web.config
            Providers = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(cs => cs.Name, cs => cs.ProviderName);
        }

        public static bool HasConnection(string providerName, string connectionString) 
        {
            bool IsConnected = false;
            switch (providerName)
            {
                case "System.Data.SQLite":
                    IsConnected=HasSqLiteConnection(connectionString); break;
                case "System.Data.SqlClient":
                    IsConnected=HasSqlServerConnection(connectionString); break;
            }
            return IsConnected;
        }

        // Check if you have SQL Server connection
        public static bool HasSqlServerConnection(string connectionString)
        {
            bool IsConnected = false;
            if (!string.IsNullOrEmpty(connectionString))
            {                
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    IsConnected = true;
                }
            }
            return IsConnected;
        }

        // Check if you have SQLite connection
        public static bool HasSqLiteConnection(string connectionString)
        {
            bool IsConnected = false;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    IsConnected = true;                   
                }
            }
            return IsConnected;
        }
    }
}
