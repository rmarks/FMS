using FMS.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.UI.WPF
{
    public class BootStrapper
    {
        private IKernel _kernel = new StandardKernel();

        public BootStrapper()
        {
            BindViewModels();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private void BindViewModels()
        {
            _kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            _kernel.Bind<CompaniesViewModel>().ToSelf().InTransientScope();
        }
    }
}
