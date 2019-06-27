using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using FMS.WPF.Application.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FMS.WPF.ViewModel.Services;
using System.Threading.Tasks;

namespace FMS.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private IDataTransferService _dataTransferService;
        private IProgressBarService _progressBarService;
        private IDialogService _dialogService;
        #endregion Fields

        #region Constructors
        public MainWindowViewModel(IWorkspaceManager workspaceManager, 
                                   IDataTransferService dataTransferService,
                                   IProgressBarService progressBarService,
                                   IDialogService dialogService)
        {
            WorkspaceManager = workspaceManager;
            _dataTransferService = dataTransferService;
            _progressBarService = progressBarService;
            _dialogService = dialogService;

            CreateCommands();
        }
        #endregion Constructors

        #region Properties
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();

        public IWorkspaceManager WorkspaceManager { get; }

        public ObservableCollection<WorkspaceViewModelBase> Workspaces => WorkspaceManager.Workspaces;
        #endregion Properties

        #region Commands
        private ICommand _transferDataCommand;
        public ICommand TransferDataCommand => _transferDataCommand ?? (_transferDataCommand = new RelayCommand(TransferData));
        private async void TransferData()
        {
            if (_dialogService.ShowMessageBox("Kas kustutame praegused andmed?", "Kustutamine", "YesNo"))
            {
                _progressBarService.ShowInDeterminateProgressBar("Andmete kustutamine");
                await Task.Run(() => _dataTransferService.ClearDatabase());
                _progressBarService.CloseProgressBar();

                if (_dialogService.ShowMessageBox("Andmed kustutatud. Kas kopeerime värsked andmed?", "Teade", "YesNo"))
                {
                    _progressBarService.ShowInDeterminateProgressBar("Andmete värskendamine");
                    bool isSuccess = await Task.Run(() => _dataTransferService.TransferData());
                    _progressBarService.CloseProgressBar();

                    _dialogService.ShowMessageBox(isSuccess ? "Andmed värskendatud!" : "Andmete värskendamine ebaõnnestus!");
                }
            }
        }
        #endregion Commands

        #region Helpers
        private void CreateCommands()
        {
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);

            CommandTreeItemViewModel commandCompanies = 
                new CommandTreeItemViewModel("Firmad", new RelayCommand<string>(p => WorkspaceManager.OpenWorkspace<IWorkspaceViewModelFactory<CompaniesViewModel>>("Firmad")));
            groupPermanentData.CommandTreeItems.Add(commandCompanies);
        }
        #endregion Helpers
    }
}
