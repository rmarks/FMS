using System.Windows.Controls;
using System.Windows.Input;

namespace FMS.WPF.Views
{
    /// <summary>
    /// Interaction logic for ProductPricesView.xaml
    /// </summary>
    public partial class ProductPricesView : UserControl
    {
        public ProductPricesView()
        {
            InitializeComponent();

            //Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)dgridPriceLists.ItemContainerGenerator.ContainerFromIndex(dgridPriceLists.SelectedIndex);
            dgRow.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
}
