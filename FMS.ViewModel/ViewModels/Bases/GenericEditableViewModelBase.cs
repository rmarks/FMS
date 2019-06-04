using FMS.WPF.Model;
using FMS.WPF.ViewModel.Commands;
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
                Model.Merge(EditableModel);
                EditableModel = Model;
            }
            IsEditMode = false;
        }
        #endregion Commands


    }
}
