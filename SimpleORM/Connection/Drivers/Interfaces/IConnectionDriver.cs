using SimpleORM.Connection.Parameters;

namespace SimpleORM.Connection.Drivers.Interfaces
{
    interface IConnectionDriver
    {
        bool Connect(ConnectionParameters parameters);
        

    }
}
