using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using Ninject;
using FMS.WPF.ViewModel.Services;
using FMS.WPF.UI.Services;
using FMS.DAL.EFCore.Utils;
using FMS.ServiceLayer.Utils;
using FMS.WPF.Application.Utils;
using FMS.WPF.Application.Interface.Dropdowns;

namespace FMS.WPF.UI
{
    public class BootStrapper
    {
        private IKernel _kernel;

        public BootStrapper()
        {
            _kernel = new StandardKernel(new NinjectBindingsForDAL(), 
                                         new NinjectBindingsForServiceLayer(),
                                         new NinjectBindingsForApplicationLayer(),
                                         new NinjectBindingsForViewModel());

            _kernel.Bind<IDialogService>().To<DialogService>().InTransientScope();
            _kernel.Bind<IProgressBarService>().To<ProgressBarService>().InTransientScope();

            ConfigureDropdowns();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private async void ConfigureDropdowns()
        {
            var companyDropdowns = _kernel.Get<ICompanyDropdowns>();
            await companyDropdowns.InitializeAsync();
            CompanyDropdownsProxy.Instance = companyDropdowns;

            var productDropdowns = _kernel.Get<IProductDropdowns>();
            await productDropdowns.InitializeAsync();
            ProductDropdownsProxy.Instance = productDropdowns;
        }
    }
}
