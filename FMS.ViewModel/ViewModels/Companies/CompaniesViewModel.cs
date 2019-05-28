using FMS.ViewModel.Utils;

namespace FMS.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        public CompaniesViewModel(IWorkspaceManager workspaceManager) : base(workspaceManager)
        {
            DisplayName = "Firmad";
        }
    }
}
