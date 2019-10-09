using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Models
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
        
        //flattening
        public string ProductStatusName { get; set; }
        //---

        private int? _productSourceTypeId;
        public int? ProductSourceTypeId 
        { 
            get => _productSourceTypeId;
            set
            {
                _productSourceTypeId = value;
                ProductSourceTypeChanged?.Invoke();
            }
        }

        private int? _productDestinationTypeId;
        public int? ProductDestinationTypeId 
        { 
            get => _productDestinationTypeId;
            set
            {
                _productDestinationTypeId = value;
                ProductDestinationTypeChanged?.Invoke();
            } 
        }

        public int? ProductMaterialId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductGroupId { get; set; }

        public int? ProductBrandId { get; set; }
        public int? ProductCollectionId { get; set; }
        public int? ProductDesignId { get; set; }

        public string Model { get; set; }
        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<ProductBaseProductVariationModel> ProductVariationsLink { get; set; } = new List<ProductBaseProductVariationModel>();
        public List<PriceListModel> PriceLists { get; set; } = new List<PriceListModel>();
        #endregion

        #region overrides
        public override bool IsNew => (ProductBaseId == 0);
        #endregion

        #region view properties
        //private ObservableCollection<ProductModel> _ocProducts;
        //public ObservableCollection<ProductModel> OCProducts => _ocProducts ?? (_ocProducts = new ObservableCollection<ProductModel>(Products));

        //public bool IsPurchased => (ProductSourceTypeId == 2);

        //public bool IsForOutsource => (ProductDestinationTypeId == 2);

        //private ObservableCollection<PriceListModel> _ocPriceLists;
        //public ObservableCollection<PriceListModel> OCPriceLists => _ocPriceLists ?? (_ocPriceLists = new ObservableCollection<PriceListModel>(PriceLists));
        #endregion

        #region public methods
        //public void Reset()
        //{
        //    _ocProducts = new ObservableCollection<ProductModel>(Products);
        //    _ocPriceLists = new ObservableCollection<PriceListModel>(PriceLists);
        //}

        //public void Save()
        //{
        //    Products = OCProducts.ToList();

        //    //PriceLists = OCPriceLists.ToList();
        //    //PriceLists.ForEach(pl => pl.Prices = pl.OCPrices.Where(p => p.UnitPrice != 0).ToList());
        //}

        //public void SetProductPrices(int priceListId)
        //{
        //    foreach (var product in Products)
        //    {
        //        product.ChosenPrice = product.Prices
        //            .FirstOrDefault(p => p.PriceListId == priceListId);

        //        if (product.ChosenPrice == null)
        //        {
        //            product.ChosenPrice = new PriceModel
        //            {
        //                ProductId = product.ProductId,
        //                PriceListId = priceListId
        //            };

        //            product.Prices.Add(product.ChosenPrice);
        //        }
        //    }
        //}
        #endregion

        #region events
        public event Action ProductSourceTypeChanged;
        public event Action ProductDestinationTypeChanged;
        #endregion

        #region dropdowns
        public IProductDropdowns Dropdowns => ProductDropdownsProxy.Instance;

        public IList<ProductGroupDropdownModel> ProductGroupsOnly =>
            Dropdowns?.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId).ToList();

        public IList<ProductCollectionDropdownModel> ProductCollections =>
            Dropdowns?.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownModel> ProductDesigns =>
            Dropdowns?.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();
        #endregion
    }
}
