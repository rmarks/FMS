using FMS.WPF.ViewModels;

namespace FMS.WPF.Utils
{
    public interface IViewModelFactory
    {
        T CreateInstance<T>(int id = 0) where T : ViewModelBase;
        TInstance CreateInstance<TInstance, TParameter>(TParameter param) where TInstance : ViewModelBase;
    }
}
