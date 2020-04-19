using ConvORM.Connection.Classes;
using ConvORM.Repository;
using System;

namespace ConvORM.Connection.DataSets
{
    public class DataSet
    {
        private readonly Entity _entity;
        private readonly Connection _connection;
        private ModelEntity _modelEntity;

        private DataSet(Entity entity)
        {
            _entity = entity;

            ConvertModelEntity();

            _connection = ConnectionFactory.GetConnection(_modelEntity.ConnectionName);
        }

        public DataSet(Entity entity, Connection connection)
        {
            _entity = entity;
            _connection = connection;

            ConvertModelEntity();
        }

        Entity Delete(Entity entity)
        {
            throw new NotImplementedException();
        }

        Entity Delete(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        Entity Insert(Entity entity)
        {
            var dataSet = new DataSet(entity);
            return dataSet.ExecuteInsert(entity);
        }

        Entity Insert(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        Entity SetDeleted(Entity entity)
        {
            throw new NotImplementedException();
        }

        Entity SetDeleted(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        Entity Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        Entity Update(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        //private methods
        private void ConvertModelEntity()
        {
            _modelEntity = Converter.EntityToModelEntity(_entity);
        }


        private Entity ExecuteInsert(Entity entity)
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
                return _connection.ConnectionDriver().ExecuteQuery(commandBuilder.GetSqlSelect(conditionsBuilder), entity.GetType());
            }
            else
                return null;           

        }
    }
}
