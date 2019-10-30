using FMS.WPF.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ISalesOrderService
    {
        SalesOrderModel GetSalesOrderModel(int salesOrderId);
    }
}