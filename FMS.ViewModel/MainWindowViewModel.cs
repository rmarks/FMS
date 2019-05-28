using FMS.ViewModel.Commands;
using FMS.ViewModel.Factories;
using FMS.ViewModel.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FMS.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors
        public MainWindowViewModel(IWorkspaceManager workspaceManager)
        {
            WorkspaceManager = workspaceManager;
            CreateCommands();
        }
        #endregion Constructors

        #region Properties
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();

        public IWorkspaceManager WorkspaceManager { get; }

        public ObservableCollection<WorkspaceViewModelBase> Workspaces => WorkspaceManager.Workspaces;
        #endregion Properties

        #region Helpers
        private void CreateCommands()
        {
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);

            CommandTreeItemViewModel commandCompanies = 
                new CommandTreeItemViewModel("Firmad", new DelegateCommand(p => WorkspaceManager.OpenWorkspace<ICompaniesWorkspaceFactory>("Firmad")));
            groupPermanentData.CommandTreeItems.Add(commandCompanies);
        }
        #endregion Helpers
    }
}
