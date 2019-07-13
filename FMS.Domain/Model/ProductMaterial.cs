using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductMaterial
    {
        public int ProductMaterialId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [MaxLength(1)]
        public string FMS_pmat { get; set; }
    }
}
