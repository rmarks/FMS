
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Services
{
    public interface IDialogService
    {
        bool ShowMessageBox(string content, string title = "Teade", string buttons = "OK");

        void ShowDialog(ViewModelBase viewModel);
    }
}
