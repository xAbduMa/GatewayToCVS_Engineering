using System;
using System.Data.SQLite;

namespace BaseLibrary
{

    public class SQLiteProvider : IDatabaseConnectionStringProvider
    {
        private readonly string _databaseName;
        private readonly string _appSUPath;
        private string _connectionString;

        public SQLiteProvider(string appSUPath, string databaseName)
        {
            _appSUPath = appSUPath;
            _databaseName = databaseName;
            _connectionString=GetConnectionString();
        }

        public string GetConnectionString()
        {
            string connectionString = _appSUPath + "\\" + _databaseName;

            connectionString = string.Format("Data Source = {0}; Version = 3;", connectionString);

            return connectionString;
        }
        public bool HasConnection()
        {
            bool IsConnected = false;
            if (!string.IsNullOrEmpty(_connectionString))
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        connection.Close();
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return IsConnected;
        }
    }
}
