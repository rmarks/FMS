namespace FMS.Domain.Model
{
    public class ProductBaseProductVariation
    {
        //fluent composite key
        public int ProductBaseId { get; set; }
        public int ProductVariationId { get; set; }

        //----------------------------------------
        public ProductVariation ProductVariation { get; set; }
    }
}
