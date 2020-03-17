using ConvORM.Connection.Enums;
using System.Xml.Serialization;

namespace ConvORM.Connection.Parameters
{
    public class ConnectionParameters
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("driver")]
        public EConnectionDriverTypes ConnectionDriverType { get; set; }
        [XmlElement("host")]
        public string Host { get; set; }
        [XmlElement("port")]
        public string Port { get; set; }
        [XmlElement("user")]
        public string User { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
        [XmlElement("database")]
        public string Database { get; set; }

        public ConnectionParameters(string name, EConnectionDriverTypes connectionDriverType, string host, string port, string user, string password, string database)
        {
            Name = name;
            ConnectionDriverType = connectionDriverType;
            Host = host;
            Port = port;
            User = user;
            Password = password;
            Database = database;
        }

        public ConnectionParameters()
        {
            Name = "Default";
            ConnectionDriverType = EConnectionDriverTypes.ecdtNone;
            Host = "";
            Port = "";
            User = "";
            Password = "";
            Database = "";
        }
    }
}
