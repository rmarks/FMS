using FMS.WPF.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class ProductPricesViewModel : ViewModelBase
    {
        public ProductPricesViewModel(ProductBaseModel model)
        {
            Model = model;
            InitializePriceLists();
        }

        #region properties
        public override string DisplayName => "Hinnad";
        public ProductBaseModel Model { get; set; }
        public ObservableCollection<PriceListModel> PriceLists { get; private set; }

        private PriceListModel _selectedPriceList;
        public PriceListModel SelectedPriceList 
        { 
            get => _selectedPriceList;
            set
            {
                _selectedPriceList = value;
                InitializePrices();
            }
        }
        
        public ObservableCollection<PriceModel> Prices { get; set; }
        public bool IsEditMode { get; set; }
        #endregion

        #region helpers
        private void InitializePriceLists()
        {
            PriceLists = new ObservableCollection<PriceListModel>(Model.PriceLists);
            SelectedPriceList = PriceLists.FirstOrDefault();
        }

        private void InitializePrices()
        {
            if (SelectedPriceList != null)
            {
                Prices = new ObservableCollection<PriceModel>(SelectedPriceList.Prices);
            }
            else
            {
                Prices = null;
            }
            
        }
        #endregion

        #region event handlers
        public void OnProductEditCancelled()
        {
            InitializePriceLists();
        }
        #endregion
    }
}
