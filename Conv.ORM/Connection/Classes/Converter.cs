using ConvORM.Connection.Helpers;
using ConvORM.Repository;

namespace ConvORM.Connection.Classes
{
    static class Converter
    {
        static internal ModelEntity EntityToModelEntity(Entity entity)
        {
            ConverterModelEntityHelper helper = new ConverterModelEntityHelper(entity);
            ModelEntity model = new ModelEntity();
            model.TableName = helper.GetTableName();
            model.ColumnsModelEntity = helper.GetColumnsModelEntity();
            return model;
        }
    }
}
