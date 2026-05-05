using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConnectionsLibrary
{
    public class AppConfigProvider : ExceptionsHandler, IDatabaseConnectionStringProvider
    {
        private readonly string _connectionName;
        private string _connectionString;

        public AppConfigProvider(string connectionName)
        {
            _connectionName = connectionName;
            _connectionString = GetConnectionString();
        }

        public string GetConnectionString()
        {
            string connectionString = "";
            if (ConfigurationManager.ConnectionStrings.Count > 0)
            {
                if (ConfigurationManager.ConnectionStrings[_connectionName] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
                }
            }
            return connectionString;
        }

        public bool HasConnection()
        {
            bool IsConnected = false;
            if (!string.IsNullOrEmpty(_connectionString))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        connection.Close();
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }
                }
            }
            return IsConnected;
        }
    }
}
