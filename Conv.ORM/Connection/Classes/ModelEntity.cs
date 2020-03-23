using System.Collections.Generic;
using System.Linq;

namespace ConvORM.Connection.Classes
{
    internal class ModelEntity
    {
        public string TableName { get; set; }
        public string ConnectionName { get; set; }
        public List<ColumnModelEntity> ColumnsModelEntity { get; set; }

        internal IEnumerable<ColumnModelEntity> GetPrimaryFields()
        {
            return ColumnsModelEntity.Where(column => column.Primary).ToList();
        }
    }
}
