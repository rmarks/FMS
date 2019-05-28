using FMS.ViewModel.Factories;
using FMS.ViewModels;
using Ninject;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace FMS.ViewModel.Utils
{
    public class WorkspaceManager : IWorkspaceManager
    {
        private IKernel _kernel;
        private readonly ICollectionView _workspaceCollectionView;

        public WorkspaceManager(IKernel kernel)
        {
            _kernel = kernel;
            _workspaceCollectionView = CollectionViewSource.GetDefaultView(Workspaces);
        }

        public ObservableCollection<WorkspaceViewModelBase> Workspaces { get; } = new ObservableCollection<WorkspaceViewModelBase>();

        public void OpenWorkspace<T>(string displayName) where T : IWorkspaceFactory
        {
            var workspace = Workspaces.FirstOrDefault(w => w.DisplayName == displayName);

            if (workspace == null)
            {
                var factory = _kernel.Get<T>();
                workspace = factory.CreateWorkspace();
                Workspaces.Add(workspace);
            }

            _workspaceCollectionView.MoveCurrentTo(workspace);
        }

        public void CloseWorkspace(WorkspaceViewModelBase workspace)
        {
            Workspaces.Remove(workspace);
        }
    }
}
