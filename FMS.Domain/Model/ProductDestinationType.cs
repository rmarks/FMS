using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class ProductDestinationType
    {
        public int ProductDestinationTypeId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [Required, Column(TypeName = "char(1)")]
        public string FMS_ttyyp { get; set; }
    }
}
