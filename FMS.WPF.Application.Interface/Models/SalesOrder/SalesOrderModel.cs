using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public class SalesOrderModel : ModelBase
    {
        #region model properties
        public int SalesOrderId { get; set; }
        
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }

        public string ClientOrderNo { get; set; }
        public DateTime? ClientOrderDate { get; set; }
        public DateTime? ClientOrderDeliveryDate { get; set; }

        public int CompanyId { get; set; }
        public CustomerModel Company { get; set; }
        public int BillingAddressId { get; set; }
        public CustomerAddressModel BillingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public CustomerAddressModel ShippingAddress { get; set; }

        public int LocationId { get; set; }

        public string CurrencyCode { get; set; }
        public int PriceListId { get; set; }

        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }

        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IList<SalesOrderLineModel> SalesOrderLines { get; set; }
        #endregion

        #region dropdowns
        public ISalesOrderDropdowns Dropdowns => SalesOrderDropdownsProxy.Instance;

        public IList<CustomerAddressModel> ShipTos => Dropdowns.Customers.FirstOrDefault(a => a.CompanyId == CompanyId)?.Addresses;
        #endregion

        #region overrides
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(CompanyId):
                    RaisePropertyChanged(nameof(ShipTos));
                    break;
                case nameof(ShippingAddressId):
                    ShippingAddress = ShipTos.FirstOrDefault(a => a.CompanyAddressId == ShippingAddressId);
                    break;
            }
        }
        #endregion
    }
}
