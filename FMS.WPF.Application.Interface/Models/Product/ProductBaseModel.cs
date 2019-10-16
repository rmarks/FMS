using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductBaseProductVariationModel> ProductVariationsLink { get; set; } = 
            new ObservableCollection<ProductBaseProductVariationModel>();
        public ObservableCollection<PriceListModel> PriceLists { get; set; } = new ObservableCollection<PriceListModel>();
        #endregion

        #region view properties
        public string ProductStatusName => Dropdowns.ProductStatuses
                    .FirstOrDefault(p => p.ProductStatusId == ProductStatusId)
                    .Name;
        public bool IsPurchased => (ProductSourceTypeId == 2);
        public bool IsForOutsource => (ProductDestinationTypeId == 2);
        #endregion

        #region public methods
        public void ShowProductsChosenPrices(int selectedPriceListId)
        {
            foreach (var product in Products)
            {
                product.ChosenPrice = product.Prices
                    .FirstOrDefault(p => p.PriceListId == selectedPriceListId);

                if (product.ChosenPrice == null)
                {
                    product.ChosenPrice = new PriceModel
                    {
                        ProductId = product.ProductId,
                        PriceListId = selectedPriceListId
                    };

                    product.Prices.Add(product.ChosenPrice);
                }
            }
        }

        public void AddProduct(int? selectedPriceListId)
        {
            var productModel = new ProductModel
            {
                ProductBaseId = ProductBaseId,
                ProductCode = ProductBaseCode,
                ProductName = ProductBaseName,
                ProductSource = IsPurchased ? new ProductSourceModel() : null,
                ProductDestination = IsForOutsource ? new ProductDestinationModel() : null,
            };

            foreach (var priceList in PriceLists)
            {
                PriceModel priceModel = new PriceModel
                {
                    PriceListId = priceList.PriceListId,
                };
                productModel.Prices.Add(priceModel);
            }

            productModel.ChosenPrice = productModel.Prices
                    .FirstOrDefault(p => p.PriceListId == selectedPriceListId);

            Products.Add(productModel);
        }

        public void AddPriceList(PriceListModel addedPriceList)
        {
            PriceLists.Add(addedPriceList);

            foreach (var productModel in Products)
            {
                productModel.Prices.Add(new PriceModel
                {
                    ProductId = productModel.ProductId,
                    PriceListId = addedPriceList.PriceListId
                });
            }

            RaisePropertyChanged(nameof(AddablePriceLists));
        }
        #endregion

        #region overrides
        public override bool IsNew => (ProductBaseId == 0);

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
            
            if (propertyName == nameof(ProductSourceTypeId))
            {
                RaisePropertyChanged(nameof(IsPurchased));
            }
            else if (propertyName == nameof(ProductDestinationTypeId))
            {
                RaisePropertyChanged(nameof(IsForOutsource));
            }
            else if (propertyName == nameof(ProductStatusId))
            {
                RaisePropertyChanged(nameof(ProductStatusName));
            }
        }
        #endregion

        #region dropdowns
        public IProductDropdowns Dropdowns => ProductDropdownsProxy.Instance;

        public IList<ProductGroupDropdownModel> ProductGroupsOnly =>
            Dropdowns?.ProductGroups.Where(pg => pg.ProductTypeId == ProductTypeId).ToList();

        public IList<ProductCollectionDropdownModel> ProductCollections =>
            Dropdowns?.ProductCollections.Where(pc => pc.ProductBrandId == ProductBrandId || pc.ProductBrandId == null).ToList();

        public IList<ProductDesignDropdownModel> ProductDesigns =>
            Dropdowns?.ProductDesigns.Where(pd => pd.ProductCollectionId == ProductCollectionId || pd.ProductCollectionId == null).ToList();

        public List<PriceListModel> AddablePriceLists => Dropdowns.PriceLists
            .Where(pl => PriceLists.All(o => o.PriceListId != pl.PriceListId))
            .Select(pl => pl)
            .ToList();
        #endregion
    }
}
