namespace FMS.WPF.Models
{
    public class SalesOrderLineModel
    {
        public int SalesOrderLineId { get; set; }

        public int SalesOrderId { get; set; }
        
        public int LocationId { get; set; }
        public string LocationLocationName { get; set; }

        public int ProductId { get; set; }
        public string ProductProductCode { get; set; }
        public string ProductProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int MissingQuantity => OrderedQuantity - InvoicedQuantity - ReservedQuantity;
    }
}
