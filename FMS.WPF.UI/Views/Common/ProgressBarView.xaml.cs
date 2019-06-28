using System.ComponentModel;
using System.Windows;

namespace FMS.WPF.Views
{
    /// <summary>
    /// Interaction logic for ProgressBarView.xaml
    /// </summary>
    public partial class ProgressBarView : Window
    {
        private BackgroundWorker _worker;

        public ProgressBarView()
        {
            InitializeComponent();
        }

        public void Start()
        {
            this.Show();

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.RunWorkerAsync();

            System.Windows.Application.Current.MainWindow.IsEnabled = false;
        }

        public void Stop()
        {
            System.Windows.Application.Current.MainWindow.IsEnabled = true;

            _worker.CancelAsync();
            this.Close();
        }
    }
}
