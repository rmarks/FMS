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

        public int? ProductSourceTypeId { get; set; }

        public int? ProductDestinationTypeId { get; set; }

        public int? ProductBrandId { get; set; }

        public int? ProductCollectionId { get; set; }

        public int? ProductDesignId { get; set; }

        //---------------------------------------------
        public ProductSourceType ProductSourceType { get; set; }
        public ProductDestinationType ProductDestinationType { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductCollection ProductCollection { get; set; }
        public ProductDesign ProductDesign { get; set; }
    }
}
