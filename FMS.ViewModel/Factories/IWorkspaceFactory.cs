using FMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.ViewModel.Factories
{
    public interface IWorkspaceFactory
    {
        WorkspaceViewModelBase CreateWorkspace();
    }
}
