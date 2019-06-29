using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public abstract class EditableModelBase : INotifyPropertyChanged
    {
        public abstract void Merge(EditableModelBase source);

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
