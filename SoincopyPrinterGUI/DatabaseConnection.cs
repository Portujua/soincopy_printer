using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SoincopyPrinterGUI
{
    class DatabaseConnection
    {
        private static string host = "localhost";
        private static string user = "root";
        private static string password = "21115476";
        private static string database = "soincopy";

        private string connectionString;
        private MySqlConnection connection;
        private string lastQuery;

        public DatabaseConnection()
        {
            this.connectionString = DatabaseConnection.getConnectionString();
        }

        public ConnectionState connect()
        {
            this.connection = new MySqlConnection(this.connectionString);
            this.connection.Open();

            return this.connection.State;
        }

        public bool isConnected()
        {
            return this.connection.State == ConnectionState.Open;
        }

        public void prepare(string sql)
        {
            this.lastQuery = sql;
        }

        public void printResults()
        {
            if (!this.isConnected())
            {
                Console.WriteLine("You must connect first.");
                return;
            }

            MySqlCommand cmd = new MySqlCommand(this.lastQuery, this.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString("total"));
            }
        }

        public string getFieldResult(string field)
        {
            if (!this.isConnected())
            {
                Console.WriteLine("You must connect first.");
                return string.Empty;
            }

            MySqlCommand cmd = new MySqlCommand(this.lastQuery, this.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            string r = string.Empty;

            if (!reader.HasRows)
            {
                throw new Exception("Factura inexistente");
            }

            while (reader.Read())
            {
                if (r.Length > 0) break;

                r = reader.GetString("total");
            }

            reader.Close();

            return r;
        }

        public static string getConnectionString()
        {
            return "host=" + DatabaseConnection.host + ";"
                + "user=" + DatabaseConnection.user + ";"
                + "password=" + DatabaseConnection.password + ";"
                + "database=" + DatabaseConnection.database + ";";
        }
    }
}
