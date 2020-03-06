using ConvORM.Connection.DataSets;

namespace ConvORM.Repository
{
    public class Repository
    {
        private Entity _Entity;

        public Entity Insert(Entity entity)
        {
            return DataSet.Insert(entity);
        }
    }
}
