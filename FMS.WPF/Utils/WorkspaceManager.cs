using FMS.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FMS.WPF.Utils
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

        public ObservableCollection<IWorkspace> Workspaces { get; } = new ObservableCollection<IWorkspace>();

        public event Action<IWorkspace> WorkspaceSelected;

        public void OpenWorkspace<T>(int id = 0) where T : ViewModelBase, IWorkspace
        {
            var newWs = _viewModelFactory.CreateInstance<T>(id);

            var ws = Workspaces.FirstOrDefault(w => w.DisplayName == newWs.DisplayName);
            if (ws == null)
            {
                ws = newWs;
                Workspaces.Add(ws);
            }

            //_workspaceCollectionView.MoveCurrentTo(ws);
            WorkspaceSelected?.Invoke(ws);
        }

        public void CloseWorkspace(IWorkspace workspace)
        {
            Workspaces.Remove(workspace);
        }
    }
}