namespace FMS.ServiceLayer.Interface.Services
{
    public interface IDataTransferService
    {
        void ClearDatabase();
        bool TransferData();
    }
}