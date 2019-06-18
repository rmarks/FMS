using System;
using System.Collections.Generic;

namespace FMS.WPF.Model
{
    public class CompanyBasicsModel :EditableModelBase
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string VATNo { get; set; }

        public string RegNo { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsVAT { get; set; }

        public int PaymentDays { get; set; }

        public string DeliveryTermName { get; set; }

        public int FixedDiscountPercent { get; set; }

        public DateTime? CreatedOn { get; set; }

        public CompanyAddressModel BillingAddress { get; set; }

        public IList<CountryModel>  Countries { get; set; }

        public IList<CurrencyModel> Currencies { get; set; }


        public override void Merge(EditableModelBase source)
        {
            if (source is CompanyBasicsModel s)
            {
                CompanyId = s.CompanyId;
                CompanyCode = s.CompanyCode;
                CompanyName = s.CompanyName;
                VATNo = s.VATNo;
                RegNo = s.RegNo;
                CurrencyCode = s.CurrencyCode;
                IsVAT = s.IsVAT;
                PaymentDays = s.PaymentDays;
                DeliveryTermName = s.DeliveryTermName;
                FixedDiscountPercent = s.FixedDiscountPercent;
                CreatedOn = s.CreatedOn;

                BillingAddress = new CompanyAddressModel
                {
                    CompanyAddressId = s.BillingAddress.CompanyAddressId,
                    CompanyId = s.BillingAddress.CompanyId,
                    CountryId = s.BillingAddress.CountryId,
                    CountryName = s.BillingAddress.CountryName,
                    City = s.BillingAddress.City,
                    Address = s.BillingAddress.Address,
                    PostCode = s.BillingAddress.PostCode,
                    Description = s.BillingAddress.Description,
                    IsBilling = s.BillingAddress.IsBilling,
                    CreatedOn = s.CreatedOn
                };
            }
        }
    }
}
