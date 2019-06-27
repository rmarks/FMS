using FMS.WPF.ViewModel.Services;
using FMS.WPF.Views;
using System.Windows;

namespace FMS.WPF.UI.Services
{
    public class ProgressBarService : IProgressBarService
    {
        private ProgressBarView _progressBar;

        public void ShowInDeterminateProgressBar(string title)
        {
            _progressBar = new ProgressBarView();
            _progressBar.Owner = System.Windows.Application.Current.MainWindow;
            _progressBar.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _progressBar.Title = title;
            _progressBar.Start();
        }

        public void CloseProgressBar()
        {
            if (_progressBar != null)
            {
                _progressBar.Stop();
            }
        }
    }
}
