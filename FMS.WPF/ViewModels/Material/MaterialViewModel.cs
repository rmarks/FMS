using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class MaterialViewModel : GenericEditableViewModelBase2<MaterialModel>
    {
        public void Load(MaterialModel model)
        {
            Model = model;
        }
    }
}
