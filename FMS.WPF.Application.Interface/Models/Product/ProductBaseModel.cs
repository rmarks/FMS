using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Interface.Models
{
    public class ProductBaseModel : ModelBase
    {
        #region model properties
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
        public bool HasSize { get; set; }
        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }
        #endregion

        #region dropdowns
        public IProductDropdowns Dropdowns => ProductDropdownsProxy.Instance;

        public IList<ProductGroupDropdownModel> ProductGroups =>
            Dropdowns?.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId || pg.ProductTypeId == null).ToList();

        public IList<ProductCollectionDropdownModel> ProductCollections =>
            Dropdowns?.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownModel> ProductDesigns =>
            Dropdowns?.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();
        #endregion
    }
}
