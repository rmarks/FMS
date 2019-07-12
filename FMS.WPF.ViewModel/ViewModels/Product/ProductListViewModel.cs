using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
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

            InitializeDropdowns();
        }

        public ProductListOptionsModel Options { get; } = new ProductListOptionsModel();

        public ProductDropdownsDto Dropdowns { get; private set; }

        public override void Refresh(bool selectFirstItem = false)
        {
            Items = _productService.GetProducts(Options.MapTo<ProductListOptionsDto>());
        }

        #region Helpers
        private async void InitializeDropdowns()
        {
            Dropdowns = await _dropdownsService.GetProductDropdownsAsync();
        }
        #endregion Helpers
    }
}
