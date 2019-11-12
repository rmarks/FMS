using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Strategies;
using FMS.WPF.Utils;

namespace FMS.WPF.ViewModels
{
    public class DeliveryNoteListViewModel : GenericListViewModelBase<DeliveryNoteListModel>, IWorkspace
    {
        private readonly IDeliveryNoteListService _service;
        private readonly IDeliveryStrategy _strategy;

        public DeliveryNoteListViewModel(IDeliveryStrategy strategy, 
                                         IWorkspaceManager workspaceManager, 
                                         IDeliveryNoteListService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;
            _strategy = strategy;

            Initialize();
        }

        #region properties
        public DeliveryNoteListOptionsModel OptionsModel { get; private set; }
        public bool IsFromLocationTypeEnabled { get; set; }
        public bool IsToLocationTypeEnabled { get; set; }
        #endregion

        #region overrides
        public override void Refresh(int itemId = 0)
        {
            Items = _service.GetDeliveryNoteListModels(OptionsModel);
            ItemsCount = Items.Count;
        }

        protected override void Reset()
        {
            OptionsModel.Reset();
        }
        #endregion

        #region helpers
        private void Initialize()
        {
            InitializeOptionsModel();

            DisplayName = _strategy.DisplayName;
            IsFromLocationTypeEnabled = _strategy.IsFromLocationTypeEnabled;
            IsToLocationTypeEnabled = _strategy.IsToLocationTypeEnabled;
            
            Refresh();
        }

        private void InitializeOptionsModel()
        {
            OptionsModel = _service.GetDeliveryNoteListOptionsModel();

            OptionsModel.OptionChanged += ClearItems;
            OptionsModel.SetDefaultOptions += () => _strategy.SetDefaultOptions(OptionsModel);

            OptionsModel.SetDefaultOptions();
        }

        private void ClearItems()
        {
            Items = null;
            ItemsCount = null;
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public RelayCommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion
    }
}
