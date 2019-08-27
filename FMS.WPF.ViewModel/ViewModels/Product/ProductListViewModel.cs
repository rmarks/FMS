using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>
    {
        #region Fields
        private IProductListService _service;
        #endregion

        public ProductListViewModel(IProductListService service)
        {
            _service = service;

            InitializeOptionsModel();
        }

        #region properties
        public ProductListOptionsModel OptionsModel { get; private set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetProductListModels(OptionsModel);
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
            OptionsModel = _service.GetProductListOptionsModel();
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
