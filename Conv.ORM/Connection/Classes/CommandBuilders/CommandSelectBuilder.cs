using ConvORM.Connection.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvORM.Connection.Classes.CommandBuilders
{
    internal class CommandSelectBuilder
    {
        private readonly ModelEntity _modelEntity;
        private readonly QueryConditionsBuilder _queryConditionsBuilder;

        public CommandSelectBuilder(ModelEntity model, QueryConditionsBuilder queryConditions)
        {
            _modelEntity = model;
            _queryConditionsBuilder = queryConditions;
        }

        internal string GetSqlSelect()
        {
            var sql = new StringBuilder();

            sql.Append("SELECT ");

            sql.Append(GetSqlFields());

            sql.Append(" FROM ");
            sql.Append(_modelEntity.TableName);

            if (!HasWhere()) return sql.ToString();

            sql.Append(" WHERE ");
            sql.Append(GetWhere());

            return sql.ToString();
        }

        private string GetSqlFields()
        {
            var sqlFields = new StringBuilder();

            foreach (var columnModelEntity in _modelEntity.ColumnsModelEntity)
            {
                sqlFields.Append(_modelEntity.TableName);
                sqlFields.Append(".");
                sqlFields.Append(columnModelEntity.ColumnName);
                sqlFields.Append(",");
            }

            sqlFields.Remove(sqlFields.Length - 1, 1);

            return sqlFields.ToString();
        }

        private string GetWhere()
        {
            var sqlWhere = new StringBuilder();
            foreach(var condition in _queryConditionsBuilder.QueryConditionList)
            {
                sqlWhere.Append(condition.Field);

                switch (condition.Type)
                {
                    case EConditionTypes.In:
                        sqlWhere.Append(" IN ");
                        sqlWhere.Append(GetSqlIn(condition.Value));
                        break;
                    case EConditionTypes.Between:
                        break;
                    case EConditionTypes.Like:
                        break;
                    case EConditionTypes.LessThan:
                        break;
                    case EConditionTypes.LessThanOrEquals:
                        break;
                    case EConditionTypes.MoreThan:
                        break;
                    case EConditionTypes.MoreThanOrEquals:
                        break;
                    case EConditionTypes.Equals:
                        sqlWhere.Append(" = ");
                        sqlWhere.Append(ConvertValue(condition.Value));
                        break;
                    case EConditionTypes.Not:
                        break;
                    case EConditionTypes.IsNull:
                        break;
                    default:
                        break;
                }

            }

            return sqlWhere.ToString();

        }

        private bool HasWhere()
        {
            return _queryConditionsBuilder.QueryConditionList.Count > 0;
        }

        private string GetSqlIn(object valueList)
        {
            var sqlIn = new StringBuilder();
            switch (valueList)
            {
                case List<string> list:
                    sqlIn.Append("('");
                    sqlIn.Append(string.Join("','", list));
                    sqlIn.Append("')");
                    break;
                case List<int> _:
                    sqlIn.Append("(");
                    sqlIn.Append(string.Join(",", (List<string>)valueList));
                    sqlIn.Append(")");
                    break;
                default:
                    throw new System.Exception("The condition of type IN require a list of string or int");
            }

            return sqlIn.ToString();
        }

        private static string ConvertValue(object value)
        {
            switch (value)
            {
                case int i:
                    return i.ToString();
                case string s:
                    return "'" + s + "'";
                case DateTime time:
                    return "'" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                default:
                    return "'" + value.ToString() + "'";
            }
        }

    }
}
