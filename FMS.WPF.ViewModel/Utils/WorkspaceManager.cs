using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FMS.WPF.ViewModel.Utils
{
    public class WorkspaceManager : IWorkspaceManager
    {
        private readonly IViewModelFactory _viewModelFactory;
        //private readonly ICollectionView _workspaceCollectionView;

        public WorkspaceManager(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            //_workspaceCollectionView = CollectionViewSource.GetDefaultView(Workspaces);
        }

        public ObservableCollection<WorkspaceViewModelBase> Workspaces { get; } = new ObservableCollection<WorkspaceViewModelBase>();

        public event Action<WorkspaceViewModelBase> WorkspaceSelected;

        public void OpenWorkspace<T>(string paramName = null, int paramValue = 0) where T : WorkspaceViewModelBase
        {
            var newWs = _viewModelFactory.CreateInstance<T>(paramName, paramValue);

            var ws = Workspaces.FirstOrDefault(w => w.DisplayName == newWs.DisplayName);
            if (ws == null)
            {
                ws = newWs;
                Workspaces.Add(ws);
            }

            //_workspaceCollectionView.MoveCurrentTo(ws);
            WorkspaceSelected?.Invoke(ws);
        }

        public void CloseWorkspace(WorkspaceViewModelBase workspace)
        {
            Workspaces.Remove(workspace);
        }
    }
}