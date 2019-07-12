using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyListViewModel : GenericListViewModelBase<CompanyListDto>
    {
        private ICompanyService _companyService;

        public CompanyListViewModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public void Load()
        {
            Refresh(selectFirstItem: true);
        }

        #region GenericListViewModelBase Members
        public override async void Refresh(bool selectFirstItem = false)
        {
            var oldSelectedItem = SelectedItem;

            Items = await _companyService.GetCompaniesAsync(Query);

            SelectedItem = selectFirstItem ? Items.FirstOrDefault() 
                                           : Items.FirstOrDefault(i => i.CompanyId == oldSelectedItem.CompanyId);
        }

        public override string QueryDefaultText => "Otsi firma nime, riigi, linna, aadressi või saaja nime järgi";
        #endregion GenericListViewModelBase Members
    }
}
