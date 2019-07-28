using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Services;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        #region Constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager,
                                  ICompanyService companyService,
                                  IDialogService dialogService,
                                  ICompanyDropdownsService dropdownsService,
                                  ICompanyListViewModelFactory companyListViewModelFactory) : base(workspaceManager)
        {
            DisplayName = "Firmad";

            CompanyListViewModel = companyListViewModelFactory.CreateInstance();
            CompanyViewModel = new CompanyViewModel(companyService, dialogService, dropdownsService);

            CompanyListViewModel.SelectedItemChanged += CompanyListViewModel_SelectedItemChanged;
            CompanyViewModel.RequestListRefresh += CompanyViewModel_RequestListRefresh;

            CompanyListViewModel.Load();
        }
        #endregion Constructors

        #region Properties
        public CompanyListViewModel CompanyListViewModel { get; }

        public CompanyViewModel CompanyViewModel { get; }

        public bool IsCompanyAvailable => CompanyListViewModel.SelectedItem != null;
        #endregion Properties

        #region Event Handlers
        private void CompanyListViewModel_SelectedItemChanged(CompanyListModel model)
        {
            CompanyViewModel.Load(model?.CompanyId ?? 0);
            RaisePropertyChanged(nameof(IsCompanyAvailable));
        }

        private void CompanyViewModel_RequestListRefresh()
        {
            CompanyListViewModel.Refresh();
        }
        #endregion Event Handlers
    }
}
