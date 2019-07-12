using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using System;
using System.Linq;

namespace FMS.ServiceLayer.QueryObjects
{
    public static class CompanySalesOrderSelect
    {
        public static IQueryable<CompanySalesOrderListDto> MapToDto(this IQueryable<SalesOrder> salesOrders)
        {
            return salesOrders.Select(s => new CompanySalesOrderListDto
            {
                SalesOrderId = s.SalesOrderId,
                OrderNo = s.OrderNo,
                OrderDate = s.OrderDate,
                OrderDeliveryDate = s.OrderDeliveryDate,
                BuyerName = s.Company.CompanyName,
                ConsigneeName = $"{(s.BillingAddressId == s.ShippingAddressId ? s.Company.CompanyName : s.ShippingAddress.ConsigneeName)}",
                TotalOrderedQuantity = s.SalesOrderLines.Sum(l => l.OrderedQuantity),
                TotalInvoicedQuantity = s.SalesOrderLines.Sum(l => l.InvoicedQuantity),
                TotalReservedQuantity = s.SalesOrderLines.Sum(l => l.ReservedQuantity),
                OrderedSum = s.SalesOrderLines.Sum(l => l.OrderedQuantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2)),
                MissingSum = s.SalesOrderLines.Sum(l => (l.OrderedQuantity - l.InvoicedQuantity - l.ReservedQuantity) * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2)),
                IsClosed = s.IsClosed
            });
        }
    }
}
