namespace FMS.ServiceLayer.Interface.Dtos
{
    public class ProductBaseProductVariationDto
    {
        public int ProductBaseId { get; set; }
        public int ProductVariationId { get; set; }
        public ProductVariationDto ProductVariation { get; set; }
    }
}
