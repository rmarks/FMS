using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductFacadeViewModel : WorkspaceViewModelBase
    {
        private readonly IProductFacadeService _productFacadeService;
        private readonly IViewModelFactory _viewModelFactory;

        public ProductFacadeViewModel(int productBaseId, 
                                      IWorkspaceManager workspaceManager,
                                      IProductFacadeService productFacadeService,
                                      IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            _productFacadeService = productFacadeService;
            ProductBaseModel = _productFacadeService.GetProductBaseModel(productBaseId);
            _viewModelFactory = viewModelFactory;

            InitializeProductTabs(productBaseId);
        }

        #region properties
        public override string DisplayName => $"Toode {ProductBaseViewModel.Model?.ProductBaseCode}";

        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }

        public ProductBaseViewModel ProductBaseViewModel { get; private set; }

        public ProductBaseModel ProductBaseModel { get; set; }
        #endregion

        #region helpers
        private void InitializeProductTabs(int productBaseId)
        {
            ProductTabs = new ObservableCollection<ViewModelBase>();

            ProductBaseViewModel = _viewModelFactory.CreateInstance<ProductBaseViewModel>(productBaseId);
            ProductTabs.Add(ProductBaseViewModel);

            //ProductTabs.Add(_viewModelFactory.CreateInstance<ProductPricesViewModel>(productBaseId));
            ProductTabs.Add(_viewModelFactory.CreateInstance<ProductPricesViewModel, ProductBaseModel>(ProductBaseModel));

            if (ProductBaseViewModel.Model.ProductSourceTypeId == 2)
            {
                //ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel>(productBaseId));
                //ProductTabs.Add(new ProductSourceCompaniesViewModel(ProductBaseModel, _productFacadeService));
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel, ProductBaseModel>(ProductBaseModel));
            }

            if (ProductBaseViewModel.Model.ProductDestinationTypeId == 2)
            {
                //ProductTabs.Add(_viewModelFactory.CreateInstance<ProductDestCompaniesViewModel>(productBaseId));
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductDestCompaniesViewModel, ProductBaseModel>(ProductBaseModel));
            }
        }
        #endregion
    }
}
