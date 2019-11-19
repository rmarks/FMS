using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class DeliveryNoteViewModel : GenericEditableViewModelBase2<DeliveryNoteModel>, IWorkspace
    {
        private readonly IDeliveryNoteService _service;

        public DeliveryNoteViewModel(int deliveryHeaderId,
                                     IWorkspaceManager workspaceManager,
                                     IDeliveryNoteService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;

            Initialize(deliveryHeaderId);
        }

        #region properties
        public override string DisplayName => Model?.DocNo == null ? "Uus saateleht" : "Saateleht nr. " + Model.DocNo;
        public ObservableCollection<DeliveryLineModel> Lines { get; set; }
        #endregion

        #region helpers
        private void Initialize(int deliveryHeaderId)
        {
            Model = _service.GetDeliveryNoteModel(deliveryHeaderId);

            Lines = new ObservableCollection<DeliveryLineModel>(Model.DeliveryLines);
            Model.DeliveryLines = null;

            EditModeChanged += OnEditModeChanged;
        }
        #endregion

        #region event handlers
        private void OnEditModeChanged(bool isEditMode)
        {
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
