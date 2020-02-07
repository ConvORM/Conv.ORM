using ConvORM.Connection.Parameters;

namespace ConvORM.Connection.Drivers.Interfaces
{
    interface IConnectionDriver
    {
        bool Connect(ConnectionParameters parameters);
        

    }
}
