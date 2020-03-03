using ConvORM.Connection;
namespace ConvORM.Repository
{
    public class Repository
    {
        private Entity _Entity;
        private Connection.Connection _Connection;

        public Repository(Entity entity)
        {
            _Entity = entity;
        }

        public Repository(Entity entity, Connection.Connection connection)
        {
            _Entity = entity;
            _Connection = connection;
        }

        public Entity Insert(Entity entity)
        {
            
        }
    }
}
