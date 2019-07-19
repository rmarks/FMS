using System;
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

        [MaxLength(50)]
        public string ProductBaseNameEng { get; set; }

        [MaxLength(50)]
        public string ProductBaseNameGer { get; set; }

        public int? BusinessLineId { get; set; }

        public int? ProductSourceTypeId { get; set; }

        public int? ProductDestinationTypeId { get; set; }

        public int? ProductStatusId { get; set; }

        public int? ProductMaterialId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? ProductGroupId { get; set; }

        public int? ProductBrandId { get; set; }

        public int? ProductCollectionId { get; set; }

        public int? ProductDesignId { get; set; }

        [MaxLength(4)]
        public string Model { get; set; }

        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        //---------------------------------------------
        public BusinessLine BusinessLine { get; set; }
        public ProductSourceType ProductSourceType { get; set; }
        public ProductDestinationType ProductDestinationType { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductMaterial ProductMaterial { get; set; }
        public ProductType ProductType { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductCollection ProductCollection { get; set; }
        public ProductDesign ProductDesign { get; set; }
    }
}
