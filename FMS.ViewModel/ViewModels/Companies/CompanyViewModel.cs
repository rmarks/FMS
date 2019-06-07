using FMS.WPF.Application.Services;
using FMS.WPF.ViewModel.Services;
using System;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        public CompanyViewModel(ICompanyService companyService, IDialogService dialogService)
        {
            CompanyBasicsViewModel = new CompanyBasicsViewModel(companyService, dialogService);
            CompanyAddressesViewModel = new CompanyAddressesViewModel(companyService);
            CompanyContactsViewModel = new CompanyContactsViewModel(companyService);

            LoadCompanyTabs();

            CompanyBasicsViewModel.ItemSavedOrDeleted += () => RequestListRefresh?.Invoke(); ;
        }

        public void Load(int companyId)
        {
            CompanyBasicsViewModel.Load(companyId);
            CompanyAddressesViewModel.Load(companyId);
            CompanyContactsViewModel.Load(companyId);
        }

        #region Properties
        public CompanyBasicsViewModel CompanyBasicsViewModel { get; }

        public CompanyAddressesViewModel CompanyAddressesViewModel { get; }

        public CompanyContactsViewModel CompanyContactsViewModel { get; }

        public ObservableCollection<ViewModelBase> CompanyTabs { get; private set; }
        #endregion Properties

        #region Events
        public event Action RequestListRefresh;
        #endregion Events

        #region Helpers
        private void LoadCompanyTabs()
        {
            CompanyTabs = new ObservableCollection<ViewModelBase>();
            CompanyTabs.Add(CompanyBasicsViewModel);
            CompanyTabs.Add(CompanyAddressesViewModel);
            CompanyTabs.Add(CompanyContactsViewModel);
        }
        #endregion Helpers
    }
}
