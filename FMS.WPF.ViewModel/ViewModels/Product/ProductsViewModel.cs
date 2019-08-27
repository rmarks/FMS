using FMS.WPF.Models;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class ProductsViewModel : WorkspaceViewModelBase
    {
        public ProductsViewModel(IWorkspaceManager workspaceManager, 
                                 IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            DisplayName = "Tooted";

            ProductListViewModel = viewModelFactory.CreateInstance<ProductListViewModel>();
            ProductListViewModel.RequestOpenItem += ProductListViewModel_RequestOpenItem;
        }

        public ProductListViewModel ProductListViewModel { get; }

        #region event handlers
        private void ProductListViewModel_RequestOpenItem(ProductListModel model)
        {
            if (model != null)
            {
                WorkspaceManager.OpenWorkspace<ProductFacadeViewModel>(model.ProductBaseId);
            }
        }
        #endregion
    }
}
