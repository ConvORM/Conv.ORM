using ConvORM.Connection.Parameters;
using ConvORM.Repository;
using System;
using System.Collections.Generic;

namespace ConvORM.Connection.Drivers.Interfaces
{
    interface IConnectionDriver
    {
        bool Connect(ConnectionParameters parameters);
        int ExecuteCommand(string sql);
        int ExecuteCommand(string sql, Dictionary<string, object> parameters);
        Entity ExecuteQuery(string sql, Type entityType);


    }
}
