using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Models;
using System;

namespace FMS.WPF.ViewModels
{
    public class ProductInfoViewModel : GenericEditableViewModelBase<ProductInfoModel>
    {
        private IProductService _productService;

        public ProductInfoViewModel(int productBaseId,
                                    IProductService productService)
        {
            DisplayName = "Üldandmed";

            _productService = productService;
            InitializeModelAsync(productBaseId);
        }

        #region overrides
        protected override bool ConfirmDelete()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteItem(ProductInfoModel model)
        {
            throw new NotImplementedException();
        }

        protected override bool SaveItem(ProductInfoModel model)
        {
            return false;
        }
        #endregion

        #region helpers
        private async void InitializeModelAsync(int productBaseId)
        {
            var dto = _productService.GetProduct(productBaseId);
            Model = dto.MapTo<ProductInfoModel>();
            Model.Dropdowns = await _productService.GetProductDropdownsAsync();
        }
        #endregion
    }
}
