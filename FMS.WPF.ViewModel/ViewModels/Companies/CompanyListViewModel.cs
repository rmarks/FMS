using FMS.WPF.Application.Services;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyListViewModel : GenericListViewModelBase<CompanyListModel>
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
        public override void Refresh(bool selectFirstItem = false)
        {
            var oldSelectedItem = SelectedItem;
            
            Items = _companyService.GetCompanyList(Query);

            SelectedItem = selectFirstItem ? Items.FirstOrDefault() 
                                           : Items.FirstOrDefault(i => i.CompanyId == oldSelectedItem.CompanyId);
        }

        public override string QueryDefaultText => "Otsi firma nime, riigi, linna, aadressi või saaja nime järgi";
        #endregion GenericListViewModelBase Members
    }
}
