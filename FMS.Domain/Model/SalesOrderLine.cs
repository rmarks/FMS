using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesOrderLine
    {
        public int SalesOrderLineId { get; set; }

        public int SalesOrderId { get; set; }

        [Required, MaxLength(12)]
        public string ProductCode { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }

        //-------------------------------------
        public SalesOrder SalesOrder { get; set; }
    }
}
