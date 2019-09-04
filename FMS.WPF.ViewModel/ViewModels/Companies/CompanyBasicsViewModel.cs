using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : ViewModelBase
    {
        #region properties
        public override string DisplayName => "Üldandmed";
        public CompanyModel Model { get; set; }
        public bool IsEditMode { get; set; }
        #endregion

        #region public methods
        public void Load(CompanyModel model)
        {
            Model = model;
        }
        #endregion
    }
}
