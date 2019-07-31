using AutoMapper;
using FMS.ServiceLayer.Utils;
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
                cfg.AddProfile<EntityDtoMappingProfile>();
                cfg.AddProfile<FMS.WPF.ViewModel.Utils.ModelModelMappingProfile>();
                cfg.AddProfile<FMS.WPF.Application.Utils.DtoModelMappingProfile>();
            });
        }
    }
}
