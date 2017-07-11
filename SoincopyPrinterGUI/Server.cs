using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SoincopyPrinterGUI
{
    class Server
    {
        public static int DEFAULT_PORT = 6666;

        private string host;
        private int port;
        private HttpListener listener;
        private DatabaseConnection dbc;
        public int ultimaFactura = -1;
        private bool _isRunning;

        public Server(string host)
        {
            this.host = host;
            this.port = Server.DEFAULT_PORT;
        }

        public Server(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void init()
        {
            this._isRunning = false;

            Debug.WriteLine("Connecting to database..");
            this.dbc = new DatabaseConnection();
            this.dbc.connect();

            Debug.WriteLine("Connected to database.");

            Debug.WriteLine("Initializing server on port " + this.port);

            try
            {
                this.listener = new HttpListener();
                this.listener.Prefixes.Add("http://" + this.host + ":" + this.port + "/");
                this.listener.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        
        public void run()
        {
            this._isRunning = true;

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string url = context.Request.RawUrl;
                Regex regex = new Regex(@"/\?factura=(\d+)");
                Match m = regex.Match(url);

                string responseString = string.Empty;

                if (m.Success)
                {
                    int factura = Convert.ToInt32(m.Groups[1].ToString());
                    this.ultimaFactura = factura;
                    Debug.WriteLine("La factura es la #" + factura);
                    responseString = "Imprimiendo factura #" + factura;

                    try
                    {
                        this.dbc.prepare("select * from Pago_Pedido where id=" + factura);
                        double totalFactura = Convert.ToDouble(this.dbc.getFieldResult("total"));
                        //Debug.WriteLine("El monto total de la factura #" + factura + " fue de Bs. " + totalFactura);
                    }
                    catch (Exception ex)
                    {
                        responseString = "Ha ocurrido un error. (" + ex.Message + ")";
                    }
                }
                else
                {
                    responseString = "Error, debe especificar un numero de factura";
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }
        }

        public void stop()
        {
            listener.Stop();
        }

        public bool isRunning()
        {
            return this._isRunning;
        }

        public static string getHtmlFrom(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                return readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return string.Empty;
        }
    }
}
