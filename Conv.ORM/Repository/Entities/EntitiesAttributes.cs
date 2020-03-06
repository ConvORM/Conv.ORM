using System;

namespace ConvORM.Repository.Entities
{
    public class EntitiesAttributes : Attribute
    {
        public string TableName { get; set; }
        public string ConnectionName { get; set; }
    }
}
