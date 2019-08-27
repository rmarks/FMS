using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class ProductSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        
        [MaxLength(30)]
        public string CompanyProductCode { get; set; }
        [MaxLength(13)]
        public string EAN { get; set; }

        //-----------------------------------
        //relationships
        public Product Product { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
