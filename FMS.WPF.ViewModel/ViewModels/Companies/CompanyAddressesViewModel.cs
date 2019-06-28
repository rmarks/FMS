﻿using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        private int _companyId;

        public CompanyAddressesViewModel(ICompanyService companyService, IDialogService dialogService)
        {
            DisplayName = "Saajad";

            _companyService = companyService;
            _dialogService = dialogService;
        }

        public void Load(int companyId)
        {
            _companyId = companyId;

            Models = _companyId > 0 
                ? new ObservableCollection<CompanyAddressModel>(_companyService.GetCompanyAddressModelsForShipping(_companyId)) 
                : null;
        }

        public ObservableCollection<CompanyAddressModel> Models { get; private set; }

        public CompanyAddressModel SelectedModel { get; set; }

        #region Commands
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
                var viewModel = new CompanyAddressViewModel(SelectedModel, _companyService, _dialogService);
                viewModel.IsEditMode = false;
                viewModel.DeleteCommand?.Execute(null);
                if (SelectedModel.CompanyAddressId == 0)
                {
                    Load(_companyId);
                }
            }
        }
        #endregion Commands

        #region Helpers
        private void ShowAddress(CompanyAddressModel model)
        {
            var viewModel = new CompanyAddressViewModel(model, _companyService, _dialogService);
            _dialogService.ShowDialog(viewModel);

            Load(_companyId);
            SelectedModel = Models?.FirstOrDefault(a => a.CompanyAddressId == model.CompanyAddressId);
        }
        #endregion Helpers
    }
}