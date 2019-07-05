namespace FMS.DAL.EFCore
{
    public interface IDataContextFactory
    {
        IDataContext CreateContext();
    }
}
