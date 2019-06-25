using System;

namespace FMS.WPF.Model
{
    public class CompanySalesInvoiceListModel
    {
        public int SalesInvoiceId { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string BuyerName { get; set; }

        public string ConsigneeName { get; set; }

        public bool IsClosed { get; set; }
    }
}
