using FMS.WPF.Application.Common;
using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using FMS.WPF.ViewModel.Services;
using System;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : GenericEditableViewModelBase<CompanyBasicsModel>
    {
        #region Fields
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        #endregion Fields

        public CompanyBasicsViewModel(ICompanyService companyService, IDialogService dialogService)
        {
            DisplayName = "Üldandmed";

            _companyService = companyService;
            _dialogService = dialogService;
        }

        public void Load(int companyId)
        {
            Model = companyId > 0 
                ? _companyService.GetCompanyBasicsModel(companyId) 
                : null;
        }

        #region Properties
        public IList<CountryModel> Countries => CompanyDropdownTablesProxy.Instance.Countries;
        public IList<CurrencyModel> Currencies => CompanyDropdownTablesProxy.Instance.Currencies;
        public IList<DeliveryTermModel> DeliveryTerms => CompanyDropdownTablesProxy.Instance.DeliveryTerms;
        public IList<PaymentTermDropdownModel> PaymentTerms => CompanyDropdownTablesProxy.Instance.PaymentTerms;
        #endregion Properties

        #region Events
        public event Action ItemSavedOrDeleted;
        #endregion Events

        #region GenericEditableViewModelBase Members
        protected override bool SaveItem(CompanyBasicsModel model)
        {
            model = _companyService.SaveCompanyBasics(model);
            ItemSavedOrDeleted?.Invoke();

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyBasicsModel model)
        {
            _companyService.DeleteCompanyBasics(model.CompanyId);
            ItemSavedOrDeleted?.Invoke();
        }
        #endregion GenericEditableViewModelBase Members
    }
}
