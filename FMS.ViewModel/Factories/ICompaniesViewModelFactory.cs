using FMS.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModel.Factories
{
    public interface ICompaniesViewModelFactory : IWorkspaceFactory
    {
        CompaniesViewModel CreateInstance();
    }
}
