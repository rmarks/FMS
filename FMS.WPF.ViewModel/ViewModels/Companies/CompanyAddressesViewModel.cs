using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        #region fields
        private ICompanyFacadeService _companyFacadeService;
        private IDialogService _dialogService;
        private int _companyId;
        #endregion

        public CompanyAddressesViewModel(ICompanyFacadeService companyFacadeService, 
                                         IDialogService dialogService)
        {
            _companyFacadeService = companyFacadeService;
            _dialogService = dialogService;
        }

        #region properties
        public override string DisplayName => "Saajad";
        public ObservableCollection<CompanyAddressModel> Models { get; private set; }
        public CompanyAddressModel SelectedModel { get; set; }
        #endregion

        #region public methods
        public async void Load(int companyId)
        {
            _companyId = companyId;

            var models = await _companyFacadeService.GetCompanyAddressModelsAsync(_companyId);

            Models = models != null
                ? new ObservableCollection<CompanyAddressModel>(models)
                : null;
        }
        #endregion

        #region commands
        public ICommand EditCommand => new RelayCommand(OnEdit);
        private void OnEdit()
        {
            if (SelectedModel != null)
            {
                ShowAddress(SelectedModel);
            }
        }

        public ICommand AddCommand => new RelayCommand(OnAdd);
        private void OnAdd()
        {
            ShowAddress(new CompanyAddressModel { CompanyId = _companyId });
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        private void OnDelete()
        {
            if (SelectedModel != null)
            {
                var viewModel = new CompanyAddressViewModel(SelectedModel, _companyFacadeService, _dialogService);//, _dropdownsService);
                viewModel.IsEditMode = false;
                viewModel.DeleteCommand?.Execute(null);
                if (SelectedModel.CompanyAddressId == 0)
                {
                    Load(_companyId);
                }
            }
        }
        #endregion

        #region helpers
        private void ShowAddress(CompanyAddressModel model)
        {
            var viewModel = new CompanyAddressViewModel(model, _companyFacadeService, _dialogService);
            _dialogService.ShowDialog(viewModel);

            Load(_companyId);
            SelectedModel = Models?.FirstOrDefault(a => a.CompanyAddressId == model.CompanyAddressId);
        }
        #endregion
    }
}
