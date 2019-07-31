using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>
    {
        private IProductAppService _productAppService;

        public ProductListViewModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;

            InitializeOptionsModel();
        }

        #region properties
        public ProductListOptionsModel OptionsModel { get; private set; }
        #endregion

        #region overrides
        public override void Refresh(bool selectFirstItem = false)
        {
            Items = _productAppService.GetProductListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
            ClearItems();
        }
        #endregion overrides

        #region helpers
        private void InitializeOptionsModel()
        {
            OptionsModel = _productAppService.GetProductListOptionsModel();
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
