﻿namespace FMS.WPF.Models
{
    public class ProductSourceModel
    {
        public int ProductSourceId { get; set; }

        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }

        public int ProductId { get; set; }
        public int CompanyId { get; set; }
    }
}
