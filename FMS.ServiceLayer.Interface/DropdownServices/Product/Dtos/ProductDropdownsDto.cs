using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductDropdownsDto
    {
        public IList<BusinessLineDropdownDto> BusinessLines { get; set; }

        public IList<ProductStatusDropdownDto> ProductStatuses { get; set; }

        public IList<ProductSourceTypeDropdownDto> ProductSourceTypes { get; set; }

        public IList<ProductDestinationTypeDropdownDto> ProductDestinationTypes { get; set; }

        public IList<ProductMaterialDropdownDto> ProductMaterials { get; set; }

        public IList<ProductTypeDropdownDto> ProductTypes { get; set; }

        public IList<ProductGroupDropdownDto> ProductGroups { get; set; }

        public IList<ProductBrandDropdownDto> ProductBrands { get; set; }

        public IList<ProductCollectionDropdownDto> ProductCollections { get; set; }

        public IList<ProductDesignDropdownDto> ProductDesigns { get; set; }
    }
}
