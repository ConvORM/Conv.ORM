using ConvORM.Connection.Classes;
using ConvORM.Repository;
using System.Collections;
using ConvORM.Connection.Classes.QueryBuilders;

namespace ConvORM.Connection.DataTransferor.Interfaces
{
    public interface IDataTransfer
    {
        Entity Delete();
        Entity Insert();
        Entity SetDeleted();
        Entity Update();

        IList FindAll();
        IList Find(QueryConditionsBuilder conditionsBuilder);
        Entity Find(int[] ids);
    }
}