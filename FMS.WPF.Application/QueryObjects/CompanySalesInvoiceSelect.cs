using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanySalesInvoiceSelect
    {
        public static IQueryable<CompanySalesInvoiceListModel> MapSalesInvoiceQueryToCompanySalesInvoiceListModelQuery(this IQueryable<SalesInvoice> salesInvoices)
        {
            return salesInvoices.Select(i => new CompanySalesInvoiceListModel
            {
                InvoiceNo = i.InvoiceNo,
                InvoiceDate = i.InvoiceDate,
                BuyerName = i.Company.CompanyName,
                ConsigneeName = $"{(i.BillingAddressId == i.ShippingAddressId ? i.Company.CompanyName : i.ShippingAddress.ConsigneeName)}",
                IsClosed = i.IsClosed
            });
        }
    }
}
