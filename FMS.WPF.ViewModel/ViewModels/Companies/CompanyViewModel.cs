using System;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        #region public methods
        public void Initialize()
        {
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
        #endregion

        #region properties
        public CompanyBasicsViewModel CompanyBasicsViewModel { get; set; }

        public CompanyAddressesViewModel CompanyAddressesViewModel { get; set; }

        public CompanyContactsViewModel CompanyContactsViewModel { get; set; }

        public CompanySalesOrderListViewModel CompanySalesOrderListViewModel { get; set; }

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
