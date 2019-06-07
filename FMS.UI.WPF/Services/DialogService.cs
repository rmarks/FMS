using FMS.WPF.ViewModel.Services;
using System.Windows;

namespace FMS.WPF.UI.Services
{
    public class DialogService : IDialogService
    {
        public bool ShowMessageBox(string content, string title = "Teade", string buttons = "OK")
        {
            buttons = buttons.ToUpper();
            MessageBoxButton msgButtons = default(MessageBoxButton);

            switch (buttons)
            {
                case "OK":
                    msgButtons = MessageBoxButton.OK;
                    break;
                case "YESNO":
                    msgButtons = MessageBoxButton.YesNo;
                    break;
                default:
                    return false;
            }

            MessageBoxResult result = MessageBox.Show(content, title, msgButtons);

            return (result == MessageBoxResult.OK || result == MessageBoxResult.Yes) ? true : false;
        }
    }
}
