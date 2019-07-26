using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>
    {
        private IProductsVmService _productService;

        public ProductListViewModel(IProductsVmService productService)
        {
            _productService = productService;

            InitializeOptionsModelAsync();
        }

        public ProductListOptionsModel OptionsModel { get; private set; }

        #region overrides
        public override void Refresh(bool selectFirstItem = false)
        {
            Items = _productService.GetProductListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
            ClearItems();
        }
        #endregion overrides

        #region helpers
        private async void InitializeOptionsModelAsync()
        {
            OptionsModel = await _productService.GetProductListOptionsModelAsync();
            OptionsModel.OptionChanged += ClearItems;
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;
        }
        #endregion helpers
    }
}
