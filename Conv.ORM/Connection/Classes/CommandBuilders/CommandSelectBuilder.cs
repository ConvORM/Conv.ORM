using ConvORM.Connection.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvORM.Connection.Classes.CommandBuilders
{
    internal class CommandSelectBuilder
    {
        private ModelEntity modelEntity;
        private QueryConditionsBuilder queryConditionsBuilder;

        public CommandSelectBuilder(ModelEntity model, QueryConditionsBuilder queryConditions)
        {
            modelEntity = model;
            queryConditionsBuilder = queryConditions;
        }

        internal string GetSqlSelect()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");

            sql.Append(GetSqlFields());

            sql.Append(" FROM ");
            sql.Append(modelEntity.TableName);

            sql.Append(" WHERE ");
            sql.Append(GetWhere());

            return sql.ToString();
        }

        private string GetSqlFields()
        {
            StringBuilder sqlFields = new StringBuilder();

            foreach (ColumnModelEntity columnModelEntity in modelEntity.ColumnsModelEntity)
            {
                sqlFields.Append(modelEntity.TableName);
                sqlFields.Append(".");
                sqlFields.Append(columnModelEntity.ColumnName);
                sqlFields.Append(",");
            }

            sqlFields.Remove(sqlFields.Length - 1, 1);

            return sqlFields.ToString();
        }

        private string GetWhere()
        {
            StringBuilder sqlwhere = new StringBuilder();
            foreach(QueryCondition condition in queryConditionsBuilder.QueryConditionList)
            {
                sqlwhere.Append(condition.Field);

                switch (condition.Type)
                {
                    case EConditionTypes.In:
                        sqlwhere.Append(" IN ");
                        sqlwhere.Append(GetSqlIn(condition.Value));
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
                        sqlwhere.Append(" = ");
                        sqlwhere.Append(ConvertValue(condition.Value));
                        break;
                    case EConditionTypes.Not:
                        break;
                    case EConditionTypes.IsNull:
                        break;
                    default:
                        break;
                }

            }

            return sqlwhere.ToString();

        }

        private string GetSqlIn(object valueList)
        {
            StringBuilder sqlIn = new StringBuilder();
            if (valueList is List<string>)
            {
                sqlIn.Append("('");
                sqlIn.Append(string.Join("','", (List<string>)valueList));
                sqlIn.Append("')");

            }
            else if (valueList is List<int>)
            {
                sqlIn.Append("(");
                sqlIn.Append(string.Join(",", (List<string>)valueList));
                sqlIn.Append(")");                
            }
            else
                throw new System.Exception("The condition of type IN require a list of string or int");

            return sqlIn.ToString();
        }

        private string ConvertValue(object value)
        {
            if (value is int)
            {
                return ((int)value).ToString();
            }
            else if (value is string)
            {
                return "'" + (string)value + "'";
            }
            else if (value is DateTime)
            {
                return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else
            {
                return "'" + value.ToString() + "'";
            }
        }

    }
}
