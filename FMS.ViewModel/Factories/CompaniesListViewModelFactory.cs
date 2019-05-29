﻿using System;
using System.Collections.Generic;
using System.Text;
using FMS.ViewModels;
using Ninject;

namespace FMS.ViewModel.Factories
{
    public class CompaniesListViewModelFactory : ICompaniesListViewModelFactory
    {
        private IKernel _kernel;

        public CompaniesListViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompaniesListViewModel CreateInstance()
        {
            return _kernel.Get<CompaniesListViewModel>();
        }
    }
}
