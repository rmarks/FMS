using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductViewModel : WorkspaceViewModelBase
    {
        private IProductAppService _productAppService;

        public ProductViewModel(int productBaseId, 
                                IWorkspaceManager workspaceManager,
                                IProductAppService productAppService) : base(workspaceManager)
        {
            _productAppService = productAppService;

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

            ProductBaseViewModel = new ProductBaseViewModel(productBaseId, _productAppService);
            ProductTabs.Add(ProductBaseViewModel);

            if (ProductBaseViewModel.Model.HasSize)
            {
                ProductTabs.Add(new ProductSizesViewModel(productBaseId, _productAppService));
            }
        }
        #endregion
    }
}
