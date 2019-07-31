using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesOrderListViewModel : GenericListViewModelBase<CompanySalesOrderListModel>
    {
        private ICompanyAppService _companyAppService;
        private int _companyId;

        public CompanySalesOrderListViewModel(ICompanyAppService companyAppService)
        {
            DisplayName = "Tellimused";

            _companyAppService = companyAppService;
        }

        public void Load(int companyId)
        {
            _companyId = companyId;
            Refresh();
        }

        #region overrides
        public override async void Refresh(bool selectFirstItem = false)
        {
            Items = await _companyAppService.GetCompanySalesOrderListModelsAsync(_companyId);
        }
        #endregion
    }
}
