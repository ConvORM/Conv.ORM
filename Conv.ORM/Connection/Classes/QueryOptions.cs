using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvORM.Connection.Classes
{
    public class QueryOptions
    {
        private QueryOptions _QueryOptions;
        private string TableName;
        private Dictionary<string, string> FieldsDictionary;

        public QueryOptions(string tableName)
        {
            TableName = tableName;
        }

        public QueryOptions AddAllFields()
        {

        }
    }
}
