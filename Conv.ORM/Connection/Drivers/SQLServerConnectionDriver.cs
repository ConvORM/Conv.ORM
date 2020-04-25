using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Parameters;
using ConvORM.Repository;

namespace ConvORM.Connection.Drivers
{
    class SqlServerConnectionDriver : IConnectionDriver
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
