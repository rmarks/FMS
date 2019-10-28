using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Services.Material
{
    public class MaterialListService : IMaterialListService
    {
        public IList<MaterialModel> Materials { get; set; }

        public IList<MaterialModel> GetMaterialModels()
        {
            if (Materials == null)
            {
                Materials = GetMaterials();
            }

            return Materials;
        }

        #region helpers
        private IList<MaterialModel> GetMaterials()
        {
            return new List<MaterialModel> 
            { 
                new MaterialModel { MaterialId = 1, MaterialCode = "2-629", MaterialName = "Hõbe 830 Leht 0.35x200x500 mm" , 
                    MaterialBaseId = 2, MaterialRecipeId = 1, MaterialShapeId = 1, Thickness = 0.35, Width = 200, Length = 500 },
                new MaterialModel { MaterialId = 2, MaterialCode = "2-999", MaterialName = "Hõbe 550 joodis KAR No.8 Pulber" ,
                    MaterialBaseId = 2, MaterialRecipeId = 2, MaterialShapeId = 3 },
                new MaterialModel { MaterialId = 3, MaterialCode = "2-998", MaterialName = "Hõbe 999 Anood 10x80x300 mm" ,
                    MaterialBaseId = 2, MaterialRecipeId = 3, MaterialShapeId = 2, Thickness = 10, Width = 80, Length = 300 }
            };
        }
        #endregion
    }
}
