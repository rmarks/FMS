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

            //if (ProductBaseViewModel.Model.HasSize)
            //{
            //    ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSizesViewModel>(productBaseId));
            //}
        }
        #endregion
    }
}
