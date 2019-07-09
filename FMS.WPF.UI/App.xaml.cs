using AutoMapper;
using FMS.WPF.Application.Utils;
using System.Windows;

namespace FMS.WPF.UI
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
        }

        private void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ModelMappingProfile>();
            });
        }
    }
}
