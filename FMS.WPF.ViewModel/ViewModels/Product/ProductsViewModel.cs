using FMS.WPF.ViewModel.Utils;
using Ninject;

namespace FMS.WPF.ViewModels
{
    public class ProductsViewModel : WorkspaceViewModelBase
    {
        public ProductsViewModel(IWorkspaceManager workspaceManager) : base(workspaceManager)
        {
            DisplayName = "Tooted";
        }

        [Inject]
        public ProductListViewModel ProductListViewModel { get; set; }
    }
}
