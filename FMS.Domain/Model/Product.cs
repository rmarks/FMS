using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, MaxLength(15)]
        public string ProductCode { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitGrossWeight { get; set; }

        //------------------------------------------
        //Relationships
        public int ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; }

        public ProductSource ProductSource { get; set; }
        public ProductDestination ProductDestination { get; set; }
        public List<Price> Prices { get; set; }

        //--- legacy system fields ---
        [MaxLength(12)]
        public string FMS_tkood { get; set; }
        [MaxLength(3)]
        public string FMS_suurus { get; set; }
    }
}
