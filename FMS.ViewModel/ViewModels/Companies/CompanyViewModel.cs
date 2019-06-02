using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        public ObservableCollection<ViewModelBase> CompanyTabs { get; } = new ObservableCollection<ViewModelBase>();
    }
}
