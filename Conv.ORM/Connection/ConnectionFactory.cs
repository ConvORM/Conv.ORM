using ConvORM.Connection.Enums;
using ConvORM.Connection.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace ConvORM.Connection
{
    public static class ConnectionFactory
    {
        static private Dictionary<string, Connection> Connections;
        static private ConnectionsParametersFile connectionsParametersFile;

        static internal void AddConnection(Connection connection, string name)
        {
            Connections.Add(name, connection);
        }

        static public Connection GetConnection()
        {
            Initialize();
            Connection connection = LocateConnection();

            if (connection == null)
            {
                ConnectionParameters parameters = connectionsParametersFile.GetFirstConnectionParameter();
                connection = GetNewConnection(parameters);
            }

            return connection;

        }

        static public Connection GetConnection(ConnectionParameters parameters)
        {
            Initialize();
            Connection connection = LocateConnection(parameters);

            return connection == null ? GetNewConnection(parameters) : connection;
  
        }

        static public Connection GetConnection(string name)
        {
            Initialize();
            if ((name == "") || (name == null))
            {
                return GetConnection();
            }
            else
            {
                Connection connection = LocateConnection(name);

                if (connection == null)
                {
                    ConnectionParameters parameters = connectionsParametersFile.GetConnectionParameters(name);
                    connection = GetNewConnection(parameters);
                }

                return connection;
            }
        }

        static public Connection GetConnection(EConnectionDriverTypes type)
        {
            {
                Initialize();
                Connection connection = LocateConnection(type);

                if (connection == null)
                {
                    ConnectionParameters parameters = connectionsParametersFile.GetConnectionParameters(type);
                    connection = GetNewConnection(parameters);
                }

                return connection;
            }
        }

        static private Connection GetNewConnection(ConnectionParameters parameters)
        {
            return new Connection(parameters).GetConnection();
        }

        static private Connection LocateConnection()
        {
            if (Connections.Count == 0)
                return null;
            else
            {
                string firstKey = Connections.Keys.First();
                return Connections[firstKey];
            }
        }

        static private Connection LocateConnection(ConnectionParameters parameters)
        {
            foreach (Connection connection in Connections.Values)
            {
                if (connection.Parameters == parameters)
                    return connection;
            }

            return null;
        }

        static private Connection LocateConnection(string name)
        {
            foreach (Connection connection in Connections.Values)
            {
                if (connection.Parameters.Name == name)
                    return connection;
            }

            return null;
        }

        static private Connection LocateConnection(EConnectionDriverTypes type)
        {
            foreach (Connection connection in Connections.Values)
            {
                if (connection.Parameters.ConnectionDriverType == type)
                    return connection;
            }

            return null;
        }


        static private void Initialize()
        {
            if (Connections == null)
            {
                Connections = new Dictionary<string, Connection>();
            }

            if (connectionsParametersFile == null)
                connectionsParametersFile = new ConnectionsParametersFile();
        }
            
    }
}
