using System.Collections.Generic;
using System.Text;

namespace ConvORM.Connection.Classes
{
    internal class CommandBuilder
    {
        private ModelEntity modelEntity; 

        public CommandBuilder(ModelEntity model)
        {
            modelEntity = model;
        }

        internal string GetSqlInsert(out Dictionary<string, object> parametersValues)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO ");
            sql.Append(modelEntity.TableName);

            GetSqlFieldsAndParameters(out string fields, 
                                      out string values,
                                      out parametersValues);

            sql.Append(fields);

            sql.Append(" VALUES ");

            sql.Append(values);

            return sql.ToString();       
        }

        private void GetSqlFieldsAndParameters(out string fields, out string values, out Dictionary<string,object> parametersValues)
        {
            parametersValues = new Dictionary<string, object>();

            StringBuilder sqlFields = new StringBuilder();
            StringBuilder sqlValues = new StringBuilder();
                 
            sqlFields.Append(" (");
            sqlValues.Append(" (");
            foreach(ColumnModelEntity columnModelEntity in modelEntity.ColumnsModelEntity)
            {
                sqlFields.Append(columnModelEntity.ColumnName);
                sqlFields.Append(",");

                string parameter = "@" + columnModelEntity.ColumnName;

                sqlValues.Append(parameter);
                sqlValues.Append(",");

                parametersValues.Add(parameter, columnModelEntity.Value);

            }

            sqlFields.Remove(sqlFields.Length - 2, 1);
            sqlFields.Append(") ");

            sqlValues.Remove(sqlFields.Length - 2, 1);
            sqlValues.Append(") ");

            fields = sqlFields.ToString();
            values = sqlFields.ToString();
        }
    }
}
