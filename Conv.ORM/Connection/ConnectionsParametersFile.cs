using ConvORM.Connection.Enums;
using ConvORM.Connection.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConvORM.Connection
{
    internal class ConnectionsParametersFile
    {
        private ConnectionsParameters Connections;
        internal ConnectionsParametersFile()
        {
            string path = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
            path += @"\connection.xml";

            //Log in debug mode;
            #if DEBUG
                Console.WriteLine("File path: " + path);
            #endif

            StreamReader xmlFile;

            try
            {
                xmlFile = new StreamReader(path);
                LoadConnectionParametersFromFile(xmlFile);

            }
            catch (Exception e)
            {
                #if DEBUG
                    Console.WriteLine("Erro in open the connection file: " + e.Message);
#endif

                xmlFile = null;
            }
        }

        private void LoadConnectionParametersFromFile(StreamReader xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionsParameters));

            try
            {
                Connections = serializer.Deserialize(xmlFile) as ConnectionsParameters;
            }
            catch (InvalidOperationException ex)
            {
                #if DEBUG
                    Console.WriteLine("Erro in open the connection file: " + ex.Message);
                #endif
            }
            finally
            {
                xmlFile.Close();
            }
        }

        internal ConnectionParameters GetFirstConnectionParameter()
        {
            if (Connections.Connections.Count == 0)
                return null;
            else
                return Connections.Connections[0];
        }

        internal ConnectionParameters GetConnectionParameters(string name)
        {
            if (Connections.Connections.Count == 0)
                return null;
            else
                return LocateConnectionParameters(name);
        }

        internal ConnectionParameters GetConnectionParameters(EConnectionDriverTypes type)
        {
            if (Connections.Connections.Count == 0)
                return null;
            else
                return LocateConnectionParameters(type);
        }

        private ConnectionParameters LocateConnectionParameters(string name)
        {
            foreach (ConnectionParameters parameters in Connections.Connections)
            {
                if (parameters.Name == name)
                return parameters;                
            }

            return null;
        }

        private ConnectionParameters LocateConnectionParameters(EConnectionDriverTypes type)
        {
            foreach (ConnectionParameters parameters in Connections.Connections)
            {
                if (parameters.ConnectionDriverType == type)
                    return parameters;                
            }

            return null;
        }
    }
}
