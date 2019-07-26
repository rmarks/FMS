using FMS.WPF.Application.Interface.Models;
using System;

namespace FMS.WPF.Models
{
    public class CompanyBasicsModel : ModelBase
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string VATNo { get; set; }

        public string RegNo { get; set; }

        public string CurrencyCode { get; set; }

        public int? PriceListId { get; set; }

        public int? LocationId { get; set; }

        public int PaymentDays { get; set; }

        public string DeliveryTermName { get; set; }

        public int FixedDiscountPercent { get; set; }

        public bool IsVAT { get; set; }

        public DateTime? CreatedOn { get; set; }

        public CompanyAddressModel BillingAddress { get; set; }


        //public override void Merge(EditableModelBase source)
        //{
        //    if (source is CompanyBasicsModel s)
        //    {
        //        CompanyId = s.CompanyId;
        //        CompanyName = s.CompanyName;
        //        VATNo = s.VATNo;
        //        RegNo = s.RegNo;
        //        CurrencyCode = s.CurrencyCode;
        //        PriceListId = s.PriceListId;
        //        LocationId = s.LocationId;
        //        PaymentDays = s.PaymentDays;
        //        DeliveryTermName = s.DeliveryTermName;
        //        FixedDiscountPercent = s.FixedDiscountPercent;
        //        IsVAT = s.IsVAT;
        //        CreatedOn = s.CreatedOn;

        //        BillingAddress = new CompanyAddressModel
        //        {
        //            CompanyAddressId = s.BillingAddress.CompanyAddressId,
        //            CompanyId = s.BillingAddress.CompanyId,
        //            CountryId = s.BillingAddress.CountryId,
        //            CountryCountryName = s.BillingAddress.CountryCountryName,
        //            County = s.BillingAddress.County,
        //            City = s.BillingAddress.City,
        //            Address = s.BillingAddress.Address,
        //            PostCode = s.BillingAddress.PostCode,
        //            ConsigneeName = s.BillingAddress.ConsigneeName,
        //            IsBilling = s.BillingAddress.IsBilling,
        //            CreatedOn = s.CreatedOn
        //        };
        //    }
        //}
    }
}
