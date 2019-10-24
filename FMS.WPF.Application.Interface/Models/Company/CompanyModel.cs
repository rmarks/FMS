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

        public ObservableCollection<CompanyAddressModel> Addresses { get; set; } = new ObservableCollection<CompanyAddressModel>();
        public ObservableCollection<CompanyContactModel> Contacts { get; set; } = new ObservableCollection<CompanyContactModel>();
        public ObservableCollection<CompanyCompanyTypeModel> CompanyTypesLink { get; set; } = new ObservableCollection<CompanyCompanyTypeModel>();
        #endregion

        #region overrides
        public override bool IsNew => (CompanyId == 0);
        #endregion

        #region public methods
        public void AddCompanyType(CompanyTypeModel model)
        {
            CompanyTypesLink.Add(new CompanyCompanyTypeModel
            {
                CompanyId = this.CompanyId,
                CompanyTypeId = model.CompanyTypeId,
                CompanyType = model
            });

            RaisePropertyChanged(nameof(AddableCompanyTypes));
        }

        public void RemoveCompanyType(CompanyCompanyTypeModel model)
        {

            CompanyTypesLink.Remove(model);

            RaisePropertyChanged(nameof(AddableCompanyTypes));
        }
        #endregion

        #region dropdowns
        public ICompanyDropdowns Dropdowns => CompanyDropdownsProxy.Instance;

        public IList<PriceListDropdownModel> PriceLists =>
            Dropdowns?.PriceLists.Where(pl => pl.CurrencyCode == CurrencyCode || pl.CurrencyCode == null).ToList();

        public List<CompanyTypeModel> AddableCompanyTypes => Dropdowns.CompanyTypes
            .Where(ct => CompanyTypesLink.All(l => l.CompanyType.CompanyTypeId != ct.CompanyTypeId))
            .Select(ct => ct)
            .ToList();
        #endregion
    }
}
