using System;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Interface.Dtos
{
    public class ProductBaseDto
    {
        public int ProductBaseId { get; set; }

        public string ProductBaseCode { get; set; }

        public string ProductBaseName { get; set; }
        public string ProductBaseNameEng { get; set; }
        public string ProductBaseNameGer { get; set; }

        public int? BusinessLineId { get; set; }
        public int? ProductStatusId { get; set; }
        public string ProductStatusName { get; set; }

        public int? ProductSourceTypeId { get; set; }
        public int? ProductDestinationTypeId { get; set; }

        public int? ProductMaterialId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductGroupId { get; set; }

        public int? ProductBrandId { get; set; }
        public int? ProductCollectionId { get; set; }
        public int? ProductDesignId { get; set; }

        public string Model { get; set; }
        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<ProductDto> Products { get; set; }

        public List<ProductBaseProductVariationDto> ProductVariationsLink { get; set; }

        public List<PriceDto> Prices { get; set; }
    }
}
