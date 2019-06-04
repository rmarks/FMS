using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        private ICompanyAddressesService _service;

        public CompanyAddressesViewModel(int companyId, ICompanyAddressesService service)
        {
            DisplayName = "Saajad";

            _service = service;
            Models = new ObservableCollection<CompanyAddressModel>(_service.GetCompanyAddressModels(companyId));
        }

        public ObservableCollection<CompanyAddressModel> Models { get; }
    }
}
