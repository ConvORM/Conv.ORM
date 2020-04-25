using ConvORM.Connection.Enums;
using System.Collections.Generic;

namespace ConvORM.Connection.Classes
{
    public class QueryConditionsBuilder
    {
        internal readonly List<QueryCondition> QueryConditionList;
        
        public QueryConditionsBuilder()
        {
            QueryConditionList = new List<QueryCondition>();
        }

        public QueryConditionsBuilder AddQueryCondition(string field, EConditionTypes conditionTypes, object value, ELogicalConditionTypes logicalConditionTypes = ELogicalConditionTypes.And)
        {
            var queryCondition = new QueryCondition
            {
                Field = field, Type = conditionTypes, Value = value, LogicalType = logicalConditionTypes
            };

            QueryConditionList.Add(queryCondition);

            return this;
        }
    }
}
