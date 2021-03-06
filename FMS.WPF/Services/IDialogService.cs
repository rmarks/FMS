﻿using FMS.WPF.ViewModels;

namespace FMS.WPF.Services
{
    public interface IDialogService
    {
        bool ShowMessageBox(string content, string title = "Teade", string buttons = "OK");

        void ShowDialog(ViewModelBase viewModel);
    }
}
