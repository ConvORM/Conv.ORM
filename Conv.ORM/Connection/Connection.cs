using ConvORM.Connection.Drivers;
using ConvORM.Connection.Drivers.Interfaces;
using ConvORM.Connection.Enums;
using ConvORM.Connection.Parameters;

namespace ConvORM.Connection
{
    public class Connection
    {
        public ConnectionParameters Parameters { get; private set; }
        private bool Connected { get; set; }

        private IConnectionDriver _connectionDriver;

        public Connection(ConnectionParameters parameters)
        {
            Parameters = parameters;
        }

        internal IConnectionDriver ConnectionDriver()
        {
            return _connectionDriver;
        }

        public Connection GetConnection()
        {
            if (_connectionDriver == null)
            {
                LoadConnectionDriver();
            }
               
            Connected = _connectionDriver.Connect(Parameters);

            if (Connected)
                ConnectionFactory.AddConnection(this, "");

            return this;

        }

        private void LoadConnectionDriver()
        {
            switch (Parameters.ConnectionDriverType)
            {
                case EConnectionDriverTypes.ecdtFirebird:
                    _connectionDriver = new FirebirdConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtMySql:
                    _connectionDriver = new MySqlConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtPostgreeSQL:
                    _connectionDriver = new PostgreeSqlConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtSQLServer:
                    _connectionDriver = new SqlServerConnectionDriver();
                    break;
                default:
                    _connectionDriver = null;
                    break;
            }
        }

    }
}
