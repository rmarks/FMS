﻿using FMS.WPF.Models;
using FMS.WPF.Utils;
using System;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public abstract class GenericEditableViewModelBase<TModel> : ViewModelBase where TModel : ModelBase, new()
    {
        #region properties
        private TModel _model;
        public TModel Model
        {
            get => _model;
            set
            {
                _model = value;
                EditableModel = _model;
            }
        }

        public TModel EditableModel { get; set; }

        public bool IsEditMode { get; set; }
        #endregion

        #region events
        public event Action ItemEditCancelled;
        public event Action<TModel> ItemSaved;
        public event Action ItemDeleted;
        #endregion

        #region commands
        public ICommand EditCommand => new RelayCommand(BeginEdit);
        private void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;

                EditableModel = new TModel();
                MappingFactory.MapTo<TModel, TModel>(Model, EditableModel);
            }
        }

        public ICommand CancelCommand => new RelayCommand(CancelEdit);
        private void CancelEdit()
        {
            if (IsEditMode)
            {
                EditableModel = Model;

                ItemEditCancelled?.Invoke();
            }
            IsEditMode = false;
        }

        public ICommand SaveCommand => new RelayCommand(SaveEdit);
        private void SaveEdit()
        {
            if (IsEditMode)
            {
                if (SaveItem(EditableModel))
                {
                    MappingFactory.MapTo<TModel, TModel>(EditableModel, Model);
                    EditableModel = Model;

                    ItemSaved?.Invoke(Model);
                }
                IsEditMode = false;
            }
        }

        public ICommand DeleteCommand => new RelayCommand(Delete);
        private void Delete()
        {
            if (!IsEditMode)
            {
                if (ConfirmDelete())
                {
                    DeleteItem(Model);

                    ItemDeleted?.Invoke();
                }
            }
        }
        #endregion

        #region virtuals
        protected virtual bool SaveItem(TModel model) { return false; }
        protected virtual void DeleteItem(TModel model) { }
        protected virtual bool ConfirmDelete() { return false; }
        #endregion
    }
}
