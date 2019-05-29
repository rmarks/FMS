using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.ViewModels
{
    public class CompaniesListViewModel : GenericListViewModelBase<CompanyListModel>
    {
        private ICompaniesListService _companiesListService;

        public CompaniesListViewModel(ICompaniesListService companiesListService)
        {
            _companiesListService = companiesListService;
            Refresh();
        }

        protected override void Refresh()
        {
            LoadData();
        }

        #region Helpers
        private void LoadData()
        {
            Items = _companiesListService.GetCompaniesList();
        }
        #endregion Helpers
    }
}
