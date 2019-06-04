using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMS.WPF.UI.Controls
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

        #region IsEditMode
        public bool IsEditMode
        {
            get { return (bool)GetValue(IsEditModeProperty); }
            set { SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(nameof(IsEditMode), typeof(bool), typeof(EditableTaskbar));
        #endregion
    }
}
