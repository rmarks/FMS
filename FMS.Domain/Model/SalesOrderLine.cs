using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesOrderLine
    {
        public int SalesOrderLineId { get; set; }

        public int SalesOrderId { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int OrderedQuantity { get; set; }
        public int ReservedQuantity { get; set; }

        //--- obsolete ---
        public int InvoicedQuantity { get; set; }
    }
}
