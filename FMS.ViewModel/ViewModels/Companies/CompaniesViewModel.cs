﻿using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        private ICompaniesListViewModelFactory _companiesListViewModelFactory;

        public CompaniesViewModel(IWorkspaceManager workspaceManager, ICompaniesListViewModelFactory companiesListViewModelFactory) 
            : base(workspaceManager)
        {
            _companiesListViewModelFactory = companiesListViewModelFactory;
            DisplayName = "Firmad";
        }

        private CompaniesListViewModel _listViewModel;
        public CompaniesListViewModel ListViewModel => _listViewModel ?? (_listViewModel = _companiesListViewModelFactory.CreateInstance());
    }
}
