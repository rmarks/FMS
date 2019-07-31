namespace FMS.WPF.ViewModel.Services
{
    public interface IProgressBarService
    {
        void ShowInDeterminateProgressBar(string title);
        void CloseProgressBar();
    }
}
