using ConvORM.Connection.Classes;
using ConvORM.Connection.DataSets;
using ConvORM.Connection.DataTransferor;

namespace ConvORM.Repository
{
    public class Repository
    {
        public Entity Insert(Entity entity)
        {
            return DataTransferorFactory.GetDataTransferor(Converter.EntityToModelEntity(entity)).Insert();
        }
    }
}
