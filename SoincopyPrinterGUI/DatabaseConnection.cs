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
        public static string HOST = "localhost";
        public static string USER = "root";
        public static string PASSWORD = "21115476";
        public static string DATABASE = "soincopy";

        private string connectionString;
        private MySqlConnection connection;
        private string lastQuery;
        private string errorMessage;

        public DatabaseConnection()
        {
            this.connectionString = DatabaseConnection.getConnectionString();
        }

        public DatabaseConnection(string host, string user, string password, string database)
        {
            this.connectionString = DatabaseConnection.getConnectionString(host, user, password, database);
        }

        public ConnectionState connect()
        {
            this.connection = new MySqlConnection(this.connectionString);

            try {
                this.connection.Open();
            }
            catch (MySqlException ex)
            {
                this.errorMessage = "No se pudo establecer conexión con el servidor MySQL.";
            }
            

            return this.connection.State;
        }

        public string getLastError()
        {
            return this.errorMessage != null ? this.errorMessage : String.Empty;
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
                reader.Close();
                throw new UnexistantBillException("Factura inexistente");
            }

            while (reader.Read())
            {
                if (r.Length > 0) break;

                r = reader.GetString("total");
            }

            reader.Close();

            return r;
        }

        public void changeConnection(string host, string user, string password, string database)
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
                this.connectionString = DatabaseConnection.getConnectionString(host, user, password, database);
                this.connect();
            }
        }

        public static string getConnectionString()
        {
            return "host=" + DatabaseConnection.HOST + ";"
                + "user=" + DatabaseConnection.USER + ";"
                + "password=" + DatabaseConnection.PASSWORD + ";"
                + "database=" + DatabaseConnection.DATABASE + ";";
        }

        public static string getConnectionString(string host, string user, string password, string database)
        {
            return "host=" + host + ";"
                + "user=" + user + ";"
                + "password=" + password + ";"
                + "database=" + database + ";";
        }
    }

    class UnexistantBillException : Exception
    {
        public UnexistantBillException()
            : base() { }

        public UnexistantBillException(string message)
            : base(message) { }

        public UnexistantBillException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public UnexistantBillException(string message, Exception innerException)
            : base(message, innerException) { }

        public UnexistantBillException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
