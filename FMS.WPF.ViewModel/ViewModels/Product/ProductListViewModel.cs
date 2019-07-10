using FMS.WPF.Application.Common;
using FMS.WPF.Application.Services;
using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>
    {
        private IProductsService _productsService;

        public ProductListViewModel(IProductsService productsService)
        {
            _productsService = productsService;
            Refresh();
        }

        public ProductListOptionsModel Options { get; set; } = new ProductListOptionsModel();

        public IProductDropdownTables DropdownTables { get; set; }

        public override void Refresh(bool selectFirstItem = false)
        {
            Items = _productsService.GetProductList(Options);
        }
    }
}
