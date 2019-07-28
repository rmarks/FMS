using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.ViewModel.Services;
using System;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        public CompanyViewModel(ICompanyService companyService, 
                                IDialogService dialogService,
                                ICompanyDropdownsService dropdownsService)
        {
            CompanyBasicsViewModel = new CompanyBasicsViewModel(companyService, dialogService, dropdownsService);
            CompanyAddressesViewModel = new CompanyAddressesViewModel(companyService, dialogService, dropdownsService);
            CompanyContactsViewModel = new CompanyContactsViewModel(companyService, dialogService);
            CompanySalesOrderListViewModel = new CompanySalesOrderListViewModel(companyService);
            CompanySalesInvoiceListViewModel = new CompanySalesInvoiceListViewModel(companyService);

            InitializeCompanyTabs();

            CompanyBasicsViewModel.ItemSavedOrDeleted += () => RequestListRefresh?.Invoke();
        }

        public void Load(int companyId)
        {
            CompanyBasicsViewModel.Load(companyId);
            CompanyAddressesViewModel.Load(companyId);
            CompanyContactsViewModel.Load(companyId);
            CompanySalesOrderListViewModel.Load(companyId);
            CompanySalesInvoiceListViewModel.Load(companyId);
        }

        #region Properties
        public CompanyBasicsViewModel CompanyBasicsViewModel { get; }

        public CompanyAddressesViewModel CompanyAddressesViewModel { get; }

        public CompanyContactsViewModel CompanyContactsViewModel { get; }

        public CompanySalesOrderListViewModel CompanySalesOrderListViewModel { get; }

        public CompanySalesInvoiceListViewModel CompanySalesInvoiceListViewModel { get; set; }

        public ObservableCollection<ViewModelBase> CompanyTabs { get; private set; }
        #endregion Properties

        #region Events
        public event Action RequestListRefresh;
        #endregion Events

        #region Helpers
        private void InitializeCompanyTabs()
        {
            CompanyTabs = new ObservableCollection<ViewModelBase>();
            CompanyTabs.Add(CompanyBasicsViewModel);
            CompanyTabs.Add(CompanyAddressesViewModel);
            CompanyTabs.Add(CompanyContactsViewModel);
            CompanyTabs.Add(CompanySalesOrderListViewModel);
            CompanyTabs.Add(CompanySalesInvoiceListViewModel);
        }
        #endregion Helpers
    }
}
