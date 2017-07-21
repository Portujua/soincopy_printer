using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SoincopyPrinterGUI
{
    class Settings
    {
        public static string DEFAULT_FILENAME = "settings.xml";

        private string filename;
        private XmlDocument config;

        public Settings()
        {
            this.filename = Settings.DEFAULT_FILENAME;
            this.init();
        }

        public Settings(string filename)
        {
            this.filename = filename;
            this.init();
        }

        private void init()
        {
            this.config = new XmlDocument();
        }

        public void load()
        {
            if (File.Exists(this.filename))
            {
                try
                {
                    this.config.LoadXml(File.ReadAllText(this.filename));
                }
                catch (XmlException ex)
                {
                    throw new XmlException(string.Concat("Error leyendo el archivo ", this.filename));
                }
            }
            else
            {
                this.createSettingsFile(null);
            }
        }

        public void createSettingsFile(SettingNode[] settings)
        {
            this.config = new XmlDocument();

            XmlNode root = this.config.CreateXmlDeclaration("1.0", "UTF-8", null);
            this.config.AppendChild(root);

            // Root node
            XmlNode rootNode = this.config.CreateElement("soincopy-printer");
            this.config.AppendChild(rootNode);

            // Server node
            XmlNode server = this.config.CreateElement("server");
            XmlAttribute serverPort = this.config.CreateAttribute("port");
            serverPort.Value = settings == null 
                ? Server.DEFAULT_PORT.ToString()
                : this.getValue(settings, "server", "host");
            server.Attributes.Append(serverPort);
            rootNode.AppendChild(server);

            // Web node
            XmlNode web = this.config.CreateElement("web");

            XmlAttribute webHost = this.config.CreateAttribute("host");
            webHost.Value = settings == null
                ? Form1.WEB_HOST
                : this.getValue(settings, "web", "host");
            web.Attributes.Append(webHost);

            XmlAttribute webPort = this.config.CreateAttribute("port");
            webPort.Value = settings == null
                ? Form1.WEB_PORT
                : this.getValue(settings, "web", "port");
            web.Attributes.Append(webPort);

            XmlAttribute webEndpoint = this.config.CreateAttribute("endpoint");
            webEndpoint.Value = settings == null
                ? Form1.WEB_ENDPOINT
                : this.getValue(settings, "web", "endpoint");
            web.Attributes.Append(webEndpoint);

            XmlAttribute webHttps = this.config.CreateAttribute("https");
            webHttps.Value = settings == null
                ? Form1.WEB_HTTPS.ToString()
                : this.getValue(settings, "web", "https");
            web.Attributes.Append(webHttps);

            rootNode.AppendChild(web);

            // DB node
            XmlNode database = this.config.CreateElement("database");

            XmlAttribute databaseHost = this.config.CreateAttribute("host");
            databaseHost.Value = settings == null
                ? DatabaseConnection.HOST
                : this.getValue(settings, "database", "host");
            database.Attributes.Append(databaseHost);

            XmlAttribute databaseUser = this.config.CreateAttribute("user");
            databaseUser.Value = settings == null
                ? DatabaseConnection.USER
                : this.getValue(settings, "database", "user");
            database.Attributes.Append(databaseUser);

            XmlAttribute databasePassword = this.config.CreateAttribute("password");
            databasePassword.Value = settings == null
                ? DatabaseConnection.PASSWORD
                : this.getValue(settings, "database", "password");
            database.Attributes.Append(databasePassword);

            XmlAttribute databaseName = this.config.CreateAttribute("name");
            databaseName.Value = settings == null
                ? DatabaseConnection.DATABASE
                : this.getValue(settings, "database", "name");
            database.Attributes.Append(databaseName);

            rootNode.AppendChild(database);


            this.config.Save(this.filename);
        }

        public string getValue(string node, string attribute)
        {
            foreach (XmlNode n in this.config.GetElementsByTagName(node))
            {
                foreach (XmlAttribute a in n.Attributes)
                {
                    if (a.Name.Equals(attribute))
                    {
                        return a.Value;
                    }
                }
            }

            return String.Empty;
        }

        public string getValue(SettingNode[] settings, string node, string attribute)
        {
            foreach (SettingNode sn in settings)
            {
                if (sn.getName().Equals(node))
                {
                    return sn.getValue(attribute);
                }
            }

            return String.Empty;
        }

        public void save(SettingNode[] settings)
        {
            this.createSettingsFile(settings);
        }
    }

    class SettingNode
    {
        private string name;
        private List<SettingNodeAttribute> attributes;

        public SettingNode(string name)
        {
            this.name = name;
            this.attributes = new List<SettingNodeAttribute>();
        }

        public string getName()
        {
            return this.name;
        }

        public List<SettingNodeAttribute> getAttributes()
        {
            return this.attributes;
        }

        public void addAttribute(SettingNodeAttribute sna)
        {
            this.attributes.Add(sna);
        }

        public void addAttribute(string name, string value)
        {
            this.attributes.Add(new SettingNodeAttribute(name, value));
        }

        public string getValue(string attribute)
        {
            foreach (SettingNodeAttribute sna in this.attributes)
            {
                if (sna.getName().Equals(attribute))
                {
                    return sna.getValue();
                }
            }

            return String.Empty;
        }
    }

    class SettingNodeAttribute
    {
        private string name;
        private string value;

        public SettingNodeAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string getName()
        {
            return this.name;
        }

        public string getValue()
        {
            return this.value;
        }
    }
}
