using FMS.WPF.UI.Services;
using FMS.WPF.ViewModel.Services;
using Ninject.Modules;

namespace FMS.WPF.UI.Utils
{
    public class NinjectBindingsForUI : NinjectModule
    {
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService>().InTransientScope();
            Bind<IProgressBarService>().To<ProgressBarService>().InTransientScope();
        }
    }
}
