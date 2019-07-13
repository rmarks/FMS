using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductGroup
    {
        public int ProductGroupId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int? ProductTypeId { get; set; }

        //------------------------------------------
        public ProductType ProductType { get; set; }

        //--- legacy system fields ---
        [MaxLength(1)]
        public string FMS_aliik { get; set; }
        [MaxLength(2)]
        public string FMS_agrupp { get; set; }
    }
}
