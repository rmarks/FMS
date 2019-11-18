using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Helpers;
using FMS.WPF.Models;
using FMS.WPF.Utils;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class LocationInventoryListViewModel : GenericListViewModelBase<LocationInventoryListModel>, IWorkspace
    {
        private readonly ILocationInventoryListService _service;

        public LocationInventoryListViewModel(LocationListModel model, 
                                              IWorkspaceManager workspaceManager,
                                              ILocationInventoryListService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;

            Initialize(model);
        }

        #region properties
        public LocationInventoryListOptionModel OptionsModel { get; set; }
        public ProductDeliveriesModel ProductDeliveriesModel { get; set; }

        public int TotalReservedQuantity { get; set; }
        public int TotalStockQuantity { get; set; }

        public string ProductPicturePath { get; set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetLocationInventoryListModels(OptionsModel);
            ItemsCount = Items.Count;

            TotalReservedQuantity = Items.Sum(i => i.ReservedQuantity);
            TotalStockQuantity = Items.Sum(i => i.StockQuantity);
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
        }
        #endregion

        #region helpers
        private void Initialize(LocationListModel model)
        {
            DisplayName = $"{model.LocationName} laoseis";

            SelectedItemChanged += (p) => LoadProductDeliveriesModel();

            InitializeOptionsModel(model);

            Refresh();
        }

        private void InitializeOptionsModel(LocationListModel model)
        {
            OptionsModel = _service.GetLocationInventoryListOptionModel(model.LocationId);

            OptionsModel.OptionChanged += ClearItems;

            OptionsModel.SetDefaultOptions();
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;

            ClearProductDeliveriesModel();
        }

        private void LoadProductDeliveriesModel()
        {
            ProductDeliveriesModel = _service.GetProductDeliveriesModel(SelectedItem.ProductId, SelectedItem.LocationId);
            ProductPicturePath = PictureLocationHelper.GetPictureLocation(SelectedItem.ProductProductBaseProductBaseCode);
        }

        private void ClearProductDeliveriesModel()
        {
            ProductDeliveriesModel = null;
            ProductPicturePath = null;
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public RelayCommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
