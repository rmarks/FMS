using FMS.WPF.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public abstract class GenericListViewModelBase<TModel> : ViewModelBase
    {
        #region Properties
        public IList<TModel> Items { get; set; }
        public int? ItemsCount { get; set; }

        public string Query { get; set; }

        public virtual string QueryDefaultText { get; set; }

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
        public event Action<TModel> RequestOpenItem;
        #endregion Events

        #region Commands
        public ICommand RefreshCommand => new RelayCommand(() => Refresh(selectFirstItem: true));
        public ICommand ResetCommand => new RelayCommand(Reset);
        public ICommand OpenItemCommand => new RelayCommand(() => RequestOpenItem?.Invoke(SelectedItem));
        #endregion Commands

        #region Abstract or Virtual Members
        public abstract void Refresh(bool selectFirstItem = false);

        protected virtual void Reset() {}
        #endregion Abstract Members
    }
}
