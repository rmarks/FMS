using FMS.WPF.ViewModel.Factories;
using System;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyFacadeViewModel : ViewModelBase
    {
        public CompanyFacadeViewModel(IViewModelFactory viewModelFactory)
        {
            CompanyBasicsViewModel = viewModelFactory.CreateInstance<CompanyBasicsViewModel>();
            CompanyAddressesViewModel = viewModelFactory.CreateInstance<CompanyAddressesViewModel>();
            CompanyContactsViewModel = viewModelFactory.CreateInstance<CompanyContactsViewModel>();
            CompanySalesOrderListViewModel = viewModelFactory.CreateInstance<CompanySalesOrderListViewModel>();
            CompanySalesInvoiceListViewModel = viewModelFactory.CreateInstance<CompanySalesInvoiceListViewModel>();

            CompanyBasicsViewModel.ItemSaved += (p) => CompanySaved?.Invoke(p.CompanyId);
            CompanyBasicsViewModel.ItemDeleted += () => CompanyDeleted?.Invoke();
            CompanyBasicsViewModel.ItemEditCancelled += () => CompanyEditCancelled?.Invoke();
        }

        #region public methods
        public void LoadCompany(int companyId)
        {
            CompanyBasicsViewModel.Load(companyId);
            CompanyAddressesViewModel.Load(companyId);
            CompanyContactsViewModel.Load(companyId);
            CompanySalesOrderListViewModel.Load(companyId);
            CompanySalesInvoiceListViewModel.Load(companyId);

            ComposeCompanyTabs(isNewCompany: companyId == 0);
        }
        #endregion

        #region properties
        public CompanyBasicsViewModel CompanyBasicsViewModel { get; set; }
        public CompanyAddressesViewModel CompanyAddressesViewModel { get; set; }
        public CompanyContactsViewModel CompanyContactsViewModel { get; set; }
        public CompanySalesOrderListViewModel CompanySalesOrderListViewModel { get; set; }
        public CompanySalesInvoiceListViewModel CompanySalesInvoiceListViewModel { get; set; }
        public ObservableCollection<ViewModelBase> CompanyTabs { get; } = new ObservableCollection<ViewModelBase>();
        public ViewModelBase SelectedTab { get; set; }
        #endregion

        #region events
        public event Action<int> CompanySaved;
        public event Action CompanyDeleted;
        public event Action CompanyEditCancelled;
        #endregion

        #region helpers
        private void ComposeCompanyTabs(bool isNewCompany)
        {
            if (isNewCompany)
            {
                CompanyTabs.Clear();
                CompanyTabs.Add(CompanyBasicsViewModel);

                SelectedTab = CompanyBasicsViewModel;

                CompanyBasicsViewModel.EditCommand.Execute(null);
            }
            //if previous was new company (Count = 1)
            //   or company form opened for the first time (Count = 0), 
            //then show all tabs
            else if (CompanyTabs.Count < 2)
            {
                if (CompanyTabs.Count != 0) CompanyTabs.Clear();

                CompanyTabs.Add(CompanyBasicsViewModel);
                CompanyTabs.Add(CompanyAddressesViewModel);
                CompanyTabs.Add(CompanyContactsViewModel);
                CompanyTabs.Add(CompanySalesOrderListViewModel);
                CompanyTabs.Add(CompanySalesInvoiceListViewModel);

                SelectedTab = CompanyBasicsViewModel;
            }
        }
        #endregion
    }
}
