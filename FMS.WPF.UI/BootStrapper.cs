using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using Ninject;
using FMS.WPF.ViewModel.Services;
using FMS.WPF.UI.Services;
using FMS.DAL.EFCore.Utils;
using FMS.ServiceLayer.Utils;

namespace FMS.WPF.UI
{
    public class BootStrapper
    {
        private IKernel _kernel;

        public BootStrapper()
        {
            _kernel = new StandardKernel(new NinjectBindingsForDAL(), 
                                         new NinjectBindingsForServiceLayer(),
                                         new NinjectBindingsForViewModel());

            _kernel.Bind<IDialogService>().To<DialogService>().InTransientScope();
            _kernel.Bind<IProgressBarService>().To<ProgressBarService>().InTransientScope();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();
    }
}
