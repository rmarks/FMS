using FMS.WPF.Models;
using FMS.WPF.Utils;
using System;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class GenericEditableViewModelBase2<TModel> : ViewModelBase where TModel : ModelBase, new()
    {
        #region properties
        public TModel Model { get; set; }
        public TModel BackupModel { get; set; }

        private bool _isEditModel;
        public bool IsEditMode 
        { 
            get => _isEditModel;
            set
            {
                _isEditModel = value;
                EditModeChanged?.Invoke(_isEditModel);
            }
        }
        #endregion

        #region events
        public event Action ItemEditCancelled;
        public event Action<TModel> ItemSaved;
        public event Action ItemDeleted;
        public event Action<bool> EditModeChanged;
        #endregion

        #region commands
        public ICommand EditCommand => new RelayCommand(BeginEdit);
        private void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;

                BackupModel = new TModel();
                MappingFactory.MapTo<TModel, TModel>(Model, BackupModel);
            }
        }

        public ICommand AddCommand => new RelayCommand(AddToEdit);
        private void AddToEdit()
        {
            if (!IsEditMode)
            {
                AddItem();
                BeginEdit();
            }
        }

        public ICommand CancelCommand => new RelayCommand(CancelEdit);
        private void CancelEdit()
        {
            if (IsEditMode)
            {
                MappingFactory.MapTo<TModel, TModel>(BackupModel, Model);
                ItemEditCancelled?.Invoke();
                
                IsEditMode = false;
            }
        }

        public ICommand SaveCommand => new RelayCommand(SaveEdit);
        private void SaveEdit()
        {
            if (IsEditMode)
            {
                if (SaveItem(Model))
                {
                    BackupModel = null;
                    ItemSaved?.Invoke(Model);

                    IsEditMode = false;
                }
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
        protected virtual void AddItem() { }
        #endregion
    }
}
