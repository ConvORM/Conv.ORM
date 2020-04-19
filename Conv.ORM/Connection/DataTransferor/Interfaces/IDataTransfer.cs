using ConvORM.Repository;

namespace ConvORM.Connection.DataTransferor.Interfaces
{
    public interface IDataTransfer
    {
        Entity Delete();
        Entity Insert();
        Entity SetDeleted();
        Entity Update();
    }
}