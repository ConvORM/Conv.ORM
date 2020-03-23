using ConvORM.Connection.DataSets;

namespace ConvORM.Repository
{
    public class Repository
    {
        private Entity _entity;

        public Entity Insert(Entity entity)
        {
            return DataSet.Insert(entity);
        }
    }
}
