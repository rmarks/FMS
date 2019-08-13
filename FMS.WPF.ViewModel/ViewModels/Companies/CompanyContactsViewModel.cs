using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        #region fields
        private ICompanyFacadeService _companyFacadeService;
        private IDialogService _dialogService;
        private int _companyId;
        #endregion

        public CompanyContactsViewModel(ICompanyFacadeService companyFacadeService, 
                                        IDialogService dialogService)
        {
            _companyFacadeService = companyFacadeService;
            _dialogService = dialogService;
        }

        public async void Load(int companyId)
        {
            _companyId = companyId;

            var models = await _companyFacadeService.GetCompanyContactModelsAsync(companyId);

            Models = models != null
                ? new ObservableCollection<CompanyContactModel>(models)
                : null;
        }

        #region properties
        public override string DisplayName => "Kontaktid";
        public ObservableCollection<CompanyContactModel> Models { get; private set; }
        public CompanyContactModel SelectedModel { get; set; }
        #endregion Properties

        #region commands
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
                var viewModel = new CompanyContactViewModel(SelectedModel, _companyFacadeService, _dialogService);
                viewModel.IsEditMode = false;
                viewModel.DeleteCommand?.Execute(null);
                if (SelectedModel.ContactId == 0)
                {
                    Load(_companyId);
                }
            }
        }
        #endregion

        #region helpers
        private void ShowContact(CompanyContactModel model)
        {
            var viewModel = new CompanyContactViewModel(model, _companyFacadeService, _dialogService);
            _dialogService.ShowDialog(viewModel);

            Load(_companyId);
            SelectedModel = Models?.FirstOrDefault(c => c.ContactId == model.ContactId);
        }
        #endregion
    }
}
