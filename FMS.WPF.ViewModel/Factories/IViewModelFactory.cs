using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IViewModelFactory
    {
        T CreateInstance<T>(string paramName = null, int paramValue = 0) where T : ViewModelBase;
    }
}
