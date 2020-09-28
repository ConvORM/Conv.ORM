using ConvORM.Connection.Classes;
using ConvORM.Connection.DataTransferor;
using System.Collections;
using ConvORM.Connection.Classes.QueryBuilders;

namespace ConvORM.Repository
{
    public class Repository
    {
        public Entity Insert(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Insert();
        }

        public IList FindAll(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).FindAll();
        }

        public IList Find(Entity entity, QueryConditionsBuilder conditionsBuilder)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Find(conditionsBuilder);
        }

        public Entity Find(Entity entity, int[] ids)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Find(ids);
        }

        public Entity Update(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Update();
        }
    }
}
