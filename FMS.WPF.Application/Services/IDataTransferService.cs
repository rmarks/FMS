namespace FMS.WPF.Application.Services
{
    public interface IDataTransferService
    {
        void ClearDatabase();
        bool TransferData();
    }
}