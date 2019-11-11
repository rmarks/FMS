using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesLine
    {
        public int SalesLineId { get; set; }

        public int SalesHeaderId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int SoldQuantity { get; set; }

        //temp int -> int?
        public int? DeliveryLineId { get; set; }
    }
}
