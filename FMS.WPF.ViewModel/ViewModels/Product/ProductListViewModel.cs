using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>
    {
        #region Fields
        private IProductListService _productListService;
        #endregion

        public ProductListViewModel(IProductListService productListService)
        {
            _productListService = productListService;

            InitializeOptionsModel();
        }

        #region properties
        public ProductListOptionsModel OptionsModel { get; private set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _productListService.GetProductListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
            ClearItems();
        }
        #endregion

        #region helpers
        private void InitializeOptionsModel()
        {
            OptionsModel = _productListService.GetProductListOptionsModel();
            OptionsModel.OptionChanged += ClearItems;
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;
        }
        #endregion
    }
}
