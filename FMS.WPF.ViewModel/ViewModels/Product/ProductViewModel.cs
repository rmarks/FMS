using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductViewModel : WorkspaceViewModelBase
    {
        private IProductVmService _productVmService;

        public ProductViewModel(int productBaseId, 
                                IWorkspaceManager workspaceManager,
                                IProductVmService productVmService) : base(workspaceManager)
        {
            _productVmService = productVmService;

            InitializeProductTabs(productBaseId);
        }

        #region properties
        public override string DisplayName => $"Toode {ProductBaseViewModel.Model?.ProductBaseCode}";

        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }

        public ProductBaseViewModel ProductBaseViewModel { get; private set; }
        #endregion

        #region helpers
        private void InitializeProductTabs(int productBaseId)
        {
            ProductTabs = new ObservableCollection<ViewModelBase>();

            ProductBaseViewModel = new ProductBaseViewModel(productBaseId, _productVmService);
            ProductTabs.Add(ProductBaseViewModel);

            if (ProductBaseViewModel.Model.HasSize)
            {
                ProductTabs.Add(new ProductSizesViewModel(productBaseId, _productVmService));
            }
        }
        #endregion
    }
}
