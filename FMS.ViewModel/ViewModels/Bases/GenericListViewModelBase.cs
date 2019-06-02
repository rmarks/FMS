using System;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public abstract class GenericListViewModelBase<TModel> : ViewModelBase
    {
        #region Properties
        public IList<TModel> Items { get; set; }

        private TModel _selectedItem;
        public TModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                SelectedItemChanged?.Invoke();
            }
        }
        #endregion Properties

        #region Events
        public event Action SelectedItemChanged;
        #endregion Events

        #region Abstract Members
        protected abstract void Refresh();
        #endregion Abstract Members
    }
}
