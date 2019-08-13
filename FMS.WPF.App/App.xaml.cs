using FMS.WPF.Views;
using System.Windows;

namespace FMS.WPF.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();

            var mainWindow = new MainWindow { DataContext = bootstrapper.MainWindowViewModel };
            mainWindow.Show();
        }
    }
}
