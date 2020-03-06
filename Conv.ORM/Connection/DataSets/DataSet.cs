using ConvORM.Connection.Classes;
using ConvORM.Repository;
using System;
using System.Collections.Generic;

namespace ConvORM.Connection.DataSets
{
    public class DataSet
    {
        private Entity _entity;
        private Connection _connection;
        private ModelEntity modelEntity;

        public DataSet(Entity entity)
        {
            _entity = entity;

            ConvertModelEntity();

            _connection = ConnectionFactory.GetConnection(modelEntity.ConnectionName);
        }

        public DataSet(Entity entity, Connection connection)
        {
            _entity = entity;
            _connection = connection;

            ConvertModelEntity();
        }

        public static Entity Delete(Entity entity)
        {
            throw new NotImplementedException();
        }

        public static Entity Delete(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        public static Entity Insert(Entity entity)
        {
            DataSet dataSet = new DataSet(entity);
            return dataSet.ExecuteInsert(entity);
        }

        public static Entity Insert(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        public static Entity SetDeleted(Entity entity)
        {
            throw new NotImplementedException();
        }

        public static Entity SetDeleted(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        public static Entity Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public static Entity Update(Entity entity, Connection connection)
        {
            throw new NotImplementedException();
        }

        //private methods
        private void ConvertModelEntity()
        {
            modelEntity = Converter.EntityToModelEntity(_entity);
        }


        private Entity ExecuteInsert(Entity entity)
        {
            CommandBuilder commandBuilder = new CommandBuilder(modelEntity);
            commandBuilder.GetSqlInsert(out Dictionary<string, object> parametersValues);

        }
    }
}
