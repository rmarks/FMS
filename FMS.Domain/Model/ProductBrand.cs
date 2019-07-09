using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductBrand
    {
        public int ProductBrandId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [Required, MaxLength(2)]
        public string FMS_suurustype2 { get; set; }
    }
}
