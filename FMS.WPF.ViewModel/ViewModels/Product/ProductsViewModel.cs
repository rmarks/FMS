using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class ProductsViewModel : ViewModelBase, IWorkspace
    {
        public ProductsViewModel(IWorkspaceManager workspaceManager, 
                                 IViewModelFactory viewModelFactory)
        {
            WorkspaceManager = workspaceManager;
            DisplayName = "Tooted";

            ProductListViewModel = viewModelFactory.CreateInstance<ProductListViewModel>();
            ProductListViewModel.RequestOpenItem += ProductListViewModel_RequestOpenItem;
        }

        public ProductListViewModel ProductListViewModel { get; }

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion

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
