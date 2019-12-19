using MySql.Data.MySqlClient;
using SimpleORM.Connection.Drivers.Interfaces;
using SimpleORM.Connection.Parameters;
using SimpleORM.Exceptions;
using System;

namespace SimpleORM.Connection.Drivers
{
    class MySqlConnectionDriver : IConnectionDriver
    {
        private MySqlConnection Connection;
        public bool Connect(ConnectionParameters parameters)
        {
            Connection = new MySqlConnection(GenerateConnectionString(parameters));
            try
            {
                Connection.Open();
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw new ConnectionException(Convert.ToString(ex.ErrorCode), ex.Message);
            }
        }

        private string GenerateConnectionString(ConnectionParameters parameters)
        {
            return "Server=" + parameters.Host + ";Port=" + parameters.Port + ";Database=" + parameters.Database + ";Uid=" + parameters.User + ";Pwd = " + parameters.Password + ";";
        }
    }
}
