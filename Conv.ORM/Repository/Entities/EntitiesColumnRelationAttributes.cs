namespace ConvORM.Repository.Entities
{
    public abstract class EntitiesColumnRelationAttributes
    {
        public string TableRelationName { get; set; }
        public string ColumnRelationName { get; set; }
        public Entity EntityRelation { get; set; }
    }
}
