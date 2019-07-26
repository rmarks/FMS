using FMS.WPF.Application.Interface.Models;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Utils;
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

        #region commands
        public ICommand EditCommand => new RelayCommand(BeginEdit);
        private void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;

                //EditableModel = new TModel();
                //EditableModel.Merge(Model);
                EditableModel = MappingFactory.MapTo<TModel>(Model);
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
                    //Model.Merge(EditableModel);
                    MappingFactory.MapTo<TModel, TModel>(EditableModel, Model);
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
        #endregion

        #region virtuals
        protected virtual bool SaveItem(TModel model) { return false; }
        protected virtual void DeleteItem(TModel model) { }
        protected virtual bool ConfirmDelete() { return false; }
        #endregion
    }
}
