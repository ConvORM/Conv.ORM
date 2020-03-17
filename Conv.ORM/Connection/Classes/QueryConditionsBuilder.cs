using ConvORM.Connection.Enums;
using System.Collections.Generic;

namespace ConvORM.Connection.Classes
{
    public class QueryConditionsBuilder
    {
        internal List<QueryCondition> QueryConditionList;
        
        public QueryConditionsBuilder()
        {
            QueryConditionList = new List<QueryCondition>();
        }

        public QueryConditionsBuilder AddQueryCondition(string field, EConditionTypes conditionTypes, object value, ELogicalConditionTypes logicalConditionTypes = ELogicalConditionTypes.And)
        {
            QueryCondition queryCondition = new QueryCondition();
            queryCondition.Field = field;
            queryCondition.Type = conditionTypes;
            queryCondition.Value = value;
            queryCondition.LogicalType = logicalConditionTypes;

            QueryConditionList.Add(queryCondition);

            return this;
        }
    }
}
