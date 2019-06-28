using System.Windows;

namespace FMS.WPF.UI.Utils
{
    public class DialogCloser : DependencyObject
    {
        public static readonly DependencyProperty DialogInEditModeProperty = DependencyProperty.RegisterAttached(
            "DialogInEditMode", typeof(bool), typeof(DialogCloser), new PropertyMetadata(DialogInEditModeChanged));

        public static bool GetDialogInEditMode(DependencyObject obj)
        {
            return (bool)obj.GetValue(DialogInEditModeProperty);
        }

        public static void SetDialogInEditMode(DependencyObject obj, bool value)
        {
            obj.SetValue(DialogInEditModeProperty, value);
        }

        private static void DialogInEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window && (bool)e.NewValue == false)
            {
                window.Close();
            }
        }
    }
}
