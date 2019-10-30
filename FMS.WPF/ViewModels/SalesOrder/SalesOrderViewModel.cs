using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using FMS.WPF.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class SalesOrderViewModel : GenericEditableViewModelBase2<SalesOrderModel>, IWorkspace
    {
        private readonly ISalesOrderService _service;

        public SalesOrderViewModel(int salesOrderId,
                                   IWorkspaceManager workspaceManager,
                                   ISalesOrderService service)
        {
            WorkspaceManager = workspaceManager;
            _service = service;

            Initialize(salesOrderId);
        }

        #region properties
        public override string DisplayName => Model?.OrderNo == null ? "Uus tellimus" : "Tellimus nr. " + Model.OrderNo;
        public ObservableCollection<SalesOrderLineModel> Lines { get; set; }
        public int VATPercent => Model.VATPercent;
        #endregion

        #region total properties
        public int TotalOrderedQuantity => Lines.Sum(l => l.OrderedQuantity);
        public int TotalInvoicedQuantity => Lines.Sum(l => l.InvoicedQuantity);
        public int TotalReservedQuantity => Lines.Sum(l => l.ReservedQuantity);
        public int TotalMissingQuantity => TotalOrderedQuantity - TotalInvoicedQuantity - TotalReservedQuantity;

        public decimal OrderedSum => Lines.Sum(l => l.OrderedQuantity * l.UnitPrice);
        public decimal OrderedSumWithDiscount => Lines.Sum(l => l.OrderedQuantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2));
        public decimal OrderedSumWithVAT => OrderedSumWithDiscount + Math.Round(OrderedSumWithDiscount* VATPercent / 100m, 1);

        public decimal InvoicedSum => Lines.Sum(l => l.InvoicedQuantity * l.UnitPrice);
        public decimal InvoicedSumWithDiscount => Lines.Sum(l => l.InvoicedQuantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2));
        public decimal InvoicedSumWithVAT => InvoicedSumWithDiscount + Math.Round(InvoicedSumWithDiscount * VATPercent / 100m, 1);

        public decimal ReservedSum => Lines.Sum(l => l.ReservedQuantity * l.UnitPrice);
        public decimal ReservedSumWithDiscount => Lines.Sum(l => l.ReservedQuantity * Math.Round(l.UnitPrice * (1 - l.LineDiscountPercent / 100m), 2));
        public decimal ReservedSumWithVAT => ReservedSumWithDiscount + Math.Round(ReservedSumWithDiscount* VATPercent / 100m, 1);

        public decimal MissingSum => Lines.Sum(l => (l.OrderedQuantity - l.InvoicedQuantity - l.ReservedQuantity) * l.UnitPrice);
        public decimal MissingSumWithDiscount => Lines.Sum(l => (l.OrderedQuantity - l.InvoicedQuantity - l.ReservedQuantity) * Math.Round(l.UnitPrice* (1 - l.LineDiscountPercent / 100m), 2));
        public decimal MissingSumWithVAT => MissingSumWithDiscount + Math.Round(MissingSumWithDiscount * VATPercent / 100m, 1);
        #endregion

        #region helpers
        private void Initialize(int salesOrderId)
        {
            Model = _service.GetSalesOrderModel(salesOrderId);
            
            Lines = new ObservableCollection<SalesOrderLineModel>(Model.SalesOrderLines);
            Model.SalesOrderLines = null;

            EditModeChanged += OnEditModeChanged;
        }
        #endregion

        #region event handlers
        private void OnEditModeChanged(bool isEditMode)
        {
            CloseWorkspaceCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }

        private RelayCommand _closeWorkspaceCommand;
        public RelayCommand CloseWorkspaceCommand => _closeWorkspaceCommand ??
            (_closeWorkspaceCommand = new RelayCommand(() => WorkspaceManager.CloseWorkspace(this), () => CanCloseWorkspace));
        public bool CanCloseWorkspace => !IsEditMode;
        #endregion
    }
}
