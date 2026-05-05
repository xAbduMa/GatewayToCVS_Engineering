using ConnectionsLibrary;
using System;
using System.Windows.Forms;

namespace MainForm
{
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

            AppConfigProvider appConfigProvider = new AppConfigProvider("DevelopmentHome");
            
            if (appConfigProvider.HasConnection())
            {
                MessageBox.Show("Connected successfully to Microsoft SQL Server database!!");
            }
            else
            {
                MessageBox.Show("Failed to connect to Microsoft SQL Server database!!");
            }

            SQLiteProvider sqLiteProvider = new SQLiteProvider(Application.StartupPath, "ANSI-B4P1N2V0.2.db");

            if (sqLiteProvider.HasConnection())
            {
                MessageBox.Show("Connected successfully to SQLite database!!");
            }
            else
            {
                MessageBox.Show("Failed to connect to SQLite database!!");
            }
            
            //Application.Run(new Form1());
        }
    }
}
