using ConvORM.Connection.Classes;
using ConvORM.Connection.Classes.QueryBuilders;
using ConvORM.Connection.Enums;
using ConvORM.Repository;
using System;
using System.Collections;

namespace ConvORM.Connection.DataTransferor.Interfaces
{
    class SqlServerDataTransferor : IDataTransfer
    {
        private readonly ModelEntity _modelEntity;
        private readonly Connection _connection;

        public SqlServerDataTransferor(ModelEntity modelEntity, Connection connection)
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
            var commandBuilder = new CommandFactory(_modelEntity, EConnectionDriverTypes.ecdtSQLServer);

            if (_connection.ConnectionDriver()
                .ExecuteCommand(commandBuilder.GetSqlInsert(out var parametersValues), parametersValues) > 0)
            {
                var lastInsertedId = _connection.ConnectionDriver().GetLastInsertedId();
                var conditionsBuilder = new QueryConditionsBuilder();
                foreach (var column in _modelEntity.GetPrimaryFields())
                {

                    conditionsBuilder.AddQueryCondition(column.ColumnName, EConditionTypes.Equals,
                        new object[] { lastInsertedId });
                }

                return _connection.ConnectionDriver().ExecuteScalarQuery(commandBuilder.GetSqlSelect(conditionsBuilder),
                    _modelEntity.EntityType);
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

        public IList FindAll()
        {
            return _connection.ConnectionDriver()
                .ExecuteQuery(new CommandFactory(_modelEntity, EConnectionDriverTypes.ecdtSQLServer).GetSqlSelect(new QueryConditionsBuilder()),
                    _modelEntity.EntityType);
        }

        public IList Find(QueryConditionsBuilder conditionsBuilder)
        {
            return _connection.ConnectionDriver()
                .ExecuteQuery(new CommandFactory(_modelEntity, EConnectionDriverTypes.ecdtSQLServer).GetSqlSelect(conditionsBuilder),
                    _modelEntity.EntityType);
        }

        public Entity Find(int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
