using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductCollection
    {
        public int ProductCollectionId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int ProductBrandId { get; set; }

        //--------------------------------------------
        public ProductBrand ProductBrand { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_lamudel { get; set; }
    }
}
