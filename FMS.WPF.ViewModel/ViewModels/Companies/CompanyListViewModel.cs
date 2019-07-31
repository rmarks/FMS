using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyListViewModel : GenericListViewModelBase<CompanyListModel>
    {
        private ICompanyAppService _companyAppService;

        public CompanyListViewModel(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public void Load()
        {
            Refresh(selectFirstItem: true);
        }

        #region overrides
        public async override void Refresh(bool selectFirstItem = false)
        {
            var oldSelectedItem = SelectedItem;

            Items = await _companyAppService.GetCompanyListModelsAsync(Query);

            SelectedItem = selectFirstItem ? Items.FirstOrDefault() 
                                           : Items.FirstOrDefault(i => i.CompanyId == oldSelectedItem.CompanyId);
        }

        public override string QueryDefaultText => "Otsi firma nime, riigi, linna, aadressi või saaja nime järgi";
        #endregion
    }
}
