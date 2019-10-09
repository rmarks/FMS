namespace FMS.Domain.Model
{
    public class ProductBaseProductVariation
    {
        public int ProductBaseProductVariationId { get; set; }

        //---------------------------------------------------
        //Relationships
        public int ProductBaseId { get; set; }

        public int ProductVariationId { get; set; }
        public ProductVariation ProductVariation { get; set; }
    }
}
