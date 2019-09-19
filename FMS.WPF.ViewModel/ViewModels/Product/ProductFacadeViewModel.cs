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
        public ProductBaseViewModel ProductBaseViewModel { get; set; }
        public ProductPricesViewModel ProductPricesViewModel { get; set; }
        public ProductSourceCompaniesViewModel ProductSourceCompaniesViewModel { get; set; }
        public ProductDestCompaniesViewModel ProductDestCompaniesViewModel { get; set; }
        #endregion

        #region event handlers
        private void OnEditModeChanged(bool isEditMode)
        {
            ProductBaseViewModel.IsEditMode = isEditMode;
            ProductPricesViewModel.IsEditMode = isEditMode;
            
            if (ProductSourceCompaniesViewModel != null)
            {
                ProductSourceCompaniesViewModel.IsEditMode = isEditMode;
            }
            if (ProductDestCompaniesViewModel != null)
            {
                ProductDestCompaniesViewModel.IsEditMode = isEditMode;
            }
        }
        #endregion

        #region helpers
        private void Initialize(int productBaseId)
        {
            Model = _service.GetProductBaseModel(productBaseId);

            PictureLocation = PictureLocationHelper.GetPictureLocation(Model.ProductBaseCode);

            //product tabs
            ProductTabs = new ObservableCollection<ViewModelBase>();

            ProductBaseViewModel = _viewModelFactory.CreateInstance<ProductBaseViewModel, ProductBaseModel>(Model);
            ItemEditCancelled += ProductBaseViewModel.OnProductEditCancelled;
            ProductTabs.Add(ProductBaseViewModel);

            ProductPricesViewModel = _viewModelFactory.CreateInstance<ProductPricesViewModel, ProductBaseModel>(Model);
            ItemEditCancelled += ProductPricesViewModel.OnProductEditCancelled;
            ProductTabs.Add(ProductPricesViewModel);

            if (Model.ProductSourceTypeId == 2)
            {
                ProductSourceCompaniesViewModel = _viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel, ProductBaseModel>(Model);
                ItemEditCancelled += ProductSourceCompaniesViewModel.OnProductEditCancelled;
                ProductTabs.Add(ProductSourceCompaniesViewModel);
            }

            if (Model.ProductDestinationTypeId == 2)
            {
                ProductDestCompaniesViewModel = _viewModelFactory.CreateInstance<ProductDestCompaniesViewModel, ProductBaseModel>(Model);
                ItemEditCancelled += ProductDestCompaniesViewModel.OnProductEditCancelled;
                ProductTabs.Add(ProductDestCompaniesViewModel);
            }

            EditModeChanged += OnEditModeChanged;
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
