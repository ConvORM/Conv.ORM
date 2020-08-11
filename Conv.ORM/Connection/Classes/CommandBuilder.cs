using ConvORM.Connection.Classes.CommandBuilders;
using System.Collections.Generic;
using ConvORM.Connection.Classes.QueryBuilders;

namespace ConvORM.Connection.Classes
{
    internal class CommandBuilder
    {
        private readonly ModelEntity _modelEntity; 

        public CommandBuilder(ModelEntity model)
        {
            _modelEntity = model;
        }

        internal string GetSqlInsert(out Dictionary<string, object> parametersValues)
         {
            var commandInsertBuilder = new CommandInsertBuilder(_modelEntity);
            return commandInsertBuilder.GetSqlInsert(out parametersValues);
        }

        internal string GetSqlSelect(QueryConditionsBuilder queryConditionsBuilder)
        {
            var commandSelectBuilder = new CommandSelectBuilder(_modelEntity, queryConditionsBuilder);
            return commandSelectBuilder.GetSqlSelect();
        }
    }
}
