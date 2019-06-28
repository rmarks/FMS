using FMS.WPF.Application.Services;
using FMS.WPF.Model;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesOrderListViewModel : GenericListViewModelBase<CompanySalesOrderListModel>
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
        public override void Refresh()
        {
            Items = _companyService.GetCompanySalesOrderList(_companyId);
        }
        #endregion GenericListViewModelBase Members
    }
}
