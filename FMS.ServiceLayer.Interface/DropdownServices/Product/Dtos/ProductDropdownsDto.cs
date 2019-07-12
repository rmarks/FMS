using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductDropdownsDto
    {
        public IList<ProductSourceTypeDropdownDto> ProductSourceTypes { get; set; }

        public IList<ProductDestinationTypeDropdownDto> ProductDestinationTypes { get; set; }

        public IList<ProductBrandDropdownDto> ProductBrands { get; set; }

        public IList<ProductCollectionDropdownDto> ProductCollections { get; set; }

    }
}
