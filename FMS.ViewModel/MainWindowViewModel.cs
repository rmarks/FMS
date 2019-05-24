using FMS.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace FMS.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();

        private ObservableCollection<WorkspaceViewModelBase> _workspaces;
        public ObservableCollection<WorkspaceViewModelBase> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModelBase>();
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }

                return _workspaces;
            }
        }

        public WorkspaceViewModelBase SelectedWorkspace { get; set; }
        #endregion Properties

        public MainWindowViewModel()
        {
            CreateCommands();
        }

        #region Helpers
        private void CreateCommands()
        {
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);
            CommandTreeItemViewModel commandCompanies = new CommandTreeItemViewModel("Firmad", new DelegateCommand(p => ShowWorkspace("Firmad")));
            groupPermanentData.CommandTreeItems.Add(commandCompanies);
        }

        private void ShowWorkspace(string name)
        {
            AddWorkspace();
        }

        private void AddWorkspace()
        {
            var viewModel = new CompaniesViewModel();

            var workspace = Workspaces.FirstOrDefault(w => w.DisplayName == viewModel.DisplayName);
            if (workspace == null)
            {
                workspace = viewModel;
                Workspaces.Add(workspace);
            }
            
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModelBase workspace)
        {
            SelectedWorkspace = workspace;
        }
        #endregion Helpers

        #region Event Handlers
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (WorkspaceViewModelBase workspace in e.NewItems)
                {
                    workspace.RequestCloseWorkspace += OnCloseWorkspace;
                }
            }
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (WorkspaceViewModelBase workspace in e.OldItems)
                {
                    workspace.RequestCloseWorkspace -= OnCloseWorkspace;
                }
            }
        }

        private void OnCloseWorkspace(WorkspaceViewModelBase workspace)
        {
            Workspaces.Remove(workspace);
        }
        #endregion Event Handlers
    }
}
