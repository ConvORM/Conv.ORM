using ConvORM.Connection.Enums;

namespace ConvORM.Connection.Classes
{
    internal class QueryCondition
    {
        public string Field { get; set; }
        public EConditionTypes Type { get; set; }
        public object Value { get; set; }
        public ELogicalConditionTypes LogicalType { get; set; }
    }
}
