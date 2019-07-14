using FMS.ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public class ProductListOptionsModel : EditableModelBase
    {
        public ProductListOptionsDto OptionsDto { get; set; }
        public ProductListOptionsDropdownsDto Dropdowns { get; set; }

        #region options
        public int? BusinessLineId
        {
            get => OptionsDto.BusinessLineId;
            set => OptionsDto.BusinessLineId = value;
        }

        public int? ProductStatusId
        {
            get => OptionsDto.ProductStatusId;
            set => OptionsDto.ProductStatusId = value;
        }

        public int? ProductSourceTypeId
        {
            get => OptionsDto.ProductSourceTypeId;
            set => OptionsDto.ProductSourceTypeId = value;
        }

        public int? ProductDestinationTypeId
        {
            get => OptionsDto.ProductDestinationTypeId;
            set =>  OptionsDto.ProductDestinationTypeId = value;
        }

        public int? ProductMaterialId
        {
            get => OptionsDto.ProductMaterialId;
            set => OptionsDto.ProductMaterialId = value;
        }

        public int? ProductTypeId
        {
            get => OptionsDto.ProductTypeId;
            set => OptionsDto.ProductTypeId = value;
        }

        public int? ProductGroupId
        {
            get => OptionsDto.ProductGroupId;
            set => OptionsDto.ProductGroupId = value;
        }

        public int? ProductBrandId
        {
            get => OptionsDto.ProductBrandId;
            set => OptionsDto.ProductBrandId = value;
        }

        public int? ProductCollectionId
        {
            get => OptionsDto.ProductCollectionId;
            set => OptionsDto.ProductCollectionId = value;
        }

        public int? ProductDesignId
        {
            get => OptionsDto.ProductDesignId;
            set => OptionsDto.ProductDesignId = value;
        }
        #endregion options

        #region dropdowns
        public IList<BusinessLineDropdownDto> BusinessLines => Dropdowns.BusinessLines;

        public IList<ProductStatusDropdownDto> ProductStatuses => Dropdowns.ProductStatuses;

        public IList<ProductSourceTypeDropdownDto> ProductSourceTypes => Dropdowns.ProductSourceTypes;

        public IList<ProductDestinationTypeDropdownDto> ProductDestinationTypes => Dropdowns.ProductDestinationTypes;

        public IList<ProductMaterialDropdownDto> ProductMaterials => Dropdowns.ProductMaterials;

        public IList<ProductTypeDropdownDto> ProductTypes => Dropdowns.ProductTypes;

        public IList<ProductGroupDropdownDto> ProductGroups =>
            Dropdowns.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId || pg.ProductTypeId == null).ToList();

        public IList<ProductBrandDropdownDto> ProductBrands => Dropdowns.ProductBrands;

        public IList<ProductCollectionDropdownDto> ProductCollections => 
            Dropdowns.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownDto> ProductDesigns =>
            Dropdowns.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();
        #endregion dropdowns

        #region options reset and change
        public void Reset()
        {
            GetType().GetProperties().Where(pi => pi.PropertyType == typeof(int?)).ToList().ForEach(pi => pi.SetValue(this, null));
        }

        public event Action OptionChanged;

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
            OptionChanged?.Invoke();
        }
        #endregion options reset and change

        #region overrides
        public override void Merge(EditableModelBase source)
        {
            throw new NotImplementedException();
        }
        #endregion overrides
    }
}
