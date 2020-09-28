using System.Collections.Generic;

namespace ConvORM.Connection.Classes.CommandBuilders.Interfaces
{
    interface ICommandInsertBuilder
    {
        string GetSqlInsert(out Dictionary<string, object> parametersValues);
    }
}
