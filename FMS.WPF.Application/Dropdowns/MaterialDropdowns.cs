using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Dropdowns
{
    public class MaterialDropdowns : IMaterialDropdowns
    {
        #region properties
        private IList<MaterialBaseModel> _materialBases;
        public IList<MaterialBaseModel> MaterialBases => _materialBases ?? (_materialBases = GetMaterialBases());

        private IList<MaterialRecipeModel> _materialRecipes;
        public IList<MaterialRecipeModel> MaterialRecipes => _materialRecipes ?? (_materialRecipes = GetMaterialRecipes());

        private IList<MaterialShapeModel> _materialShapes;
        public IList<MaterialShapeModel> MaterialShapes => _materialShapes ?? (_materialShapes = GetMaterialShapes());
        #endregion

        #region helpers
        private IList<MaterialBaseModel> GetMaterialBases()
        {
            return new List<MaterialBaseModel> 
            { 
                new MaterialBaseModel { MaterialBaseId = 1, MaterialBaseName = "Kuld" },
                new MaterialBaseModel { MaterialBaseId = 2, MaterialBaseName = "Hõbe" }
            };
        }

        private IList<MaterialRecipeModel> GetMaterialRecipes()
        {
            return new List<MaterialRecipeModel>
            {
                new MaterialRecipeModel { MaterialRecipeId = 1, MaterialRecipeName = "830", MaterialBaseId = 2 },
                new MaterialRecipeModel { MaterialRecipeId = 2, MaterialRecipeName = "550 joodis KAR No.8", MaterialBaseId = 2 },
                new MaterialRecipeModel { MaterialRecipeId = 3, MaterialRecipeName = "999", MaterialBaseId = 2 }
            };
        }

        private IList<MaterialShapeModel> GetMaterialShapes()
        {
            return new List<MaterialShapeModel>
            {
                new MaterialShapeModel { MaterialShapeId = 1, MaterialShapeName = "Leht" },
                new MaterialShapeModel { MaterialShapeId = 2, MaterialShapeName = "Anood" },
                new MaterialShapeModel { MaterialShapeId = 3, MaterialShapeName = "Pulber" }
            };
        }
        #endregion
    }
}
