using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        #region Fields
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        private int _companyId;
        #endregion Fields

        public CompanyContactsViewModel(ICompanyService companyService, IDialogService dialogService)
        {
            DisplayName = "Kontaktid";

            _companyService = companyService;
            _dialogService = dialogService;
        }

        public void Load(int companyId)
        {
            _companyId = companyId;

            Models = companyId > 0 
                ? new ObservableCollection<CompanyContactModel>(_companyService.GetCompanyContactModels(companyId)) 
                : null;
        }

        #region Properties
        public ObservableCollection<CompanyContactModel> Models { get; private set; }

        public CompanyContactModel SelectedModel { get; set; }
        #endregion Properties

        #region Commands
        public ICommand EditCommand => new RelayCommand(OnEdit);
        private void OnEdit()
        {
            if (SelectedModel != null)
            {
                ShowContact(SelectedModel);
            }
        }

        public ICommand AddCommand => new RelayCommand(OnAdd);
        private void OnAdd()
        {
            ShowContact(new CompanyContactModel { CompanyId = _companyId });
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        private void OnDelete()
        {
            if (SelectedModel != null)
            {
                var viewModel = new CompanyContactViewModel(SelectedModel, _companyService, _dialogService);
                viewModel.IsEditMode = false;
                viewModel.DeleteCommand?.Execute(null);
                if (SelectedModel.ContactId == 0)
                {
                    Load(_companyId);
                }
            }
        }
        #endregion Commands

        #region Helpers
        private void ShowContact(CompanyContactModel model)
        {
            var viewModel = new CompanyContactViewModel(model, _companyService, _dialogService);
            _dialogService.ShowDialog(viewModel);

            Load(_companyId);
            SelectedModel = Models?.FirstOrDefault(c => c.ContactId == model.ContactId);
        }
        #endregion Helpers
    }
}
