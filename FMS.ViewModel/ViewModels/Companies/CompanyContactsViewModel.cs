using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        public CompanyContactsViewModel(int companyId)
        {
            DisplayName = "Kontaktid";
            CompanyTab = $"{DisplayName}: {companyId}";
        }

        public string CompanyTab { get; set; }
    }
}
