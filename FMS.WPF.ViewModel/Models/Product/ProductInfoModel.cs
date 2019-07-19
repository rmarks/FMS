using FMS.ServiceLayer.Dtos;
using FMS.WPF.ViewModel.Helpers;
using FMS.WPF.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Models
{
    public class ProductInfoModel : EditableModelBase
    {
        public ProductDropdownsDto Dropdowns { get; set; }

        #region model
        public int ProductBaseId { get; set; }

        public string ProductBaseCode { get; set; }

        public string ProductBaseName { get; set; }
        public string ProductBaseNameEng { get; set; }
        public string ProductBaseNameGer { get; set; }

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

        public string Model { get; set; }
        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ProductStatusName => Dropdowns?.ProductStatuses?.FirstOrDefault(ps => ps.ProductStatusId == ProductStatusId)?.Name;
        public string PictureLocation => PictureLocationHelper.GetPictureLocation(ProductBaseCode);
        #endregion

        #region dropdowns
        public IList<ProductGroupDropdownDto> ProductGroups =>
            Dropdowns?.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId || pg.ProductTypeId == null).ToList();

        public IList<ProductCollectionDropdownDto> ProductCollections =>
            Dropdowns?.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownDto> ProductDesigns =>
            Dropdowns?.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();
        #endregion

        public override void Merge(EditableModelBase source)
        {
            MappingFactory.MapTo<ProductInfoModel, ProductInfoModel>((ProductInfoModel)source, this);
        }
    }
}
