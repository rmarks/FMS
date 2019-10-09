using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class CompanyListViewModel : GenericListViewModelBase<CompanyListModel>
    {
        private ICompanyListService _service;

        public CompanyListViewModel(ICompanyListService service)
        {
            _service = service;
        }

        public void Load()
        {
            Refresh();
        }

        #region overrides
        public override void Refresh(int companyId = 0)
        {
            Items = _service.GetCompanyListModels(Query);

            SelectedItem = companyId == 0 ? Items.FirstOrDefault()
                                          : Items.FirstOrDefault(i => i.CompanyId == companyId);
        }

        public override string QueryDefaultText => "Otsi firma nime, riigi, linna, aadressi või saaja nime järgi";
        #endregion
    }
}
