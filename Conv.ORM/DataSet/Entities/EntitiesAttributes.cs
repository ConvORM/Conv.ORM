using System;

namespace ConvORM.DataSet.Entities
{
    public class EntitiesAttributes: Attribute
    {
        public string DataType;
        public string Name;
        public int MaxSize;
        public bool Primary;
        public bool Nullable;
        public string Default;
    }
}
