using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ISalesOrderListService
    {
        SalesOrderListOptionsModel GetSalesOrderListOptionsModel();
        IList<SalesOrderListModel> GetSalesOrderListModels(SalesOrderListOptionsModel options);
    }
}
