using FMS.ServiceLayer.Dtos;
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

        public ProductListViewModel ProductListViewModel { get; set; }

        #region event handlers
        private void ProductListViewModel_RequestOpenItem(ProductListDto dto)
        {
            WorkspaceManager.OpenWorkspace<IProductViewModelFactory>(dto?.ProductBaseId ?? 0);
        }
        #endregion
    }
}
