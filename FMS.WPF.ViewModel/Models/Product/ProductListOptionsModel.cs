using System;

namespace FMS.WPF.Models
{
    public class ProductListOptionsModel : EditableModelBase
    {
        public int? ProductSourceTypeId { get; set; }

        public int? ProductDestinationTypeId { get; set; }

        public int? ProductBrandId { get; set; }

        public int? ProductCollectionId { get; set; }


        public override void Merge(EditableModelBase source)
        {
            throw new NotImplementedException();
        }
    }
}
