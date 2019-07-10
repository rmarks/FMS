using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Common
{
    public interface IProductDropdownTables
    {
        IList<ProductSourceTypeModel> ProductSourceTypes { get; }

        IList<ProductDestinationTypeModel> ProductDestinationTypes { get; }

        IList<ProductBrandModel> ProductBrands { get; }

        IList<ProductCollectionModel> ProductCollections { get; }
    }
}
