using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesInvoiceListViewModel : GenericListViewModelBase<CompanySalesInvoiceListDto>
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
            Items = await _companyService.GetCompanySalesInvoicesAsync(_companyId);
        }
        #endregion GenericListViewModelBase Members
    }
}
