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
            Refresh();
        }

        #region GenericListViewModelBase Members
        public override void Refresh()
        {
            var prevSelItem = SelectedItem;
            
            Items = _companyService.GetCompanyList();

            SelectedItem = prevSelItem == null 
                ? Items.FirstOrDefault() 
                : Items.FirstOrDefault(i => i.CompanyId == prevSelItem.CompanyId);
        }
        #endregion GenericListViewModelBase Members
    }
}
