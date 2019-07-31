using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesInvoiceListViewModel : GenericListViewModelBase<CompanySalesInvoiceListModel>
    {
        private ICompanyAppService _companyAppService;
        private int _companyId;

        public CompanySalesInvoiceListViewModel(ICompanyAppService companyAppService)
        {
            DisplayName = "Arved";

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
            Items = await _companyAppService.GetCompanySalesInvoiceListModelsAsync(_companyId);
        }
        #endregion
    }
}
