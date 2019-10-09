using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Utils;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class ProductListViewModel : GenericListViewModelBase<ProductListModel>, IWorkspace
    {
        #region Fields
        private IProductListService _service;
        #endregion

        public ProductListViewModel(IWorkspaceManager workspaceManager,
                                    IProductListService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;

            InitializeOptionsModel();
        }

        #region properties
        public override string DisplayName => "Tooted";
        public ProductListOptionsModel OptionsModel { get; private set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetProductListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
        }

        protected override void OpenItem()
        {
            OpenWorkspace(SelectedItem.ProductBaseId);
        }

        protected override void AddItem()
        {
            OpenWorkspace(0);
        }
        #endregion

        #region helpers
        private void InitializeOptionsModel()
        {
            OptionsModel = _service.GetProductListOptionsModel();
            OptionsModel.OptionChanged += ClearItems;
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;
        }

        private void OpenWorkspace(int productBaseId)
        {
            WorkspaceManager.OpenWorkspace<ProductFacadeViewModel>(productBaseId);
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
