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
        public override string DisplayName => Model?.ProductBaseCode == null ? "Uus toode" : "Toode " + Model.ProductBaseCode;
        public ObservableCollection<ViewModelBase> ProductTabs { get; private set; }
        public string PictureLocation { get; private set; }
        public ProductBaseViewModel ProductBaseViewModel { get; set; }
        public ProductPricesViewModel ProductPricesViewModel { get; set; }
        public ProductSourceCompaniesViewModel ProductSourceCompaniesViewModel { get; set; }
        public ProductDestCompaniesViewModel ProductDestCompaniesViewModel { get; set; }
        #endregion

        #region overrides
        protected override bool SaveItem(ProductBaseModel model)
        {
            Model = _service.Save(model);
            UpdateModelPointer();

            return true;
        }
        #endregion

        #region helpers
        private void Initialize(int productBaseId)
        {
            Model = _service.GetProductBaseModel(productBaseId);

            PictureLocation = PictureLocationHelper.GetPictureLocation(Model.ProductBaseCode);

            InitializeProductTabs();

            EditModeChanged += OnEditModeChanged;
            ItemEditCancelled += OnItemEditCancelled;

            Model.ProductSourceTypeChanged += ManageProductSource;
            Model.ProductDestinationTypeChanged += ManageProductDestination;

            if (Model.IsNew)
            {
                EditCommand.Execute(null);
            }
        }

        private void InitializeProductTabs()
        {
            ProductTabs = new ObservableCollection<ViewModelBase>();

            ProductBaseViewModel = _viewModelFactory.CreateInstance<ProductBaseViewModel, ProductBaseModel>(Model);
            ProductTabs.Add(ProductBaseViewModel);

            ProductPricesViewModel = _viewModelFactory.CreateInstance<ProductPricesViewModel, ProductBaseModel>(Model);
            ProductTabs.Add(ProductPricesViewModel);

            InitializeProductSourceTab();
            InitializeProductDestinationTab();
        }

        private void InitializeProductSourceTab()
        {
            if (Model.IsPurchased)
            {
                if (ProductSourceCompaniesViewModel == null)
                {
                    //ProductSourceCompaniesViewModel = _viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel, ProductBaseModel>(Model);
                    ProductSourceCompaniesViewModel = _viewModelFactory.CreateInstance<ProductSourceCompaniesViewModel>();
                    ProductSourceCompaniesViewModel.Model = Model;
                    ProductSourceCompaniesViewModel.IsEditMode = IsEditMode;
                    ProductTabs.Add(ProductSourceCompaniesViewModel);
                }
            }
            else
            {
                if (ProductSourceCompaniesViewModel != null)
                {
                    ProductTabs.Remove(ProductSourceCompaniesViewModel);
                    ProductSourceCompaniesViewModel = null;
                }
            }
        }

        private void InitializeProductDestinationTab()
        {
            if (Model.IsForOutsource)
            {
                if (ProductDestCompaniesViewModel == null)
                {
                    //ProductDestCompaniesViewModel = _viewModelFactory.CreateInstance<ProductDestCompaniesViewModel, ProductBaseModel>(Model);
                    ProductDestCompaniesViewModel = _viewModelFactory.CreateInstance<ProductDestCompaniesViewModel>();
                    ProductDestCompaniesViewModel.Model = Model;
                    ProductDestCompaniesViewModel.IsEditMode = IsEditMode;
                    ProductTabs.Add(ProductDestCompaniesViewModel);
                }
            }
            else
            {
                if (ProductDestCompaniesViewModel != null)
                {
                    ProductTabs.Remove(ProductDestCompaniesViewModel);
                    ProductDestCompaniesViewModel = null;
                }
            }
        }

        private void ManageProductSource()
        {
            if (Model.Products != null && Model.Products.Count != 0)
            {
                if (Model.IsPurchased)
                {
                    Model.Products.ForEach(p => p.ProductSource = new ProductSourceModel());
                }
                else
                {
                    Model.Products.ForEach(p => p.ProductSource = null);
                }
            }

            InitializeProductSourceTab();
        }

        private void ManageProductDestination()
        {
            if (Model.Products != null && Model.Products.Count != 0)
            {
                if (Model.IsForOutsource)
                {
                    Model.Products.ForEach(p => p.ProductDestination = new ProductDestinationModel());
                }
                else
                {
                    Model.Products.ForEach(p => p.ProductDestination = null);
                }
            }

            InitializeProductDestinationTab();
        }

        private void UpdateModelPointer()
        {
            Model.ProductSourceTypeChanged += ManageProductSource;
            Model.ProductDestinationTypeChanged += ManageProductDestination;

            ProductBaseViewModel.Model = Model;
            ProductPricesViewModel.Model = Model;

            if (ProductSourceCompaniesViewModel != null)
            {
                ProductSourceCompaniesViewModel.Model = Model;
            }
            if (ProductDestCompaniesViewModel != null)
            {
                ProductDestCompaniesViewModel.Model = Model;
            }
        }
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

        private void OnItemEditCancelled()
        {
            if (Model.ProductBaseId == 0)
            {
                CloseWorkspaceCommand.Execute(null);
            }
            else
            {
                Model.Reset();
            }
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
