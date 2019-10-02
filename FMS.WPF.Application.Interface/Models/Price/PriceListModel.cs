using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FMS.WPF.Models
{
    public class PriceListModel
    {
        public int PriceListId { get; set; }
        public string PriceListName { get; set; }
        public bool IsVAT { get; set; }
        public string CurrencyCode { get; set; }
        public List<PriceModel> Prices { get; set; }

        private ObservableCollection<PriceModel> _ocPrices;
        public ObservableCollection<PriceModel> OCPrices => _ocPrices ?? (_ocPrices = new ObservableCollection<PriceModel>(Prices));
    }
}
