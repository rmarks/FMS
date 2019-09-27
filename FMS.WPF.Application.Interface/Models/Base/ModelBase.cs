using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region virtuals
        public virtual bool IsNew { get; }
        #endregion

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
        #endregion
    }
}
