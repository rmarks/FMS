using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanySalesOrderSelect
    {
        public static IQueryable<CompanySalesOrderListModel> MapSalesOrderQueryToCompanySalesOrderListModelQuery(this IQueryable<SalesOrder> salesOrders)
        {
            return salesOrders.Select(s => new CompanySalesOrderListModel
            {
                SalesOrderId = s.SalesOrderId,
                OrderNo = s.OrderNo,
                OrderDate = s.OrderDate,
                OrderDeliveryDate = s.OrderDeliveryDate,
                BuyerName = s.Company.CompanyName,
                ConsigneeName = $"{(s.BillingAddressId == s.ShippingAddressId ? s.Company.CompanyName : s.ShippingAddress.ConsigneeName)}",
                IsClosed = s.IsClosed
            });
        }
    }
}
