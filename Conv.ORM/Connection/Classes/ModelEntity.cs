using System.Collections.Generic;

namespace ConvORM.Connection.Classes
{
    class ModelEntity
    {
        public string TableName { get; set; }
        public string ConnectionName { get; set; }
        public List<ColumnModelEntity> ColumnsModelEntity { get; set; }

        internal List<ColumnModelEntity> GetPrimaryFields()
        {
            List<ColumnModelEntity> ColumnsPrimary = new List<ColumnModelEntity>();

            foreach (ColumnModelEntity column in ColumnsModelEntity)
            {
                if (column.Primary)
                    ColumnsPrimary.Add(column);
            }

            return ColumnsPrimary;
        }
    }
}
