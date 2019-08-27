using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        #region constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager,
                                  IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            CompanyListViewModel = viewModelFactory.CreateInstance<CompanyListViewModel>();
            CompanyFacadeViewModel = viewModelFactory.CreateInstance<CompanyFacadeViewModel>();

            CompanyListViewModel.SelectedItemChanged += CompanyListViewModel_SelectedItemChanged;

            CompanyFacadeViewModel.CompanySaved += (id) => CompanyListViewModel.Refresh(id);
            CompanyFacadeViewModel.CompanyDeleted += () => CompanyListViewModel.Refresh();
            CompanyFacadeViewModel.CompanyEditCancelled += CompanyFacadeViewModel_CompanyEditCancelled;

            CompanyListViewModel.Load();
        }
        #endregion

        #region properties
        public override string DisplayName => "Firmad";

        public CompanyListViewModel CompanyListViewModel { get; }

        public CompanyFacadeViewModel CompanyFacadeViewModel { get; }

        public bool IsCompanyAvailable => CompanyListViewModel.SelectedItem != null;
        #endregion

        #region commands
        public ICommand AddCommand => new RelayCommand(OnAdd);
        private void OnAdd()
        {
            //CompanyListViewModel.SelectedItem = new CompanyListModel();
            CompanyFacadeViewModel.LoadCompany(0);
        }
        #endregion

        #region event handlers
        private void CompanyListViewModel_SelectedItemChanged(CompanyListModel model)
        {
            if (model != null)
            {
                CompanyFacadeViewModel.LoadCompany(model.CompanyId);
            }
            
            RaisePropertyChanged(nameof(IsCompanyAvailable));
        }

        private void CompanyFacadeViewModel_CompanyEditCancelled()
        {
            CompanyFacadeViewModel.LoadCompany(CompanyListViewModel.SelectedItem.CompanyId);
        }
        #endregion
    }
}
