namespace FMS.WPF.Application.Interface.Services
{
    public interface IDataTransferService
    {
        void ClearDatabase();
        bool TransferData();
    }
}