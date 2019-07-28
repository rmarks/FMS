using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyListViewModel : GenericListViewModelBase<CompanyListModel>
    {
        private ICompanyListVmService _companyListService;

        public CompanyListViewModel(ICompanyListVmService companyListService)
        {
            _companyListService = companyListService;
        }

        public void Load()
        {
            Refresh(selectFirstItem: true);
        }

        #region GenericListViewModelBase Members
        public override void Refresh(bool selectFirstItem = false)
        {
            var oldSelectedItem = SelectedItem;

            Items = _companyListService.GetCompanyListModels(Query);

            SelectedItem = selectFirstItem ? Items.FirstOrDefault() 
                                           : Items.FirstOrDefault(i => i.CompanyId == oldSelectedItem.CompanyId);
        }

        public override string QueryDefaultText => "Otsi firma nime, riigi, linna, aadressi või saaja nime järgi";
        #endregion GenericListViewModelBase Members
    }
}
