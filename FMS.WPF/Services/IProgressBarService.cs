namespace FMS.WPF.Services
{
    public interface IProgressBarService
    {
        void ShowInDeterminateProgressBar(string title);
        void CloseProgressBar();
    }
}
