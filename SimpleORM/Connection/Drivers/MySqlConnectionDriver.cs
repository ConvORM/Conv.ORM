using MySql.Data.MySqlClient;
using SimpleORM.Connection.Drivers.Interfaces;
using SimpleORM.Connection.Helpers;
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
                throw ConnectionHelper.HandlerMySQLException(ex);
            }
        }

        private string GenerateConnectionString(ConnectionParameters parameters)
        {
            return "Server=" + parameters.Host + ";Port=" + parameters.Port + ";Database=" + parameters.Database + ";Uid=" + parameters.User + ";Pwd = " + parameters.Password + ";";
        }
    }
}
