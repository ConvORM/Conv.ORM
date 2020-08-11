using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Parameters;
using ConvORM.Repository;

namespace ConvORM.Connection.Drivers
{
    class SqlServerConnectionDriver : IConnectionDriver
    {
        private SqlConnection _connection;

        private static string GenerateConnectionString(ConnectionParameters parameters)
        {
            if (parameters.UserIntegratedSecurity)
            {
                return "Server=" + parameters.Host + "," + parameters.Port + ";Database=" + parameters.Database + ";Trusted_Connection=True;";

            }
            else
            {
                return "Server=" + parameters.Host + "," + parameters.Port + ";Database=" + parameters.Database + ";User Id=" + parameters.User + ";Password = " + parameters.Password + ";";
            }
        }

        public bool Connect(ConnectionParameters parameters)
        {
            _connection = new SqlConnection(GenerateConnectionString(parameters));
            try
            {
                _connection.Open();
                _connection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            /*connection = new MySqlConnection(GenerateConnectionString(parameters));
            try
            {
                _connection.Open();
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ConnectionHelper.HandlerMySqlException(ex);
            }*/
        }

        public int ExecuteCommand(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sql, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public Entity ExecuteScalarQuery(string sql, Type entityType)
        {
            throw new NotImplementedException();
        }

        public IList ExecuteQuery(string sql, Type entityType)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedId()
        {
            throw new NotImplementedException();
        }
    }
}
