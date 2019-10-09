using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class Price
    {
        public int PriceId { get; set; }
        
        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitPrice { get; set; }

        //------------------------------------
        //relationships
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PriceListId { get; set; }

        //--- legacy system fields ---
        [MaxLength(12)]
        public string FMS_tkood { get; set; }
        [MaxLength(3)]
        public string FMS_suurus { get; set; }

    }
}
