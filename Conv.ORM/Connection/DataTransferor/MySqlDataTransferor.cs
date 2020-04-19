using ConvORM.Connection.Classes;
using ConvORM.Connection.DataTransferor.Interfaces;
using ConvORM.Repository;

namespace ConvORM.Connection.DataTransferor
{
    internal class MySqlDataTransferor: IDataTransfer
    {
        private readonly ModelEntity _modelEntity;
        private readonly Connection _connection;

        public MySqlDataTransferor(ModelEntity modelEntity, Connection connection)
        {
            _modelEntity = modelEntity;
            _connection = connection;
        }

        public Entity Delete()
        {
            throw new System.NotImplementedException();
        }

        public Entity Insert()
        {
            var commandBuilder = new CommandBuilder(_modelEntity);

            if (_connection.ConnectionDriver().ExecuteCommand(commandBuilder.GetSqlInsert(out var parametersValues), parametersValues) > 0)
            {
                var lastInsertedId = _connection.ConnectionDriver().GetLastInsertedId();
                var conditionsBuilder = new QueryConditionsBuilder();
                foreach (var column in _modelEntity.GetPrimaryFields())
                {
                    conditionsBuilder.AddQueryCondition(column.ColumnName, Enums.EConditionTypes.Equals, lastInsertedId);
                }
                return _connection.ConnectionDriver().ExecuteQuery(commandBuilder.GetSqlSelect(conditionsBuilder), _modelEntity.EntityType);
            }
            else
                return null;
        }

        public Entity SetDeleted()
        {
            throw new System.NotImplementedException();
        }

        public Entity Update()
        {
            throw new System.NotImplementedException();
        }
        
    }
}