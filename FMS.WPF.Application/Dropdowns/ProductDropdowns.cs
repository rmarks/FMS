using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Dropdowns
{
    public class ProductDropdowns : IProductDropdowns
    {
        private readonly IProductDropdownsService _dropdownsService;

        public ProductDropdowns(IProductDropdownsService dropdownsService)
        {
            _dropdownsService = dropdownsService;
        }

        #region properties
        public IList<BusinessLineDropdownModel> BusinessLines { get; set; }
        public IList<ProductStatusDropdownModel> ProductStatuses { get; set; }
        public IList<ProductSourceTypeDropdownModel> ProductSourceTypes { get; set; }
        public IList<ProductDestinationTypeDropdownModel> ProductDestinationTypes { get; set; }
        public IList<ProductMaterialDropdownModel> ProductMaterials { get; set; }
        public IList<ProductTypeDropdownModel> ProductTypes { get; set; }
        public IList<ProductGroupDropdownModel> ProductGroups { get; set; }
        public IList<ProductBrandDropdownModel> ProductBrands { get; set; }
        public IList<ProductCollectionDropdownModel> ProductCollections { get; set; }
        public IList<ProductDesignDropdownModel> ProductDesigns { get; set; }
        #endregion

        public async Task InitializeAsync()
        {
            var dto = await _dropdownsService.GetProductDropdownsAsync();

            MappingFactory.MapTo<ProductDropdownsDto, ProductDropdowns>(dto, this);
        }
    }
}
