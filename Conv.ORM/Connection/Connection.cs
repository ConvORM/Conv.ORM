using ConvORM.Connection.Drivers;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Enums;
using ConvORM.Connection.Parameters;

namespace ConvORM.Connection
{
    public class Connection
    {
        //Propertys
        public ConnectionParameters Parameters { get; private set; }
        public bool Connected { get; private set; }

        private IConnectionDriver _ConnectionDriver;

        public Connection(ConnectionParameters parameters)
        {
            Parameters = parameters;
        }

        internal IConnectionDriver ConnectionDriver()
        {
            return _ConnectionDriver;
        }

        public Connection GetConnection()
        {
            if (_ConnectionDriver == null)
            {
                LoadConnectionDriver();
            }
               
            Connected = _ConnectionDriver.Connect(Parameters);

            if (Connected)
                ConnectionFactory.AddConnection(this, "");

            return this;

        }

        private void LoadConnectionDriver()
        {
            switch (Parameters.ConnectionDriverType)
            {
                case EConnectionDriverTypes.ecdtFirebird:
                    _ConnectionDriver = (IConnectionDriver) new FirebirdConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtMySql:
                    _ConnectionDriver = new MySqlConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtPostgreeSQL:
                    _ConnectionDriver = (IConnectionDriver) new PostgreeSQLConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtSQLServer:
                    _ConnectionDriver = (IConnectionDriver) new SQLServerConnectionDriver();
                    break;
                default:
                    _ConnectionDriver = null;
                    break;
            }
        }

    }
}
