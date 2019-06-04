using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        private ICompanyContactsService _service;

        public CompanyContactsViewModel(int companyId, ICompanyContactsService service)
        {
            DisplayName = "Kontaktid";

            _service = service;
            Models = new ObservableCollection<CompanyContactModel>(_service.GetCompanyContactModels(companyId));
        }

        public ObservableCollection<CompanyContactModel> Models { get; }
    }
}
