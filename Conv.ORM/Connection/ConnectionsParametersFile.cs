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
        private List<ConnectionParameters> ConnectionParametersList;
        internal ConnectionsParametersFile()
        {
            string path = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
            path += @"\connection.xml";

            //Log in debug mode;
            #if DEBUG
                Console.WriteLine("File path: " + path);
            #endif

            FileStream fs;

            try
            {
                fs  = new FileStream(path, FileMode.Open);
                LoadConnectionParametersFromFile(fs);

            }
            catch (Exception e)
            {
                #if DEBUG
                    Console.WriteLine("Erro in open the connection file: " + e.Message);
                #endif

                fs = null;
            }
        }

        private void LoadConnectionParametersFromFile(FileStream fs)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ConnectionParameters>));

            try
            {
                ConnectionParametersList = serializer.Deserialize(fs) as List<ConnectionParameters>;
            }
            catch (InvalidOperationException ex)
            {
                serializer.Serialize(fs, this.ConnectionParametersList);
            }
            finally
            {
                fs.Close();
            }
        }

        internal ConnectionParameters GetFirstConnectionParameter()
        {
            if (ConnectionParametersList.Count == 0)
                return null;
            else
                return ConnectionParametersList[0];
        }

        internal ConnectionParameters GetConnectionParameters(string name)
        {
            if (ConnectionParametersList.Count == 0)
                return null;
            else
                return LocateConnectionParameters(name);
        }

        internal ConnectionParameters GetConnectionParameters(EConnectionDriverTypes type)
        {
            if (ConnectionParametersList.Count == 0)
                return null;
            else
                return LocateConnectionParameters(type);
        }

        private ConnectionParameters LocateConnectionParameters(string name)
        {
            foreach (ConnectionParameters parameters in ConnectionParametersList)
            {
                if (parameters.Name == name)
                return parameters;                
            }

            return null;
        }

        private ConnectionParameters LocateConnectionParameters(EConnectionDriverTypes type)
        {
            foreach (ConnectionParameters parameters in ConnectionParametersList)
            {
                if (parameters.ConnectionDriverType == type)
                    return parameters;                
            }

            return null;
        }
    }
}
