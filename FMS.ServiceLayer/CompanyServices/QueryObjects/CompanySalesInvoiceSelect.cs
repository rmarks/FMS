using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using System;
using System.Linq;

namespace FMS.ServiceLayer.QueryObjects
{
    public static class CompanySalesInvoiceSelect
    {
        public static IQueryable<CompanySalesInvoiceListDto> MapToDto(this IQueryable<SalesInvoice> salesInvoices)
        {
            return salesInvoices.Select(i => new CompanySalesInvoiceListDto
            {
                InvoiceNo = i.InvoiceNo,
                InvoiceDate = i.InvoiceDate,
                BuyerName = i.Company.CompanyName,
                ConsigneeName = $"{(i.BillingAddressId == i.ShippingAddressId ? i.Company.CompanyName : i.ShippingAddress.ConsigneeName)}",
                TotalQuantity = i.SalesInvoiceLines.Sum(l => l.Quantity),
                Sum = i.SalesInvoiceLines.Sum(l => l.Quantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2)),
                SumWithVAT = i.SalesInvoiceLines.Sum(l => l.Quantity * Math.Round(Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2) * (1 + 20 / 100m), 2)),
                IsClosed = i.IsClosed
            });
        }
    }
}
