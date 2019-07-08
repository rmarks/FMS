using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductBase
    {
        public int ProductBaseId { get; set; }

        [Required, MaxLength(12)]
        public string ProductBaseCode { get; set; }

        [Required, MaxLength(50)]
        public string ProductBaseName { get; set; }
    }
}
