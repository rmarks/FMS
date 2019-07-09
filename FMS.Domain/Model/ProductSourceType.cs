using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class ProductSourceType
    {
        public int ProductSourceTypeId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [Required, Column(TypeName = "char(1)")]
        public string FMS_akat { get; set; }
    }
}
