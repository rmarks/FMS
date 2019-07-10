using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class ProductsViewModel : WorkspaceViewModelBase
    {
        public ProductsViewModel(IWorkspaceManager workspaceManager, 
                                 IProductListViewModelFactory productListViewModelFactory) : base(workspaceManager)
        {
            DisplayName = "Tooted";

            ProductListViewModel = productListViewModelFactory.CreateInstance();
        }

        public ProductListViewModel ProductListViewModel { get; set; }
    }
}
