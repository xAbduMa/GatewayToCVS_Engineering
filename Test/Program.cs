using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConnectionsLibrary;

namespace Test
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
            DbConnector.BaseDirectory= AppDomain.CurrentDomain.BaseDirectory;
            List<string> ConnectionNames = DbConnector.Names;
            string ConnectionStringName = "";
            using (var dialog = new ComboBoxDialogueForm("Connection Strings", "Please select a connection string name:", ConnectionNames))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ConnectionStringName = dialog.SelectedItem;
                    string ConnectionString = DbConnector.Connections[ConnectionStringName];
                    string Provider = DbConnector.Providers[ConnectionStringName];
                    ConnectionTest result = DbConnector.HasConnection(Provider, ConnectionString);
                    MessageBox.Show(result.Message);
                }
            }
        }
    }
}
