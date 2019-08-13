using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesOrderListViewModel : GenericListViewModelBase<CompanySalesOrderListModel>
    {
        private ICompanyFacadeService _companyFacadeService;
        private int _companyId;

        public CompanySalesOrderListViewModel(ICompanyFacadeService companyFacadeService)
        {
            DisplayName = "Tellimused";

            _companyFacadeService = companyFacadeService;
        }

        public void Load(int companyId)
        {
            _companyId = companyId;
            Refresh();
        }

        #region overrides
        public override async void Refresh(int itemId = 0)
        {
            Items = await _companyFacadeService.GetCompanySalesOrderListModelsAsync(_companyId);
        }
        #endregion
    }
}
