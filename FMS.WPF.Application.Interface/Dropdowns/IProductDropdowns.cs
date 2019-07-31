using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Interface.Dropdowns
{
    public interface IProductDropdowns
    {
        IList<BusinessLineDropdownModel> BusinessLines { get; set; }

        IList<ProductStatusDropdownModel> ProductStatuses { get; set; }

        IList<ProductSourceTypeDropdownModel> ProductSourceTypes { get; set; }

        IList<ProductDestinationTypeDropdownModel> ProductDestinationTypes { get; set; }

        IList<ProductMaterialDropdownModel> ProductMaterials { get; set; }

        IList<ProductTypeDropdownModel> ProductTypes { get; set; }

        IList<ProductGroupDropdownModel> ProductGroups { get; set; }

        IList<ProductBrandDropdownModel> ProductBrands { get; set; }

        IList<ProductCollectionDropdownModel> ProductCollections { get; set; }

        IList<ProductDesignDropdownModel> ProductDesigns { get; set; }

        Task InitializeAsync();
    }

    public class ProductDropdownsProxy
    {
        public static IProductDropdowns Instance { get; set; }
    }
}
