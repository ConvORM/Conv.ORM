using ConvORM.Connection.Classes.CommandBuilders;
using System.Collections.Generic;
using System.Text;

namespace ConvORM.Connection.Classes
{
    internal class CommandBuilder
    {
        private ModelEntity modelEntity; 

        public CommandBuilder(ModelEntity model)
        {
            modelEntity = model;
        }

        internal string GetSqlInsert(out Dictionary<string, object> parametersValues)
         {
            CommandInsertBuilder commandInsertBuilder = new CommandInsertBuilder(modelEntity);
            return commandInsertBuilder.GetSqlInsert(out parametersValues);
        }

        internal string GetSqlSelect(QueryConditionsBuilder queryConditionsBuilder)
        {
            CommandSelectBuilder commandSelectBuilder = new CommandSelectBuilder(modelEntity, queryConditionsBuilder);
            return commandSelectBuilder.GetSqlSelect();
        }
    }
}
