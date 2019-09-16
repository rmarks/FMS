using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductFacadeViewModel : GenericEditableViewModelBase2<ProductBaseModel>, IWorkspace
    {
        private readonly IProductFacadeService _service;
        private readonly IViewModelFactory _viewModelFactory;

        public ProductFacadeViewModel(int productBaseId, 
                                      IWorkspaceManager workspaceManager,
                                      IProductFacadeService service,
                                      IViewModelFactory viewModelFactory)
        {
            WorkspaceManager = workspaceManager;
            _service = service;
            _viewModelFactory = viewModelFactory;

            Initialize(productBaseId);
        }

        #region properties
        public override string DisplayName => $"Toode {Model?.ProductBaseCode}";
        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }
        public string PictureLocation { get; private set; }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion

        #region helpers
        private void Initialize(int productBaseId)
        {
            Model = _service.GetProductBaseModel(productBaseId);

            PictureLocation = PictureLocationHelper.GetPictureLocation(Model.ProductBaseCode);

            //product tabs
            ProductTabs = new ObservableCollection<ViewModelBase>();
            
            ProductTabs.Add(_viewModelFactory.CreateInstance<ProductBaseViewModel, ProductBaseModel>(Model));

            ProductTabs.Add(_viewModelFactory.CreateInstance<ProductPricesViewModel, ProductBaseModel>(Model));

            if (Model.ProductSourceTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel, ProductBaseModel>(Model));
            }

            if (Model.ProductDestinationTypeId == 2)
            {
                ProductTabs.Add(_viewModelFactory.CreateInstance<ProductDestCompaniesViewModel, ProductBaseModel>(Model));
            }
        }
        #endregion
    }
}
