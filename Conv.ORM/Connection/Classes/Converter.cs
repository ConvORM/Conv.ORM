using ConvORM.Connection.Helpers;
using ConvORM.Repository;

namespace ConvORM.Connection.Classes
{
    internal static class Converter
    {
        internal static ModelEntity EntityToModelEntity(Entity entity)
        {
            var helper = new ConverterModelEntityHelper(entity);
            var model = new ModelEntity
            {
                TableName = helper.GetTableName(), ColumnsModelEntity = helper.GetColumnsModelEntity(), EntityType = entity.GetType()
            };
            return model;
        }
    }
}
