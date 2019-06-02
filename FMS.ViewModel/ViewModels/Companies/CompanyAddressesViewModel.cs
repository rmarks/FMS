using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        public CompanyAddressesViewModel(int companyId)
        {
            DisplayName = "Aadressid";
            CompanyTab = $"{DisplayName}: {companyId}";
        }

        public string CompanyTab { get; set; }
    }
}
