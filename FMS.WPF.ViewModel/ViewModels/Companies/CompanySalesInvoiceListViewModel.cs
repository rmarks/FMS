using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanySalesInvoiceListViewModel : GenericListViewModelBase<CompanySalesInvoiceListModel>
    {
        private ICompanyFacadeService _companyFacadeService;
        private int _companyId;

        public CompanySalesInvoiceListViewModel(ICompanyFacadeService companyFacadeService)
        {
            DisplayName = "Arved";

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
            Items = await _companyFacadeService.GetCompanySalesInvoiceListModelsAsync(_companyId);
        }
        #endregion
    }
}
