using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;
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

        public bool IsPurchased => (Model.ProductSourceTypeId == 2);
        public bool IsForOutsource => (Model.ProductDestinationTypeId == 2);

        public ObservableCollection<ProductModel> OCProducts { get; set; }
        public ObservableCollection<PriceListModel> OCPriceLists { get; set; }
        public ObservableCollection<ProductBaseProductVariationModel> OCProductVariations { get; set; }

        private PriceListModel _selectedPriceList;
        public PriceListModel SelectedPriceList
        {
            get => _selectedPriceList;
            set
            {
                _selectedPriceList = value;
                if (_selectedPriceList != null)
                {
                    SetProductPrices(_selectedPriceList.PriceListId);
                }
            }
        }

        public bool IsVariationVisible => IsEditMode || (!IsEditMode && Model.ProductVariationsLink.Count != 0);

        private PriceListModel _addablePriceList;
        public PriceListModel AddablePriceList 
        { 
            get => _addablePriceList;
            set
            {
                _addablePriceList = value;
                AddPriceListCommmand.RaiseCanExecuteChanged();
            } 
        }
        #endregion

        #region overrides
        protected override bool SaveItem(ProductBaseModel model)
        {
            Model.Products = OCProducts.ToList();
            Model.ProductVariationsLink = OCProductVariations.ToList();

            int productBaseId = _service.Save(Model);
            InitializeModel(productBaseId);

            return true;
        }
        #endregion

        #region commands
        private RelayCommand _addProductCommmand;
        public ICommand AddProductCommand => _addProductCommmand ?? (_addProductCommmand = new RelayCommand(AddProduct, () => CanAddProduct));
        public bool CanAddProduct => (IsEditMode && ((OCProducts.Count == 0 && Model.ProductVariationsLink.Count == 0)
                                                    || Model.ProductVariationsLink.Count != 0));
        private void AddProduct()
        {
            var productModel = new ProductModel
            {
                ProductBaseId = Model.ProductBaseId,
                ProductCode = Model.ProductBaseCode,
                ProductName = Model.ProductBaseName,
                ProductSource = IsPurchased ? new ProductSourceModel() : null,
                ProductDestination = IsForOutsource ? new ProductDestinationModel() : null,
                ChosenPrice = new PriceModel { PriceListId = SelectedPriceList.PriceListId }
            };
            productModel.Prices.Add(productModel.ChosenPrice);

            foreach (var priceList in OCPriceLists)
            {
                PriceModel priceModel = new PriceModel
                {
                    PriceListId = priceList.PriceListId,
                };
                productModel.Prices.Add(priceModel);
            }

            OCProducts.Add(productModel);
        }

        private RelayCommand _addPriceListCommmand;
        public RelayCommand AddPriceListCommmand => _addPriceListCommmand ?? (_addPriceListCommmand = new RelayCommand(AddPriceList, () => CanAddPriceList));
        public bool CanAddPriceList => (AddablePriceList.PriceListId != 0);
        private void AddPriceList()
        {
            
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

            InitializeCollections();
            Model.ProductSourceTypeChanged += OnProductSourceTypeChanged;
            Model.ProductDestinationTypeChanged += OnProductDestinationTypeChanged;
        }

        private void InitializeCollections()
        {
            OCProducts = new ObservableCollection<ProductModel>(Model.Products);
            OCPriceLists = new ObservableCollection<PriceListModel>(Model.PriceLists);
            SelectedPriceList = OCPriceLists.FirstOrDefault();
            OCProductVariations = new ObservableCollection<ProductBaseProductVariationModel>(Model.ProductVariationsLink);
        }

        private void SetProductPrices(int priceListId)
        {
            foreach (var product in OCProducts)
            {
                product.ChosenPrice = product.Prices
                    .FirstOrDefault(p => p.PriceListId == priceListId);

                if (product.ChosenPrice == null)
                {
                    product.ChosenPrice = new PriceModel
                    {
                        ProductId = product.ProductId,
                        PriceListId = priceListId
                    };

                    product.Prices.Add(product.ChosenPrice);
                }
            }
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
                InitializeCollections();
            }
        }

        private void OnEditModeChanged(bool isEditMode)
        {
            _addProductCommmand.RaiseCanExecuteChanged();

            RaisePropertyChanged(nameof(IsVariationVisible));
        }

        private void OnProductSourceTypeChanged()
        {
            RaisePropertyChanged(nameof(IsPurchased));

            OCProducts.ToList().ForEach(p => p.ProductSource = IsPurchased ? new ProductSourceModel() : null);
        }

        private void OnProductDestinationTypeChanged()
        {
            RaisePropertyChanged(nameof(IsForOutsource));

            OCProducts.ToList().ForEach(p => p.ProductDestination = IsForOutsource ? new ProductDestinationModel() : null);
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
