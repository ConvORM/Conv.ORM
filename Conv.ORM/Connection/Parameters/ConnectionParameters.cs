using ConvORM.Connection.Enums;

namespace ConvORM.Connection.Parameters
{
    public class ConnectionParameters
    {
        public string Name { get; set; }
        public EConnectionDriverTypes ConnectionDriverType { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
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
