using ConvORM.Connection.Classes;
using ConvORM.Connection.DataTransferor;
using System.Collections;

namespace ConvORM.Repository
{
    public class Repository
    {
        public Entity Insert(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Insert();
        }

        public IList GetAll(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).GetAll();
        }
    }
}
