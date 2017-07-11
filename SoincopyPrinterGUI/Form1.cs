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
        private Server server;
        private DatabaseConnection dbc;

        public Form1()
        {
            InitializeComponent();

            this.dbc = new DatabaseConnection();
            this.dbc.connect();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Guevo");
            server = new Server(textBox_host.Text, Convert.ToInt32(textBox_port.Text));
            server.init();
            //server.run();
            bgw_server.DoWork += Bgw_server_DoWork;
            bgw_server.RunWorkerAsync();
        }

        private void Bgw_server_DoWork(object sender, DoWorkEventArgs e)
        {
            server.run();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.dbc.prepare("select * from Pago_Pedido where id=" + factura);

            if (server != null)
            {
                if (server.ultimaFactura > -1)
                {
                    int _ultimaFactura = server.ultimaFactura;
                    server.ultimaFactura = -1;
                    //MessageBox.Show("Factura #" + _ultimaFactura);

                    webBrowser1.DocumentText = Server.getHtmlFrom("http://localhost/soincopy/factura/" + _ultimaFactura);
                }

                if (server.isRunning())
                {
                    button_start.Text = "Corriendo";
                    button_start.Enabled = false;
                    textBox_host.Enabled = false;
                    textBox_port.Enabled = false;
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Print();
        }
    }
}
