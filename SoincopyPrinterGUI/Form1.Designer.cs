namespace SoincopyPrinterGUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.bgw_server = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Servidor = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_webHttps = new System.Windows.Forms.CheckBox();
            this.textBox_webEndpoint = new System.Windows.Forms.TextBox();
            this.textBox_webPort = new System.Windows.Forms.TextBox();
            this.textBox_webHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.probarImpresiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarValoresPorDefectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_dbHost = new System.Windows.Forms.TextBox();
            this.textBox_dbUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_dbPassword = new System.Windows.Forms.TextBox();
            this.textBox_dbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cargarConfiguraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarConfiguraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.Servidor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // textBox_port
            // 
            this.textBox_port.AutoCompleteCustomSource.AddRange(new string[] {
            "6666"});
            this.textBox_port.Location = new System.Drawing.Point(53, 6);
            this.textBox_port.MaxLength = 4;
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(72, 20);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBox_port, resources.GetString("textBox_port.ToolTip"));
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(15, 150);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(336, 23);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Iniciar";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(570, 345);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Servidor);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(340, 121);
            this.tabControl1.TabIndex = 6;
            // 
            // Servidor
            // 
            this.Servidor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Servidor.Controls.Add(this.textBox_port);
            this.Servidor.Controls.Add(this.label2);
            this.Servidor.Location = new System.Drawing.Point(4, 22);
            this.Servidor.Name = "Servidor";
            this.Servidor.Padding = new System.Windows.Forms.Padding(3);
            this.Servidor.Size = new System.Drawing.Size(332, 95);
            this.Servidor.TabIndex = 0;
            this.Servidor.Text = "Servidor";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.checkBox_webHttps);
            this.tabPage1.Controls.Add(this.textBox_webEndpoint);
            this.tabPage1.Controls.Add(this.textBox_webPort);
            this.tabPage1.Controls.Add(this.textBox_webHost);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(332, 95);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Web";
            // 
            // checkBox_webHttps
            // 
            this.checkBox_webHttps.AutoSize = true;
            this.checkBox_webHttps.Location = new System.Drawing.Point(267, 6);
            this.checkBox_webHttps.Name = "checkBox_webHttps";
            this.checkBox_webHttps.Size = new System.Drawing.Size(62, 17);
            this.checkBox_webHttps.TabIndex = 6;
            this.checkBox_webHttps.Text = "HTTPS";
            this.toolTip1.SetToolTip(this.checkBox_webHttps, "El protocolo usado por el servidor web.");
            this.checkBox_webHttps.UseVisualStyleBackColor = true;
            // 
            // textBox_webEndpoint
            // 
            this.textBox_webEndpoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_webEndpoint.Location = new System.Drawing.Point(68, 47);
            this.textBox_webEndpoint.Name = "textBox_webEndpoint";
            this.textBox_webEndpoint.Size = new System.Drawing.Size(142, 20);
            this.textBox_webEndpoint.TabIndex = 5;
            this.textBox_webEndpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBox_webEndpoint, "El complemento del URL para acceder a la vista de una factura.");
            // 
            // textBox_webPort
            // 
            this.textBox_webPort.Location = new System.Drawing.Point(68, 27);
            this.textBox_webPort.Name = "textBox_webPort";
            this.textBox_webPort.Size = new System.Drawing.Size(142, 20);
            this.textBox_webPort.TabIndex = 4;
            this.textBox_webPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBox_webPort, "El puerto del host donde se encuentra el servidor web. En caso de ser vacío se as" +
        "ume el puerto 80.\r\n\r\nValor por defecto: vacío");
            // 
            // textBox_webHost
            // 
            this.textBox_webHost.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_webHost.Location = new System.Drawing.Point(68, 7);
            this.textBox_webHost.Name = "textBox_webHost";
            this.textBox_webHost.Size = new System.Drawing.Size(142, 20);
            this.textBox_webHost.TabIndex = 3;
            this.textBox_webHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBox_webHost, "La dirección del host donde se encuentra el servidor web.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Endpoint";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Puerto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.textBox_log);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(332, 95);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consola";
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_log.Location = new System.Drawing.Point(0, 0);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(335, 99);
            this.textBox_log.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarConfiguraciónToolStripMenuItem,
            this.guardarConfiguraciónToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.probarImpresiónToolStripMenuItem,
            this.restaurarValoresPorDefectoToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // probarImpresiónToolStripMenuItem
            // 
            this.probarImpresiónToolStripMenuItem.Name = "probarImpresiónToolStripMenuItem";
            this.probarImpresiónToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.probarImpresiónToolStripMenuItem.Text = "Probar impresión";
            this.probarImpresiónToolStripMenuItem.ToolTipText = "Imprime la factura con el ID especificado de prueba.";
            this.probarImpresiónToolStripMenuItem.Click += new System.EventHandler(this.probarImpresiónToolStripMenuItem_Click);
            // 
            // restaurarValoresPorDefectoToolStripMenuItem
            // 
            this.restaurarValoresPorDefectoToolStripMenuItem.Name = "restaurarValoresPorDefectoToolStripMenuItem";
            this.restaurarValoresPorDefectoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.restaurarValoresPorDefectoToolStripMenuItem.Text = "Restaurar valores por defecto";
            this.restaurarValoresPorDefectoToolStripMenuItem.Click += new System.EventHandler(this.restaurarValoresPorDefectoToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBox_dbName);
            this.tabPage3.Controls.Add(this.textBox_dbPassword);
            this.tabPage3.Controls.Add(this.textBox_dbUser);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox_dbHost);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(332, 95);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Base de Datos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Host";
            // 
            // textBox_dbHost
            // 
            this.textBox_dbHost.Location = new System.Drawing.Point(95, 7);
            this.textBox_dbHost.Name = "textBox_dbHost";
            this.textBox_dbHost.Size = new System.Drawing.Size(222, 20);
            this.textBox_dbHost.TabIndex = 1;
            this.textBox_dbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_dbUser
            // 
            this.textBox_dbUser.Location = new System.Drawing.Point(95, 28);
            this.textBox_dbUser.Name = "textBox_dbUser";
            this.textBox_dbUser.Size = new System.Drawing.Size(222, 20);
            this.textBox_dbUser.TabIndex = 3;
            this.textBox_dbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Usuario";
            // 
            // textBox_dbPassword
            // 
            this.textBox_dbPassword.Location = new System.Drawing.Point(95, 49);
            this.textBox_dbPassword.Name = "textBox_dbPassword";
            this.textBox_dbPassword.Size = new System.Drawing.Size(222, 20);
            this.textBox_dbPassword.TabIndex = 4;
            this.textBox_dbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_dbPassword.UseSystemPasswordChar = true;
            // 
            // textBox_dbName
            // 
            this.textBox_dbName.Location = new System.Drawing.Point(95, 70);
            this.textBox_dbName.Name = "textBox_dbName";
            this.textBox_dbName.Size = new System.Drawing.Size(222, 20);
            this.textBox_dbName.TabIndex = 5;
            this.textBox_dbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Base de Datos";
            // 
            // cargarConfiguraciónToolStripMenuItem
            // 
            this.cargarConfiguraciónToolStripMenuItem.Name = "cargarConfiguraciónToolStripMenuItem";
            this.cargarConfiguraciónToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cargarConfiguraciónToolStripMenuItem.Text = "Cargar configuración";
            this.cargarConfiguraciónToolStripMenuItem.Click += new System.EventHandler(this.cargarConfiguraciónToolStripMenuItem_Click);
            // 
            // guardarConfiguraciónToolStripMenuItem
            // 
            this.guardarConfiguraciónToolStripMenuItem.Name = "guardarConfiguraciónToolStripMenuItem";
            this.guardarConfiguraciónToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.guardarConfiguraciónToolStripMenuItem.Text = "Guardar configuración";
            this.guardarConfiguraciónToolStripMenuItem.Click += new System.EventHandler(this.guardarConfiguraciónToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 182);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SACC v2 Printer";
            this.tabControl1.ResumeLayout(false);
            this.Servidor.ResumeLayout(false);
            this.Servidor.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_start;
        private System.ComponentModel.BackgroundWorker bgw_server;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Servidor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_webEndpoint;
        private System.Windows.Forms.TextBox textBox_webPort;
        private System.Windows.Forms.TextBox textBox_webHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_webHttps;
        public System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem probarImpresiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarValoresPorDefectoToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_dbName;
        private System.Windows.Forms.TextBox textBox_dbPassword;
        private System.Windows.Forms.TextBox textBox_dbUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_dbHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem cargarConfiguraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarConfiguraciónToolStripMenuItem;
    }
}

