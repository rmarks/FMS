using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FMS.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties
        public virtual string DisplayName { get; protected set; }
        #endregion Properties

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChangedToAll()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
        #endregion INotifyPropertyChanged
    }
}
