using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public abstract class OptionsModelBase : ModelBase
    {
        #region properties
        public Action SetDefaultOptions { get; set; }
        #endregion

        #region options change notification and reset
        public virtual void Reset()
        {
            //GetType().GetProperties()
            //    //.Where(pi => pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(string))
            //    .Where(pi => pi.CanWrite && pi.PropertyType != typeof(Action))
            //    .ToList()
            //    .ForEach(pi => pi.SetValue(this, null));

            GetType().GetProperties()
                .Where(pi => pi.CanWrite && (pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(string)))
                .ToList()
                .ForEach(pi => pi.SetValue(this, null));

            GetType().GetProperties()
                .Where(pi => pi.CanWrite && pi.PropertyType == typeof(bool))
                .ToList()
                .ForEach(pi => pi.SetValue(this, false));

            SetDefaultOptions?.Invoke();
        }

        public event Action OptionChanged;

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
            OptionChanged?.Invoke();
        }
        #endregion
    }
}
