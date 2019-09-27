using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FMS.WPF.Models
{
    public class CompanyModel : ModelBase
    {
        #region model properties
        public int CompanyId { get; set; }
        public string Name { get; set; }
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
        public string CompanyTypesString { get; set; }

        public List<CompanyAddressModel> Addresses { get; set; } = new List<CompanyAddressModel>();
        public List<CompanyContactModel> Contacts { get; set; } = new List<CompanyContactModel>();

        private ObservableCollection<CompanyAddressModel> _ocAddresses;
        public ObservableCollection<CompanyAddressModel> OCAddresses =>
            _ocAddresses ?? (_ocAddresses = new ObservableCollection<CompanyAddressModel>(Addresses));

        private ObservableCollection<CompanyContactModel> _ocContacts;
        public ObservableCollection<CompanyContactModel> OCContacts =>
            _ocContacts ?? (_ocContacts = new ObservableCollection<CompanyContactModel>(Contacts));
        #endregion

        #region overrides
        public override bool IsNew => (CompanyId == 0);
        #endregion

        #region dropdowns
        public ICompanyDropdowns Dropdowns => CompanyDropdownsProxy.Instance;

        public IList<PriceListDropdownModel> PriceLists =>
            Dropdowns?.PriceLists.Where(pl => pl.CurrencyCode == CurrencyCode || pl.CurrencyCode == null).ToList();
        #endregion
    }
}
