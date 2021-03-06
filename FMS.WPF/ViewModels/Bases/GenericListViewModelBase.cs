﻿using FMS.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public abstract class GenericListViewModelBase<TModel> : ViewModelBase
    {
        #region properties
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
                SelectedItemChanged?.Invoke(_selectedItem);
            }
        }
        #endregion

        #region events
        public event Action<TModel> SelectedItemChanged;
        #endregion

        #region commands
        public ICommand RefreshCommand => new RelayCommand(() => Refresh());
        public ICommand ResetCommand => new RelayCommand(Reset);
        public ICommand OpenItemCommand => new RelayCommand(OpenItem);
        public ICommand AddItemCommand => new RelayCommand(AddItem);
        #endregion

        #region abstracts
        public abstract void Refresh(int itemId = 0);
        #endregion

        #region virtuals
        protected virtual void Reset() { }
        protected virtual void OpenItem() { }
        protected virtual void AddItem() { }
        #endregion
    }
}
