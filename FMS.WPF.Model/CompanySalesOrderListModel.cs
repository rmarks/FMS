using System;

namespace FMS.WPF.Models
{
    public class CompanySalesOrderListModel
    {
        public int SalesOrderId { get; set; }

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }

        public string BuyerName { get; set; }
        public string ConsigneeName { get; set; }

        public int TotalOrderedQuantity { get; set; }
        public int TotalInvoicedQuantity { get; set; }
        public int TotalReservedQuantity { get; set; }
        public int TotalMissingQuantity => TotalOrderedQuantity - TotalInvoicedQuantity - TotalReservedQuantity;

        public decimal OrderedSum { get; set; }
        public decimal MissingSum { get; set; }

        public bool IsClosed { get; set; }
    }
}
