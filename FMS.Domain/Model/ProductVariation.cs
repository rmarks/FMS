using System.ComponentModel.DataAnnotations;


namespace FMS.Domain.Model
{
    public class ProductVariation
    {
        public int ProductVariationId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}
