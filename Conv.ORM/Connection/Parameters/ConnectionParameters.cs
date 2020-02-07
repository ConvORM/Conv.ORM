namespace ConvORM.Connection.Parameters
{
    public class ConnectionParameters
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public ConnectionParameters(string host, string port, string user, string password, string database)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
            Database = database;
        }

        public ConnectionParameters()
        {
            Host = "";
            Port = "";
            User = "";
            Password = "";
            Database = "";
        }
    }
}
