using System.Collections.Generic;

namespace ConvORM.Connection.Classes.CommandBuilders.Interfaces
{
    interface ICommandUpdateBuilder
    {
        string GetSqlUpdate(out Dictionary<string, object> parametersValues);
    }
}
