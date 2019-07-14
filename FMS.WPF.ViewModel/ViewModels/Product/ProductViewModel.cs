using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class ProductViewModel : WorkspaceViewModelBase
    {
        public ProductViewModel(int productBaseId, IWorkspaceManager workspaceManager) : base(workspaceManager)
        {
            DisplayName = productBaseId.ToString();
        }
    }
}
