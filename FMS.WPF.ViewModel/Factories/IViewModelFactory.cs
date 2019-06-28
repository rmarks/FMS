﻿using FMS.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IViewModelFactory<TViewModel> where TViewModel : ViewModelBase
    {
        TViewModel CreateInstance(int Id = 0);
    }
}