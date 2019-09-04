using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyFacadeViewModel : GenericEditableViewModelBase2<CompanyModel>
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICompanyFacadeService _service;
        private readonly IDialogService _dialogService;

        public CompanyFacadeViewModel(IViewModelFactory viewModelFactory,
                                      ICompanyFacadeService service,
                                      IDialogService dialogService)
        {
            _viewModelFactory = viewModelFactory;
            _service = service;
            _dialogService = dialogService;

            Initialize();
        }

        #region public methods
        public void Load(int companyId)
        {
            Model = _service.GetCompanyModel(companyId);

            CompanyBasicsViewModel.Load(Model);
            CompanyAddressesViewModel.Load(Model);
            CompanyContactsViewModel.Load(Model);

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
        public ObservableCollection<ViewModelBase> CompanyTabs { get; } = new ObservableCollection<ViewModelBase>();
        public ViewModelBase SelectedTab { get; set; }
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyModel model)
        {
            _service.SaveCompanyModel(model);
            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyModel model)
        {
            _service.DeleteCompanyModel(model.CompanyId);
        }

        protected override void AddItem()
        {
            Load(0);
        }
        #endregion

        #region event handlers
        private void OnEditModeChanged(bool isEditMode)
        {
            CompanyBasicsViewModel.IsEditMode = isEditMode;
            CompanyAddressesViewModel.IsEditMode = isEditMode;
            CompanyContactsViewModel.IsEditMode = isEditMode;
        }
        #endregion

        #region helpers
        private void Initialize()
        {
            CompanyBasicsViewModel = _viewModelFactory.CreateInstance<CompanyBasicsViewModel>();
            CompanyAddressesViewModel = _viewModelFactory.CreateInstance<CompanyAddressesViewModel>();
            CompanyContactsViewModel = _viewModelFactory.CreateInstance<CompanyContactsViewModel>();
            CompanySalesOrderListViewModel = _viewModelFactory.CreateInstance<CompanySalesOrderListViewModel>();
            CompanySalesInvoiceListViewModel = _viewModelFactory.CreateInstance<CompanySalesInvoiceListViewModel>();

            EditModeChanged += OnEditModeChanged;

            InitializeCompanyTabs();
        }

        private void InitializeCompanyTabs()
        {
            CompanyTabs.Add(CompanyBasicsViewModel);
            CompanyTabs.Add(CompanyAddressesViewModel);
            CompanyTabs.Add(CompanyContactsViewModel);
            CompanyTabs.Add(CompanySalesOrderListViewModel);
            CompanyTabs.Add(CompanySalesInvoiceListViewModel);

            SelectedTab = CompanyBasicsViewModel;
        }
        #endregion
    }
}
