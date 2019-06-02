using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModel.Factories
{
    public abstract class ViewModelFactoryBase
    {
        protected IKernel _kernel;

        public ViewModelFactoryBase(IKernel kernel)
        {
            _kernel = kernel;
        }
    }
}
