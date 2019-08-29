using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FMS.WPF.ViewModel.Factories;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactsViewModel : ViewModelBase
    {
        #region fields
        private readonly IDialogService _dialogService;
        private readonly IViewModelFactory _viewModelFactory;
        #endregion

        public CompanyContactsViewModel(IDialogService dialogService,
                                        IViewModelFactory viewModelFactory)
        {
            _dialogService = dialogService;
            _viewModelFactory = viewModelFactory;
        }

        public void Load(CompanyModel model)
        {
            Models = new ObservableCollection<CompanyContactModel>(model.Contacts);
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
                var viewModel = GetContactViewModel(SelectedModel);
                _dialogService.ShowDialog(viewModel);
            }
        }

        public ICommand AddCommand => new RelayCommand(OnAdd);
        private void OnAdd()
        {
            var viewModel = GetContactViewModel(new CompanyContactModel());
            viewModel.ItemSaved += (model) => 
            { 
                Models.Add(model); 
                SelectedModel = model; 
            };

            _dialogService.ShowDialog(viewModel);
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        private void OnDelete()
        {
            if (SelectedModel != null)
            {
                if (_dialogService.ShowMessageBox("Kas kustutame kontakti?", "Kustutamine", "YesNo"))
                {
                    Models.Remove(SelectedModel);
                }
            }
        }
        #endregion

        #region helpers
        private CompanyContactViewModel GetContactViewModel(CompanyContactModel model)
        {
            return _viewModelFactory.CreateInstance<CompanyContactViewModel, CompanyContactModel>(model);
        }
        #endregion
    }
}
