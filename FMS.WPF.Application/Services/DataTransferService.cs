using FMS.DAL.EFCore.Utils;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.Application.Services
{
    public class DataTransferService : IDataTransferService
    {
        public void ClearDatabase()
        {
            DataTransferHelper.ClearDatabase();
        }

        public bool TransferData()
        {
            return DataTransferHelper.TransferData();
        }
    }
}
