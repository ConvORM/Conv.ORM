using System;

namespace ConvORM.Repository.Entities
{
    public class EntitiesColumnAttributes: Attribute
    {
        public string DataType;
        public string Name;
        public int MaxSize;
        public bool Primary;
        public bool Nullable;
        public string Default;
    }
}
