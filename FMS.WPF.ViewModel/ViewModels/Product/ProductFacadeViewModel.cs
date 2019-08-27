using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductFacadeViewModel : WorkspaceViewModelBase
    {
        private readonly IProductFacadeService _service;
        private readonly IViewModelFactory _viewModelFactory;

        public ProductFacadeViewModel(int productBaseId, 
                                      IWorkspaceManager workspaceManager,
                                      IProductFacadeService service,
                                      IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            _service = service;
            _viewModelFactory = viewModelFactory;

            Initialize(productBaseId);
        }

        #region properties
        public override string DisplayName => $"Toode {ProductBaseViewModel.Model?.ProductBaseCode}";

        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }

        public ProductBaseViewModel ProductBaseViewModel { get; private set; }

        public ProductBaseModel ProductBaseModel { get; set; }
        #endregion

        #region helpers
        private void Initialize(int productBaseId)
        {
            ProductBaseModel = _service.GetProductBaseModel(productBaseId);

            ProductBaseViewModel = _viewModelFactory.CreateInstance<ProductBaseViewModel, ProductBaseModel>(ProductBaseModel);

            //product tabs
            ProductTabs = new ObservableCollection<ViewModelBase>();
            
            ProductTabs.Add(ProductBaseViewModel);

            ProductTabs.Add(_viewModelFactory.CreateInstance<ProductPricesViewModel, ProductBaseModel>(ProductBaseModel));

            if (ProductBaseViewModel.Model.ProductSourceTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel, ProductBaseModel>(ProductBaseModel));
            }

            if (ProductBaseViewModel.Model.ProductDestinationTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductDestCompaniesViewModel, ProductBaseModel>(ProductBaseModel));
            }
        }
        #endregion
    }
}
