using AutoMapper;
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

            InitializeAutoMapper();

            var bootstrapper = new Bootstrapper();

            var mainWindow = new MainWindow { DataContext = bootstrapper.MainWindowViewModel };
            mainWindow.Show();
        }

        private void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<FMS.ServiceLayer.Utils.EntityDtoMappingProfile>();
                cfg.AddProfile<FMS.WPF.ViewModel.Utils.ModelModelMappingProfile>();
                cfg.AddProfile<FMS.WPF.Application.Utils.DtoModelMappingProfile>();
            });
        }
    }
}
