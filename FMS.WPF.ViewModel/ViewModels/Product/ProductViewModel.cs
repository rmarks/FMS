using FMS.ServiceLayer.Interfaces;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductViewModel : WorkspaceViewModelBase
    {
        public ProductViewModel(int productBaseId, 
                                IWorkspaceManager workspaceManager,
                                IProductService productService) : base(workspaceManager)
        {
            ProductInfoViewModel = new ProductInfoViewModel(productBaseId, productService);

            InitializeProductTabs();
        }

        #region properties
        public override string DisplayName => $"Toode {ProductInfoViewModel.Model?.ProductBaseCode}";

        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }

        public ProductInfoViewModel ProductInfoViewModel { get; }
        #endregion

        #region helpers
        private void InitializeProductTabs()
        {
            ProductTabs = new ObservableCollection<ViewModelBase>();
            ProductTabs.Add(ProductInfoViewModel);
        }
        #endregion
    }
}
