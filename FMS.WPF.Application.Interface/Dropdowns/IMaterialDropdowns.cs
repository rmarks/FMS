using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Dropdowns
{
    public interface IMaterialDropdowns
    {
        IList<MaterialBaseModel> MaterialBases { get; }
        IList<MaterialRecipeModel> MaterialRecipes { get; }
        IList<MaterialShapeModel> MaterialShapes { get; }
    }

    public class MaterialDropdownsProxy
    {
        public static IMaterialDropdowns Instance { get; set; }
    }
}
