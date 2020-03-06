using System.Collections.Generic;

namespace ConvORM.Connection.Classes
{
    class ModelEntity
    {
        public string TableName { get; set; }
        public string ConnectionName { get; set; }
        public List<ColumnModelEntity> ColumnsModelEntity { get; set; }
    }
}
