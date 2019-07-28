using FMS.ServiceLayer.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Application.Interface.Models
{
    public class ProductListOptionsModel : ModelBase
    {
        #region options
        public int? BusinessLineId { get; set; }

        public int? ProductStatusId { get; set; }

        public int? ProductSourceTypeId { get; set; }

        public int? ProductDestinationTypeId { get; set; }

        public int? ProductMaterialId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? ProductGroupId { get; set; }

        public int? ProductBrandId { get; set; }

        public int? ProductCollectionId { get; set; }

        public int? ProductDesignId { get; set; }
        #endregion

        #region dropdowns
        public ProductDropdownsDto Dropdowns { get; set; }

        public IList<ProductGroupDropdownDto> ProductGroups =>
            Dropdowns.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId || pg.ProductTypeId == null).ToList();

        public IList<ProductCollectionDropdownDto> ProductCollections => 
            Dropdowns.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownDto> ProductDesigns =>
            Dropdowns.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();
        #endregion dropdowns

        #region options change notification and reset
        public void Reset()
        {
            GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(int?))
                .ToList()
                .ForEach(pi => pi.SetValue(this, null));
        }

        public event Action OptionChanged;

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
            OptionChanged?.Invoke();
        }
        #endregion
    }
}
