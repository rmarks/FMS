using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Utils;

namespace FMS.WPF.ViewModels
{
    public class SalesOrderListViewModel : GenericListViewModelBase<SalesOrderListModel>, IWorkspace
    {
        private readonly ISalesOrderListService _service;

        public SalesOrderListViewModel(IWorkspaceManager workspaceManager, ISalesOrderListService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;

            InitializeOptionsModel();
            Refresh();
        }

        #region properties
        public override string DisplayName => "Müügitellimused";
        public SalesOrderListOptionsModel OptionsModel { get; private set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetSalesOrderListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
        }

        protected override void OpenItem()
        {
            OpenWorkspace(SelectedItem.SalesOrderId);
        }
        #endregion

        #region helpers
        private void InitializeOptionsModel()
        {
            OptionsModel = _service.GetSalesOrderListOptionsModel();
            OptionsModel.DefaultSetup();
            OptionsModel.OptionChanged += ClearItems;
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;
        }

        private void OpenWorkspace(int salesOrderId)
        {
            WorkspaceManager.OpenWorkspace<SalesOrderViewModel>(salesOrderId);
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public RelayCommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
