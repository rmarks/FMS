using FMS.WPF.Application.Services;
using FMS.WPF.Model;

namespace FMS.WPF.ViewModels
{
    public class CompaniesListViewModel : GenericListViewModelBase<CompanyListModel>
    {
        private ICompaniesListService _service;

        public CompaniesListViewModel(ICompaniesListService service)
        {
            _service = service;
            Refresh();
        }

        protected override void Refresh()
        {
            LoadData();
        }

        #region Helpers
        private void LoadData()
        {
            Items = _service.GetCompaniesList();
        }
        #endregion Helpers
    }
}
