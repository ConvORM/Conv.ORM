using ConvORM.Connection.Parameters;
using ConvORM.Repository;
using System.Collections.Generic;
using System.Xml;

namespace ConvORM.Connection.Drivers.Interfaces
{
    interface IConnectionDriver
    {
        bool Connect(ConnectionParameters parameters);
        int ExecuteCommand(string sql);
        int ExecuteCommand(string sql, Dictionary<string, object> parameters);


    }
}
