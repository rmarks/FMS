using FMS.WPF.Application.Interface.Models;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IViewModelFactory
    {
        T CreateInstance<T>(int id = 0) where T : ViewModelBase;
        TInstance CreateInstance<TInstance, TParameter>(TParameter param) where TInstance : ViewModelBase;
    }
}
