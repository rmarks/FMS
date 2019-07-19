using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListDto>
    {
        private IProductService _productService;
        private IProductDropdownsService _dropdownsService;

        public ProductListViewModel(IProductService productService,
                                    IProductDropdownsService dropdownsService)
        {
            _productService = productService;
            _dropdownsService = dropdownsService;

            InitializeOptionsModel();
        }

        public ProductListOptionsModel OptionsModel { get; private set; }

        #region overrides
        public override void Refresh(bool selectFirstItem = false)
        {
            Items = _productService.GetProducts(OptionsModel.OptionsDto);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
            ClearItems();
        }
        #endregion overrides

        #region helpers
        private async void InitializeOptionsModel()
        {
            OptionsModel = new ProductListOptionsModel
            {
                OptionsDto = new ProductListOptionsDto(),
                Dropdowns = await _dropdownsService.GetProductDropdownsAsync()
            };
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
