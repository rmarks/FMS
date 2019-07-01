using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesInvoiceLine
    {
        public int SalesInvoiceLineId { get; set; }

        public int SalesInvoiceId { get; set; }

        [Required, MaxLength(12)]
        public string ProductCode { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int Quantity { get; set; }

        //--------------------------------------------
        public SalesInvoice SalesInvoice { get; set; }
    }
}
