using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Hotel
{
    class DBConnection
    {
        private static string Server = File.ReadLines("Dbserver.conf").ElementAtOrDefault(0);
        private static string database = File.ReadLines("Dbserver.conf").ElementAtOrDefault(1);
        private static string UID = File.ReadLines("Dbserver.conf").ElementAtOrDefault(2);
        private static string password = File.ReadLines("Dbserver.conf").ElementAtOrDefault(3);
        private static string sslMode = File.ReadLines("Dbserver.conf").ElementAtOrDefault(4);
        private static string baza = File.ReadLines("Dbserver.conf").ElementAtOrDefault(5);

        string connstring = string.Format("Server=" + Server + " ; database=" + database + "; UID=" + UID + "; password=" + password + "; sslMode=" + sslMode + ";", baza);

        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public void Connect()
        {
            connection = new MySqlConnection(connstring);
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
