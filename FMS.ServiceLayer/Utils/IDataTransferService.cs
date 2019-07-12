namespace FMS.ServiceLayer.Utils
{
    public interface IDataTransferService
    {
        void ClearDatabase();
        bool TransferData();
    }
}