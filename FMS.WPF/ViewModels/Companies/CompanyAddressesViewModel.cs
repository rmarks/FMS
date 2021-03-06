﻿using FMS.WPF.Models;
using FMS.WPF.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FMS.WPF.Utils;
using System;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressesViewModel : ViewModelBase
    {
        #region fields
        private readonly IDialogService _dialogService;
        private readonly IViewModelFactory _viewModelFactory;
        #endregion

        public CompanyAddressesViewModel(IDialogService dialogService,
                                         IViewModelFactory viewModelFactory)
        {
            _dialogService = dialogService;
            _viewModelFactory = viewModelFactory;
        }

        #region properties
        public override string DisplayName => "Saajad";
        public ObservableCollection<CompanyAddressModel> Models { get; private set; }
        public CompanyAddressModel SelectedModel { get; set; }
        public bool IsEditMode { get; set; }
        #endregion

        #region public methods
        public void Load(CompanyModel model)
        {
            Models = model.Addresses;
        }
        #endregion

        #region commands
        public ICommand EditCommand => new RelayCommand(OnEdit);
        private void OnEdit()
        {
            if (SelectedModel != null)
            {
                var viewModel = GetAddressViewModel(SelectedModel);
                _dialogService.ShowDialog(viewModel);
            }
        }

        public ICommand AddCommand => new RelayCommand(OnAdd);
        private void OnAdd()
        {
            var viewModel = GetAddressViewModel(new CompanyAddressModel
            {
                IsShipping = true,
                CreatedOn = DateTime.Now
            });

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
                if (_dialogService.ShowMessageBox("Kas kustutame aadressi?", "Kustutamine", "YesNo"))
                {
                    Models.Remove(SelectedModel);
                }
            }
        }
        #endregion

        #region helpers
        private CompanyAddressViewModel GetAddressViewModel(CompanyAddressModel model)
        {
            return _viewModelFactory.CreateInstance<CompanyAddressViewModel, CompanyAddressModel>(model);
        }
        #endregion
    }
}
