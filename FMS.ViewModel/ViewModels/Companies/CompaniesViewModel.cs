using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        #region Fields
        private IViewModelFactory<CompaniesListViewModel> _companiesListViewModelFactory;
        private IViewModelFactory<CompanyViewModel> _companyViewModelFactory;
        #endregion Fields

        #region Constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager, 
                                  IViewModelFactory<CompaniesListViewModel> companiesListViewModelFactory,
                                  IViewModelFactory<CompanyViewModel> companyViewModelFactory)
            : base(workspaceManager)
        {
            _companiesListViewModelFactory = companiesListViewModelFactory;
            _companyViewModelFactory = companyViewModelFactory;

            DisplayName = "Firmad";

            ListViewModel.SelectedItemChanged += ListViewModel_SelectedItemChanged;
            ListViewModel.SelectedItem = ListViewModel.Items.FirstOrDefault();
        }
        #endregion Constructors

        #region Properties
        private CompaniesListViewModel _listViewModel;
        public CompaniesListViewModel ListViewModel => _listViewModel ?? (_listViewModel = _companiesListViewModelFactory.CreateInstance());

        public CompanyViewModel ItemViewModel { get; private set; }
        #endregion Properties

        #region Event Handlers
        private void ListViewModel_SelectedItemChanged()
        {
            ItemViewModel = _companyViewModelFactory.CreateInstance(ListViewModel.SelectedItem.CompanyId);
        }
        #endregion Event Handlers
    }
}
