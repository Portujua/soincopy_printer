using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoincopyPrinterGUI
{
    public partial class Form1 : Form
    {
        public static string WEB_HOST = "localhost";
        public static string WEB_PORT = "";
        public static string WEB_ENDPOINT = "soincopy/factura/";
        public static bool WEB_HTTPS = false;

        private Server server;
        private DatabaseConnection dbc;
        private Settings settings;

        public Form1()
        {
            InitializeComponent();

            this.log("Cargando configuración");
            this.settings = new Settings();
            this.settings.load();
            this.importSettings();

            this.dbc = new DatabaseConnection();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // Check for errors before initiating
            if (!string.IsNullOrWhiteSpace(errorProvider1.GetError(textBox_port)) || !string.IsNullOrWhiteSpace(errorProvider1.GetError(textBox_webPort)))
            {
                string errorMessage = string.Concat(
                    "Se deben corregir los errores antes de iniciar el servidor", 
                    Environment.NewLine, 
                    Environment.NewLine,
                    "Los campos con errores son los siguientes:",
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(errorProvider1.GetError(textBox_port)) ? string.Concat("- Puerto del servidor: ", errorProvider1.GetError(textBox_port), Environment.NewLine) : String.Empty,
                    !string.IsNullOrWhiteSpace(errorProvider1.GetError(textBox_webPort)) ? string.Concat("- Puerto del servidor web: ", errorProvider1.GetError(textBox_webPort), Environment.NewLine) : String.Empty);

                this.log(errorMessage);
                MessageBox.Show("Debe corregir los errores antes de iniciar el servidor. Para más información consulte la consola.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Init
            this.switchControls(false);
            // Init MySQL connection
            this.log("Estableciendo conexión con el servidor MySQL");
            this.dbc.connect();

            if (!this.dbc.isConnected())
            {
                this.log(this.dbc.getLastError());
                MessageBox.Show("Ha ocurrido un error iniciando el servidor. Por favor consulte la consola para más información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.log("Conexión establecida con éxito");
                this.log("Iniciando servidor de impresión");
                // Init print server
                server = new Server("localhost", Convert.ToInt32(textBox_port.Text));
                server.init();
                bgw_server.DoWork += Bgw_server_DoWork;
                bgw_server.RunWorkerAsync();
                this.log("Servidor de impresión corriendo...");
            }

            this.switchControls(true);
        }

        private void Bgw_server_DoWork(object sender, DoWorkEventArgs e)
        {
            server.run();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ErrorProvider check
            if (string.IsNullOrWhiteSpace(textBox_port.Text) || !Utils.DigitsOnly(textBox_port.Text))
            {
                errorProvider1.SetError(textBox_port, "Debe contener un valor numérico entre 1 y 65536");
            }
            else
            {
                errorProvider1.SetError(textBox_port, "");
            }

            if (!Utils.DigitsOnly(textBox_webPort.Text))
            {
                errorProvider1.SetError(textBox_webPort, "Debe contener un valor numérico entre 1 y 65536");
            }
            else
            {
                errorProvider1.SetError(textBox_webPort, "");
            }

            // Clear console
            if (textBox_log.Text.Length > 3000)
            {
                textBox_log.Text = String.Empty;
            }

            // Server check
            if (server != null)
            {
                if (server.ultimaFactura > -1)
                {
                    int _ultimaFactura = server.ultimaFactura;
                    server.ultimaFactura = -1;

                    string lastResponse = server.getLastResponse();

                    this.log(lastResponse);

                    if (!lastResponse.Contains("Factura inexistente"))
                    {
                        webBrowser1.DocumentText = Server.getHtmlFrom(
                            string.Format("{0}://{1}{2}/{3}{4}",
                                checkBox_webHttps.Checked ? "https" : "http",
                                textBox_webHost.Text.ToLower(),
                                textBox_webPort.Text.Length > 0 ? string.Format(":{0}", textBox_webPort.Text) : String.Empty,
                                textBox_webEndpoint.Text,
                                _ultimaFactura
                            )
                        );
                    }
                }

                if (server.isRunning())
                {
                    button_start.Text = "Corriendo";
                    this.switchControls(false);
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Print();
        }

        public void log(string m)
        {
            textBox_log.AppendText(string.Concat(Environment.NewLine,
                DateTime.Now.ToString(@"dd\/MM\/yyyy hh\:mm\:ss tt"),
                ": ",
                m));
        }

        public void switchControls(bool newState)
        {
            // Buttons
            button_start.Enabled = newState;

            // Textboxes
            textBox_port.Enabled = newState;

            textBox_webHost.Enabled = newState;
            textBox_webPort.Enabled = newState;
            textBox_webEndpoint.Enabled = newState;

            textBox_dbHost.Enabled = newState;
            textBox_dbUser.Enabled = newState;
            textBox_dbPassword.Enabled = newState;
            textBox_dbName.Enabled = newState;

            // Checkboxes
            checkBox_webHttps.Enabled = newState;
        }

        private void probarImpresiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.log("Imprimiendo texto de prueba");
            webBrowser1.DocumentText = "Test de impresion";
        }

        private void restaurarValoresPorDefectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.resetDefaultValues();
        }

        public void resetDefaultValues()
        {
            this.log("Restaurando valores por defecto");

            textBox_port.Text = Server.DEFAULT_PORT.ToString();

            textBox_webHost.Text = Form1.WEB_HOST;
            textBox_webPort.Text = Form1.WEB_PORT;
            textBox_webEndpoint.Text = Form1.WEB_ENDPOINT;
            checkBox_webHttps.Checked = Form1.WEB_HTTPS;

            textBox_dbHost.Text = DatabaseConnection.HOST;
            textBox_dbUser.Text = DatabaseConnection.USER;
            textBox_dbPassword.Text = DatabaseConnection.PASSWORD;
            textBox_dbName.Text = DatabaseConnection.DATABASE;
        }

        private void importSettings()
        {
            this.log("Importando configuración");
            textBox_port.Text = this.settings.getValue("server", "port");

            textBox_webHost.Text = this.settings.getValue("web", "host");
            textBox_webPort.Text = this.settings.getValue("web", "port");
            textBox_webEndpoint.Text = this.settings.getValue("web", "endpoint");
            checkBox_webHttps.Checked = Convert.ToBoolean(this.settings.getValue("web", "https"));

            textBox_dbHost.Text = this.settings.getValue("database", "host");
            textBox_dbUser.Text = this.settings.getValue("database", "user");
            textBox_dbPassword.Text = this.settings.getValue("database", "password");
            textBox_dbName.Text = this.settings.getValue("database", "name");

            this.log("Configuración importada con éxito");
        }

        private void cargarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.settings.load();
            this.importSettings();
        }

        private void guardarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.log("Guardando configuración...");
            SettingNode server = new SettingNode("server");
            server.addAttribute("host", textBox_port.Text);

            SettingNode web = new SettingNode("web");
            web.addAttribute("host", textBox_webHost.Text);
            web.addAttribute("port", textBox_webPort.Text);
            web.addAttribute("endpoint", textBox_webEndpoint.Text);
            web.addAttribute("https", checkBox_webHttps.Checked.ToString());

            SettingNode database = new SettingNode("database");
            database.addAttribute("host", textBox_dbHost.Text);
            database.addAttribute("user", textBox_dbUser.Text);
            database.addAttribute("password", textBox_dbPassword.Text);
            database.addAttribute("name", textBox_dbName.Text);

            SettingNode[] st = {
                server, web, database
            };

            this.settings.save(st);
            this.log("Configuración guardada con éxito");
            MessageBox.Show("Configuración guardada con éxito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
