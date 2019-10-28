using FMS.WPF.Application.Interface.Dropdowns;

namespace FMS.WPF.Models
{
    public class MaterialModel : ModelBase
    {
        #region properties
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }

        public int MaterialBaseId { get; set; }
        public int MaterialRecipeId { get; set; }
        public int MaterialShapeId { get; set; }

        public double Diameter { get; set; }
        public double Thickness { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        #endregion

        #region Dropdowns
        public IMaterialDropdowns Dropdowns => MaterialDropdownsProxy.Instance;
        #endregion
    }
}
