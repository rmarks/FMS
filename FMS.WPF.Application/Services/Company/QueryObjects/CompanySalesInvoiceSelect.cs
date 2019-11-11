using FMS.Domain.Model;
using FMS.WPF.Models;
using System;
using System.Linq;

namespace FMS.WPF.Application.Services.QueryObjects
{
    public static class CompanySalesInvoiceSelect
    {
        public static IQueryable<CompanySalesInvoiceListModel> MapToModel(this IQueryable<SalesHeader> salesInvoices)
        {
            return salesInvoices.Select(i => new CompanySalesInvoiceListModel
            {
                InvoiceNo = i.DocNo,
                InvoiceDate = i.DocDate,
                BuyerName = i.Company.Name,
                ConsigneeName = $"{(i.BillingAddressId == i.ShippingAddressId ? i.Company.Name : i.ShippingAddress.Description)}",
                TotalQuantity = i.SalesInvoiceLines.Sum(l => l.SoldQuantity),
                Sum = i.SalesInvoiceLines.Sum(l => l.SoldQuantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2)),
                SumWithVAT = i.SalesInvoiceLines.Sum(l => l.SoldQuantity * Math.Round(Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2) * (1 + 20 / 100m), 2)),
                IsClosed = i.IsClosed
            });
        }
    }
}
