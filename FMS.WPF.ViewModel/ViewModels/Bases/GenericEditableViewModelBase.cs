using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public abstract class GenericEditableViewModelBase<TModel> : ViewModelBase where TModel : EditableModelBase, new()
    {
        #region Properties
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
        #endregion Properties

        #region Commands
        public ICommand EditCommand => new RelayCommand(BeginEdit);
        private void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;

                EditableModel = new TModel();
                EditableModel.Merge(Model);
            }
        }

        public ICommand CancelCommand => new RelayCommand(CancelEdit);
        private void CancelEdit()
        {
            if (IsEditMode)
            {
                EditableModel = Model;
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
                    Model.Merge(EditableModel);
                    EditableModel = Model;
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
                }
            }
        }
        #endregion Commands

        #region Abstract Members
        protected abstract bool SaveItem(TModel model);
        protected abstract void DeleteItem(TModel model);
        protected abstract bool ConfirmDelete();
        #endregion Abstract Members
    }
}
