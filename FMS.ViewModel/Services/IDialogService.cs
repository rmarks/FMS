
namespace FMS.WPF.ViewModel.Services
{
    public interface IDialogService
    {
        bool ShowMessageBox(string content, string title = "Teade", string buttons = "OK");
    }
}
