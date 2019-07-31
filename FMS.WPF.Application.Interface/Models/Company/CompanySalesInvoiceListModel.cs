using System;

namespace FMS.WPF.Application.Interface.Models
{
    public class CompanySalesInvoiceListModel
    {
        public int SalesInvoiceId { get; set; }

        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public string BuyerName { get; set; }
        public string ConsigneeName { get; set; }

        public int TotalQuantity { get; set; }
        public decimal Sum { get; set; }
        public decimal SumWithVAT { get; set; }

        public bool IsClosed { get; set; }
    }
}
