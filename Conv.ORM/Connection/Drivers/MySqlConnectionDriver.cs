using ConvORM.Connection.Classes;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Helpers;
using ConvORM.Connection.Parameters;
using ConvORM.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvORM.Connection.Drivers
{
    class MySqlConnectionDriver : IConnectionDriver
    {
        private MySqlConnection Connection;
        private MySqlConnectionDriverHelper helper;

        public MySqlConnectionDriver()
        {
            helper = new MySqlConnectionDriverHelper();
        }


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

        public int ExecuteCommand(string sql)
        {
            throw new System.NotImplementedException();
        }

        public int ExecuteCommand(string sql, Dictionary<string, object> parameters)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandText = sql
            };

            #if DEBUG
                Console.WriteLine("Query: " + sql);
            #endif

            MySqlCommand lastId;
            MySqlDataReader lid = null;
            lastId = new MySqlCommand();
            lastId.Connection = Connection;
            lastId.CommandText = ("SELECT LAST_INSERT_ID()");

            foreach (string key in parameters.Keys)
            {
                command.Parameters.AddWithValue(key, parameters[key]);
            }

            command.Connection = Connection;

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                lid = lastId.ExecuteReader(CommandBehavior.CloseConnection);
                Connection.Close();

                return lid.GetInt32(0);
            }
            catch (Exception e)
            {
                #if DEBUG
                    Console.WriteLine("Erro: " + e.Message);
                #endif
                return 0;
            }
        }

        public Entity ExecuteQuery(string sql, Type entityType)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandText = sql
            };

            #if DEBUG
            Console.WriteLine("Query: " + sql);
            #endif

            command.Connection = Connection;

            try
            {
                Connection.Open();
                MySqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return helper.ConvertReaderToEntity(reader, entityType);
            }
            catch (Exception e)
            {
                #if DEBUG
                Console.WriteLine("Erro: " + e.Message);
                #endif
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public Entity Insert(Entity entity)
        {
            ModelEntity modelEntity = Converter.EntityToModelEntity(entity);
            throw new System.NotImplementedException();
        }

        private string GenerateConnectionString(ConnectionParameters parameters)
        {
            return "Server=" + parameters.Host + ";Port=" + parameters.Port + ";Database=" + parameters.Database + ";Uid=" + parameters.User + ";Pwd = " + parameters.Password + ";";
        }

    }
}
