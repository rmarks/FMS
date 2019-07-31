namespace FMS.WPF.Application.Interface.Models
{
    public class ProductListModel
    {
        public int ProductBaseId { get; set; }

        public string ProductBaseCode { get; set; }

        public string ProductBaseName { get; set; }

        public string ProductBrandName { get; set; }

        public string ProductCollectionName { get; set; }

        public string ProductSourceTypeName { get; set; }

        public string ProductDestinationTypeName { get; set; }

        public string ProductBrandAndCollectionName => $"{ProductBrandName}{(ProductCollectionName == null ? "" : "/" + ProductCollectionName)}";
    }
}
