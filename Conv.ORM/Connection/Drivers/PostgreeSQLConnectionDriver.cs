using System;
using System.Collections.Generic;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Parameters;
using ConvORM.Repository;

namespace ConvORM.Connection.Drivers
{
    class PostgreeSqlConnectionDriver : IConnectionDriver
    {
        public bool Connect(ConnectionParameters parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sql, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public Entity ExecuteQuery(string sql, Type entityType)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedId()
        {
            throw new NotImplementedException();
        }
    }
}
