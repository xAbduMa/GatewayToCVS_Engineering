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
            string sqlServerConnectionString = DbConnector.Connections["DevelopmentHome"];
            string sqlServerProvider = DbConnector.Providers["DevelopmentCVS"];
            ConnectionTest result = DbConnector.HasConnection(sqlServerProvider, sqlServerConnectionString);
            MessageBox.Show(result.Message);
            string sqLiteConnectionString = DbConnector.Connections["ANSI-B4P1N2DB"];
            string sqLiteProvider = DbConnector.Providers["ANSI-B4P1N2DB"];
            string absolutePath = AppDomain.CurrentDomain.BaseDirectory;
            string useConnectionString = sqLiteConnectionString.Replace("{AppDir}", absolutePath.TrimEnd('\\'));
            result = DbConnector.HasConnection(sqLiteProvider, useConnectionString);
            MessageBox.Show(result.Message);
            
            //Application.Run(new Form1());
        }
    }
}
