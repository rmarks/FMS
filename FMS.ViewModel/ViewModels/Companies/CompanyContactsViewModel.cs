using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        private ICompanyService _companyService;

        public CompanyContactsViewModel(ICompanyService companyService)
        {
            DisplayName = "Kontaktid";

            _companyService = companyService;
            
        }

        public void Load(int companyId)
        {
            Models = companyId > 0 
                ? new ObservableCollection<CompanyContactModel>(_companyService.GetCompanyContactModels(companyId)) 
                : null;
        }

        public ObservableCollection<CompanyContactModel> Models { get; private set; }
    }
}
