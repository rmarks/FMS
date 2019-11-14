using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Strategies;
using FMS.WPF.Utils;

namespace FMS.WPF.ViewModels
{
    public class LocationListViewModel : GenericListViewModelBase<LocationListModel>, IWorkspace
    {
        private readonly ILocationListStrategy _strategy;
        private readonly ILocationListService _service;

        public LocationListViewModel(ILocationListStrategy strategy,
                                     IWorkspaceManager workspaceManager,
                                     ILocationListService service)
        {
            _strategy = strategy;
            WorkspaceManager = workspaceManager;
            _service = service;

            Initialize();
        }

        #region properties
        public string ItemsCountCaption { get; set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetLocationListModels(_strategy.LocationTypeId);
            ItemsCount = Items.Count;
        }

        protected override void OpenItem()
        {
            OpenWorkspace(SelectedItem);
        }
        #endregion

        #region helpers
        private void Initialize()
        {
            DisplayName = _strategy.DisplayName;
            ItemsCountCaption = _strategy.ItemsCountCaption;

            Refresh();
        }

        private void OpenWorkspace(LocationListModel model)
        {
            WorkspaceManager.OpenWorkspace<LocationInventoryListViewModel, LocationListModel>(model);
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public RelayCommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
