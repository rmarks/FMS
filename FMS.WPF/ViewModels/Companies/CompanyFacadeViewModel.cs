using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Services;
using FMS.WPF.Utils;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyFacadeViewModel : GenericEditableViewModelBase2<CompanyModel>
    {
        private readonly ICompanyFacadeService _service;
        private readonly IDialogService _dialogService;

        public CompanyFacadeViewModel(ICompanyFacadeService service,
                                      IDialogService dialogService)
        {
            _service = service;
            _dialogService = dialogService;
        }

        #region public methods
        public async void Load(int companyId)
        {
            Model = _service.GetCompanyModel(companyId);

            IsCustomer = Model.CompanyTypesLink.Any(c => c.CompanyType.Name == "Klient");

            if (!Model.IsNew && IsCustomer)
            {
                SalesOrders = await _service.GetCompanySalesOrderListModelsAsync(Model.CompanyId);
                SalesInvoices = await _service.GetCompanySalesInvoiceListModelsAsync(Model.CompanyId);
            }
        }
        #endregion

        #region properties
        public IList<CompanySalesOrderListModel> SalesOrders { get; set; }
        public IList<CompanySalesInvoiceListModel> SalesInvoices { get; set; }

        public bool IsCustomer { get; set; }

        private CompanyTypeModel _selectedAddableCompanyType;
        public CompanyTypeModel SelectedAddableCompanyType 
        { 
            get => _selectedAddableCompanyType;
            set
            {
                _selectedAddableCompanyType = value;
                AddCompanyTypeCommand.RaiseCanExecuteChanged();
            } 
        }

        private CompanyCompanyTypeModel _selectedCompanyType;
        public CompanyCompanyTypeModel SelectedCompanyType
        {
            get => _selectedCompanyType;
            set
            {
                _selectedCompanyType = value;
                RemoveCompanyTypeCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region commands
        private RelayCommand _addCompanyTypeCommand;
        public RelayCommand AddCompanyTypeCommand => _addCompanyTypeCommand ?? (_addCompanyTypeCommand = new RelayCommand(AddCompanyType, () => CanAddCompanyType));
        public bool CanAddCompanyType => IsEditMode && SelectedAddableCompanyType != null;
        private void AddCompanyType()
        {
            Model.AddCompanyType(SelectedAddableCompanyType);
        }

        private RelayCommand _removeCompanyTypeCommand;
        public RelayCommand RemoveCompanyTypeCommand => _removeCompanyTypeCommand ?? (_removeCompanyTypeCommand = new RelayCommand(RemoveCompanyType, () => CanRemoveCompanyType));
        public bool CanRemoveCompanyType => IsEditMode && SelectedCompanyType != null;
        private void RemoveCompanyType()
        {
            Model.RemoveCompanyType(SelectedCompanyType);
        }
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyModel model)
        {
            int companyId = _service.Save(model);
            Load(companyId);

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyModel model)
        {
            _service.Delete(model.CompanyId);
        }

        protected override void AddItem()
        {
            Load(0);
        }
        #endregion
    }
}
