namespace FMS.DAL.Interfaces
{
    public interface IDataContextFactory
    {
        IDataContext CreateContext();
    }
}
