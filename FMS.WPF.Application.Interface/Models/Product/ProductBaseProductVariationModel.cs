﻿namespace FMS.WPF.Application.Interface.Models
{
    public class ProductBaseProductVariationModel
    {
        public int ProductBaseId { get; set; }
        public int ProductVariationId { get; set; }
        public ProductVariationModel ProductVariation { get; set; }
    }
}
