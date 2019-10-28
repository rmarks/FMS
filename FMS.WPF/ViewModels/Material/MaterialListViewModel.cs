using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class MaterialListViewModel : GenericListViewModelBase<MaterialModel>
    {
        private readonly IMaterialListService _service;

        public MaterialListViewModel(IMaterialListService service)
        {
            _service = service;
        }

        public void Load()
        {
            Refresh();
        }

        #region overrides
        public override void Refresh(int materialId = 0)
        {
            Items = _service.GetMaterialModels();

            SelectedItem = materialId == 0 ? Items.FirstOrDefault() 
                                           : Items.FirstOrDefault(i => i.MaterialId == materialId);
        }
        #endregion
    }
}
