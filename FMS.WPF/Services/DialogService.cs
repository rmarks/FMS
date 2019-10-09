using FMS.WPF.ViewModels;
using FMS.WPF.Views;
using System.Windows;

namespace FMS.WPF.Services
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

        public void ShowDialog(ViewModelBase viewModel)
        {
            var dialog = new DialogView { DataContext = viewModel };
            dialog.Owner = System.Windows.Application.Current.MainWindow;
            dialog.SizeToContent = SizeToContent.WidthAndHeight;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Title = viewModel.DisplayName;
            dialog.ShowDialog();
        }
    }
}
