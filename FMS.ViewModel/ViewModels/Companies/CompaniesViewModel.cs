using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        #region Fields
        private ICompaniesListViewModelFactory _companiesListViewModelFactory;
        private ICompanyCompoundViewModelFactory _companyCompoundViewModelFactory;
        #endregion Fields

        #region Constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager, 
                                  ICompaniesListViewModelFactory companiesListViewModelFactory,
                                  ICompanyCompoundViewModelFactory companyCompoundViewModelFactory)
            : base(workspaceManager)
        {
            _companiesListViewModelFactory = companiesListViewModelFactory;
            _companyCompoundViewModelFactory = companyCompoundViewModelFactory;

            DisplayName = "Firmad";

            ListViewModel.SelectedItemChanged += ListViewModel_SelectedItemChanged;
        }
        #endregion Constructors

        #region Properties
        private CompaniesListViewModel _listViewModel;
        public CompaniesListViewModel ListViewModel => _listViewModel ?? (_listViewModel = _companiesListViewModelFactory.CreateInstance());

        public CompanyCompoundViewModel ItemViewModel { get; private set; }
        #endregion Properties

        #region Event Handlers
        private void ListViewModel_SelectedItemChanged()
        {
            ItemViewModel = _companyCompoundViewModelFactory.CreateInstance(ListViewModel.SelectedItem.CompanyId);
        }
        #endregion Event Handlers
    }
}
