using SimpleORM.Connection.Drivers;
using SimpleORM.Connection.Drivers.Interfaces;
using SimpleORM.Connection.Enums;
using SimpleORM.Connection.Parameters;

namespace SimpleORM.Connection
{
    public class Connection
    {
        //Fields

        //Propertys
        public EConnectionDriverTypes ConnectionDriverType { get; set; }
        public ConnectionParameters Parameters { get; set; }

        private IConnectionDriver ConnectionDriver;

        public bool Connect()
        {
            if (ConnectionDriver == null)
            {
                LoadConnectionDriver();
            }

            return ConnectionDriver.Connect(Parameters);
        }

        private void LoadConnectionDriver()
        {
            switch (ConnectionDriverType)
            {
                case EConnectionDriverTypes.ecdtFirebird:
                    ConnectionDriver = (IConnectionDriver) new FirebirdConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtMySql:
                    ConnectionDriver = (IConnectionDriver) new MySqlConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtPostgreeSQL:
                    ConnectionDriver = (IConnectionDriver) new PostgreeSQLConnectionDriver();
                    break;
                case EConnectionDriverTypes.ecdtSQLServer:
                    ConnectionDriver = (IConnectionDriver) new SQLServerConnectionDriver();
                    break;
                default:
                    ConnectionDriver = null;
                    break;
            }
        }

    }
}
