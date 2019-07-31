using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;
using System;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        public CompanyViewModel(ICompanyAppService companyAppService, 
                                IDialogService dialogService)
        {
            CompanyBasicsViewModel = new CompanyBasicsViewModel(companyAppService, dialogService);
            CompanyAddressesViewModel = new CompanyAddressesViewModel(companyAppService, dialogService);
            CompanyContactsViewModel = new CompanyContactsViewModel(companyAppService, dialogService);
            CompanySalesOrderListViewModel = new CompanySalesOrderListViewModel(companyAppService);
            CompanySalesInvoiceListViewModel = new CompanySalesInvoiceListViewModel(companyAppService);

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

        #region properties
        public CompanyBasicsViewModel CompanyBasicsViewModel { get; }

        public CompanyAddressesViewModel CompanyAddressesViewModel { get; }

        public CompanyContactsViewModel CompanyContactsViewModel { get; }

        public CompanySalesOrderListViewModel CompanySalesOrderListViewModel { get; }

        public CompanySalesInvoiceListViewModel CompanySalesInvoiceListViewModel { get; set; }

        public ObservableCollection<ViewModelBase> CompanyTabs { get; private set; }
        #endregion

        #region events
        public event Action RequestListRefresh;
        #endregion

        #region helpers
        private void InitializeCompanyTabs()
        {
            CompanyTabs = new ObservableCollection<ViewModelBase>();
            CompanyTabs.Add(CompanyBasicsViewModel);
            CompanyTabs.Add(CompanyAddressesViewModel);
            CompanyTabs.Add(CompanyContactsViewModel);
            CompanyTabs.Add(CompanySalesOrderListViewModel);
            CompanyTabs.Add(CompanySalesInvoiceListViewModel);
        }
        #endregion
    }
}
