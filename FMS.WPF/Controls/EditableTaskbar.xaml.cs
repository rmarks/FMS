using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMS.WPF.Controls
{
    /// <summary>
    /// Interaction logic for EditableTaskbar.xaml
    /// </summary>
    public partial class EditableTaskbar : UserControl
    {
        public EditableTaskbar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                switch (button.Name)
                {
                    case "buttonEdit":
                        EditCommand?.Execute(null);
                        break;
                    case "buttonDelete":
                        DeleteCommand?.Execute(null);
                        break;
                    case "buttonCancel":
                        CancelCommand?.Execute(null);
                        break;
                    case "buttonSave":
                        SaveCommand?.Execute(null);
                        break;
                    case "buttonAdd":
                        AddCommand?.Execute(null);
                        break;
                }
            }
        }

        #region EditCommand
        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(nameof(EditCommand), typeof(ICommand), typeof(EditableTaskbar));
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(EditableTaskbar));
        #endregion

        #region SaveCommand
        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveCommandProperty = DependencyProperty.Register(nameof(SaveCommand), typeof(ICommand), typeof(EditableTaskbar));
        #endregion

        #region CancelCommand
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(EditableTaskbar));
        #endregion

        #region AddCommand
        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(nameof(AddCommand), typeof(ICommand), typeof(EditableTaskbar));
        #endregion AddCommand

        #region IsEditVisible
        public bool IsEditVisible
        {
            get { return (bool)GetValue(IsEditVisibleProperty); }
            set { SetValue(IsEditVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsEditVisibleProperty = DependencyProperty.Register(nameof(IsEditVisible), typeof(bool), typeof(EditableTaskbar));
        #endregion IsEditVisible

        #region IsDeleteVisible
        public bool IsDeleteVisible
        {
            get { return (bool)GetValue(IsDeleteVisibleProperty); }
            set { SetValue(IsDeleteVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsDeleteVisibleProperty = DependencyProperty.Register(nameof(IsDeleteVisible), typeof(bool), typeof(EditableTaskbar));
        #endregion IsDeleteVisible

        #region IsSaveVisible
        public bool IsSaveVisible
        {
            get { return (bool)GetValue(IsSaveVisibleProperty); }
            set { SetValue(IsSaveVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSaveVisibleProperty = DependencyProperty.Register(nameof(IsSaveVisible), typeof(bool), typeof(EditableTaskbar));
        #endregion IsSaveVisible

        #region IsCancelVisible
        public bool IsCancelVisible
        {
            get { return (bool)GetValue(IsCancelVisibleProperty); }
            set { SetValue(IsCancelVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsCancelVisibleProperty = DependencyProperty.Register(nameof(IsCancelVisible), typeof(bool), typeof(EditableTaskbar));
        #endregion IsCancelVisible

        #region IsAddVisible
        public bool IsAddVisible
        {
            get { return (bool)GetValue(IsAddVisibleProperty); }
            set { SetValue(IsAddVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsAddVisibleProperty = DependencyProperty.Register(nameof(IsAddVisible), typeof(bool), typeof(EditableTaskbar));
        #endregion IsAddVisible
    }
}
