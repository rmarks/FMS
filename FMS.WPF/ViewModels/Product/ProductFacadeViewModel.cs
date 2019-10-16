using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Utils;
using FMS.WPF.Helpers;
using System.Linq;

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
        public string PictureLocation => PictureLocationHelper.GetPictureLocation(Model?.ProductBaseCode);

        private PriceListModel _selectedPriceList;
        public PriceListModel SelectedPriceList
        {
            get => _selectedPriceList;
            set
            {
                _selectedPriceList = value;
                if (_selectedPriceList != null)
                {
                    Model.ShowProductsChosenPrices(_selectedPriceList.PriceListId);
                }
                RaisePropertyChanged(nameof(IsPriceListSelected));
            }
        }

         private PriceListModel _selectedAddablePriceList;
        public PriceListModel SelectedAddablePriceList 
        { 
            get => _selectedAddablePriceList;
            set
            {
                _selectedAddablePriceList = value;
                AddPriceListCommand.RaiseCanExecuteChanged();
            } 
        }

        public bool IsVariationVisible => IsEditMode || (!IsEditMode && Model.ProductVariationsLink.Count != 0);
        public bool IsPriceListSelected => SelectedPriceList != null;
        #endregion

        #region overrides
        protected override bool SaveItem(ProductBaseModel model)
        {
            int productBaseId = _service.Save(Model);
            InitializeModel(productBaseId);

            RaisePropertyChanged(nameof(DisplayName));

            return true;
        }
        #endregion

        #region commands
        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand => _addProductCommand ?? (_addProductCommand = new RelayCommand(AddProduct, () => CanAddProduct));
        public bool CanAddProduct => (IsEditMode && ((Model.Products.Count == 0 && Model.ProductVariationsLink.Count == 0)
                                                    || Model.ProductVariationsLink.Count != 0));
        private void AddProduct()
        {
            Model.AddProduct(SelectedPriceList?.PriceListId);
        }

        private RelayCommand _addPriceListCommand;
        public RelayCommand AddPriceListCommand => _addPriceListCommand ?? (_addPriceListCommand = new RelayCommand(AddPriceList, () => CanAddPriceList));
        public bool CanAddPriceList => IsEditMode && (SelectedAddablePriceList != null) && (SelectedAddablePriceList.PriceListId != 0);
        private void AddPriceList()
        {
            var selectedAddablePriceList = SelectedAddablePriceList;

            Model.AddPriceList(selectedAddablePriceList);

            SelectedPriceList = selectedAddablePriceList;
        }
        #endregion

        #region helpers
        private void Initialize(int productBaseId)
        {
            InitializeModel(productBaseId);

            ItemEditCancelled += OnItemEditCancelled;
            EditModeChanged += OnEditModeChanged;

            if (Model.IsNew)
            {
                EditCommand.Execute(null);
            }
        }

        private void InitializeModel(int productBaseId)
        {
            Model = _service.GetProductBaseModel(productBaseId);

            InitializeSelections();
        }

        private void InitializeSelections()
        {
            SelectedPriceList = Model.PriceLists.FirstOrDefault();
        }
        #endregion

        #region event handlers
        private void OnItemEditCancelled()
        {
            if (Model.ProductBaseId == 0)
            {
                CloseWorkspaceCommand.Execute(null);
            }
            else
            {
                InitializeSelections();
            }
        }

        private void OnEditModeChanged(bool isEditMode)
        {
            RaisePropertyChanged(nameof(IsVariationVisible));

            AddProductCommand.RaiseCanExecuteChanged();
            CloseWorkspaceCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        
        private RelayCommand _closeWorkspaceCommand;
        public RelayCommand CloseWorkspaceCommand => _closeWorkspaceCommand ?? 
            (_closeWorkspaceCommand = new RelayCommand(() => WorkspaceManager.CloseWorkspace(this), () => CanCloseWorkspace));
        public bool CanCloseWorkspace => !IsEditMode;
        #endregion
    }
}
