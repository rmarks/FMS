using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductStatus
    {
        public int ProductStatusId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [MaxLength(1)]
        public string FMS_aolek { get; set; }
    }
}
