using ConnectionsLibrary;
using System;
using System.Windows.Forms;

namespace MainForm { 

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlServerConnectionString = DbConnector.Connections["DevelopmentCVS"];
            string sqlServerProvider = DbConnector.Providers["DevelopmentCVS"];
            bool IsConnected = DbConnector.HasConnection(sqlServerProvider, sqlServerConnectionString);
            if (IsConnected) MessageBox.Show("Connected successfully to Microsoft SQL Server database!!");
            if (!IsConnected) MessageBox.Show("Failed to connect to Microsoft SQL Server database!!");
            string sqLiteConnectionString = DbConnector.Connections["ANSI-B4P1N2DB"];
            string sqLiteProvider = DbConnector.Providers["ANSI-B4P1N2DB"];
            string absolutePath = AppDomain.CurrentDomain.BaseDirectory;
            string useConnectionString = sqLiteConnectionString.Replace("{AppDir}", absolutePath.TrimEnd('\\'));
            IsConnected = DbConnector.HasConnection(sqLiteProvider, useConnectionString);
            if (IsConnected) MessageBox.Show("Connected successfully to SQLite database!!");
            if (!IsConnected) MessageBox.Show("Failed to connect to SQLite database!!");
            
            //Application.Run(new Form1());
        }
    }
}
