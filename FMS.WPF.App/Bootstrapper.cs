using FMS.DAL.EFCore.Utils;
using FMS.ServiceLayer.Utils;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Application.Utils;
using FMS.WPF.UI.Utils;
using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.App
{
    public class Bootstrapper
    {
        private IKernel _kernel;

        public Bootstrapper()
        {
            _kernel = new StandardKernel(new NinjectBindingsForDAL(),
                                         new NinjectBindingsForServiceLayer(),
                                         new NinjectBindingsForApplicationLayer(),
                                         new NinjectBindingsForViewModel(),
                                         new NinjectBindingsForUI());

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
