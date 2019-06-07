using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        private ICompanyService _companyService;

        public CompanyAddressesViewModel(ICompanyService companyService)
        {
            DisplayName = "Saajad";

            _companyService = companyService;
        }

        public void Load(int companyId)
        {
            Models = companyId > 0 
                ? new ObservableCollection<CompanyAddressModel>(_companyService.GetCompanyAddressModels(companyId)) 
                : null;
        }

        public ObservableCollection<CompanyAddressModel> Models { get; private set; }
    }
}
