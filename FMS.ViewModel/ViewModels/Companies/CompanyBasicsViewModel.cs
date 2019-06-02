using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : ViewModelBase
    {
        public CompanyBasicsViewModel(int companyId)
        {
            DisplayName = "Üldandmed";
            CompanyTab = $"{DisplayName}: {companyId}";
        }

        public string CompanyTab { get; set; }
    }
}
