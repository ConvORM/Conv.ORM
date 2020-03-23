using System;

namespace ConvORM.Repository.Entities
{
    public abstract class EntitiesAttributes : Attribute
    {
        public string TableName { get; set; } //Table name in database
        public string ConnectionName { get; set; }
    }
}
