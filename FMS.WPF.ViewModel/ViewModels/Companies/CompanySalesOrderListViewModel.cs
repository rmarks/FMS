﻿using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesOrderListViewModel : GenericListViewModelBase<CompanySalesOrderListDto>
    {
        private ICompanyService _companyService;
        private int _companyId;

        public CompanySalesOrderListViewModel(ICompanyService companyService)
        {
            DisplayName = "Tellimused";

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
            Items = await _companyService.GetCompanySalesOrdersAsync(_companyId);
        }
        #endregion GenericListViewModelBase Members
    }
}
