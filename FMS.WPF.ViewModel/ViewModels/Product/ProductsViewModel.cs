using FMS.WPF.Application.Interface.Models;
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
            ProductListViewModel.RequestOpenItem += ProductListViewModel_RequestOpenItem;
        }

        public ProductListViewModel ProductListViewModel { get; }

        #region event handlers
        private void ProductListViewModel_RequestOpenItem(ProductListModel dto)
        {
            WorkspaceManager.OpenWorkspace<IProductViewModelFactory>(dto?.ProductBaseId ?? 0);
        }
        #endregion
    }
}
