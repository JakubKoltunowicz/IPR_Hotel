using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hotel
{
    class DBCommand
    {
        private static DBConnection dbCon = DBConnection.Instance();

        public static string Imie(int ID_mieszkanca)
        {
            string query = "SELECT `Imie` FROM mieszkancy WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            string a = DBCommand.DoCommand(query).GetString(0);
            dbCon.Close();
            return a;
        }

        public static string Nazwisko(int ID_mieszkanca)
        {
            string query = "SELECT `Nazwisko` FROM mieszkancy WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            string a = DBCommand.DoCommand(query).GetString(0);
            dbCon.Close();
            return a;
        }

        public static string Informacje(int ID_mieszkanca)
        {
            string query = "SELECT `Informacje` FROM mieszkancy WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            string a = DBCommand.DoCommand(query).GetString(0);
            dbCon.Close();
            return a;
        }

        public static string Sciezka(int ID_mieszkanca)
        {
            string query = "SELECT `Sciezka` FROM mieszkancy WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            string a = "\\" + DBCommand.DoCommand(query).GetString(0);
            dbCon.Close();
            return a;
        }

        public static int ID()
        {
            string query = "SELECT COUNT(ID_mieszkanca) FROM mieszkancy";
            int a = DBCommand.DoCommand(query).GetInt32(0);
            dbCon.Close();
            return a;
        }

        public static int ID_po_imieniu(string dane)
        {
            string query = "SELECT ID_mieszkanca FROM mieszkancy WHERE `Imie` LIKE '" + dane + "'";
            int a = DBCommand.DoCommand(query).GetInt32(0);
            dbCon.Close();
            return a;
        }

        public static void Delete_picture(int ID_mieszkanca)
        {
            string query = "UPDATE mieszkancy SET `Sciezka` = '' WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            DBCommand.DoCommand(query);
            dbCon.Close();
        }

        public static void Aktualizacja(string sciezka, int ID_mieszkanca)
        {
            string query = "UPDATE mieszkancy SET `Sciezka` = '" + sciezka + "' WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            DBCommand.DoCommand(query);
            dbCon.Close();
        }

        public static void Aktualizacja_danych(string informacje, int ID_mieszkanca)
        {
            string query = "UPDATE mieszkancy SET `Informacje` = '" + informacje + "' WHERE ID_mieszkanca = '" + ID_mieszkanca + "'";
            DBCommand.DoCommand(query);
            dbCon.Close();
        }

        private static MySqlDataReader DoCommand(string query)
        {
            dbCon.Connect();
            var cmd = new MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            return reader;
        }
    }
}
