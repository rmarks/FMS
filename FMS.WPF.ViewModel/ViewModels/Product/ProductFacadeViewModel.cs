using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductFacadeViewModel : WorkspaceViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;

        public ProductFacadeViewModel(int productBaseId, 
                                      IWorkspaceManager workspaceManager,
                                      IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            _viewModelFactory = viewModelFactory;

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

            ProductBaseViewModel = _viewModelFactory.CreateInstance<ProductBaseViewModel>(productBaseId);
            ProductTabs.Add(ProductBaseViewModel);

            ProductTabs.Add(_viewModelFactory.CreateInstance<ProductPricesViewModel>(productBaseId));

            if (ProductBaseViewModel.Model.ProductSourceTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel>(productBaseId));
            }

            if (ProductBaseViewModel.Model.ProductDestinationTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductDestCompaniesViewModel>(productBaseId));
            }
        }
        #endregion
    }
}
