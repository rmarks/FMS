using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class Price
    {
        //fluent composite key
        public int ProductId { get; set; }
        public int PriceListId { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitPrice { get; set; }

        //------------------------------------
        //relationships
        public Product Product { get; set; }

        //--- legacy system fields ---
        [MaxLength(12)]
        public string FMS_tkood { get; set; }
        [MaxLength(3)]
        public string FMS_suurus { get; set; }

    }
}
