using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyCompoundViewModel : ViewModelBase
    {
        public CompanyCompoundViewModel(int companyId)
        {
            CompanyId = companyId;
        }

        public int CompanyId { get; set; }
    }
}
