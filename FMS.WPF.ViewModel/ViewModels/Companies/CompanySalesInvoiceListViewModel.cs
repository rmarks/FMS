﻿using FMS.WPF.Application.Services;
using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesInvoiceListViewModel : GenericListViewModelBase<CompanySalesInvoiceListModel>
    {
        private ICompanyService _companyService;
        private int _companyId;

        public CompanySalesInvoiceListViewModel(ICompanyService companyService)
        {
            DisplayName = "Arved";

            _companyService = companyService;
        }

        public void Load(int companyId)
        {
            _companyId = companyId;
            Refresh();
        }

        #region GenericListViewModelBase Members
        public override async void Refresh(bool selectFirstItem = false)
        {
            Items = await _companyService.GetCompanySalesInvoiceListAsync(_companyId);
        }
        #endregion GenericListViewModelBase Members
    }
}
