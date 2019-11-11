using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Services;
using FMS.WPF.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System;
using System.Configuration;

namespace FMS.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region fields
        private IDataTransferService _dataTransferService;
        private IProgressBarService _progressBarService;
        private IDialogService _dialogService;
        #endregion

        #region constructors
        public MainWindowViewModel(IWorkspaceManager workspaceManager, 
                                   IDataTransferService dataTransferService,
                                   IProgressBarService progressBarService,
                                   IDialogService dialogService)
        {
            WorkspaceManager = workspaceManager;
            _dataTransferService = dataTransferService;
            _progressBarService = progressBarService;
            _dialogService = dialogService;

            CreateCommands();

            workspaceManager.WorkspaceSelected += (ws) => SelectedWorkspace = ws;
        }
        #endregion

        #region properties
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();
        public IWorkspaceManager WorkspaceManager { get; }
        public ObservableCollection<IWorkspace> Workspaces => WorkspaceManager.Workspaces;
        public IWorkspace SelectedWorkspace { get; set; }
        public string DataTransferDateTime => ConfigurationManager.AppSettings["DataTransferDateTime"];
        #endregion

        #region commands
        private ICommand _transferDataCommand;
        public ICommand TransferDataCommand => _transferDataCommand ?? (_transferDataCommand = new RelayCommand(TransferData));
        private async void TransferData()
        {
            if (_dialogService.ShowMessageBox("Kas kustutame vanad andmed?", "Kustutamine", "YesNo"))
            {
                _progressBarService.ShowInDeterminateProgressBar("Andmete kustutamine");
                await Task.Run(() => _dataTransferService.ClearDatabase());
                _progressBarService.CloseProgressBar();

                UpdateDataTransferDateTime(isOnlyClearNeeded: true);

                if (_dialogService.ShowMessageBox("Kas kopeerime uued andmed?", "Teade", "YesNo"))
                {
                    _progressBarService.ShowInDeterminateProgressBar("Andmete värskendamine");
                    bool isSuccess = await Task.Run(() => _dataTransferService.TransferData());
                    _progressBarService.CloseProgressBar();

                    if (isSuccess)
                    {
                        _dialogService.ShowMessageBox("Andmed värskendatud!");
                        UpdateDataTransferDateTime();
                    }
                    else
                    {
                        _dialogService.ShowMessageBox("Andmete värskendamine ebaõnnestus!");
                    }
                }
            }
        }
        #endregion

        #region helpers
        private void CreateCommands()
        {
            //sale
            CommandTreeGroupViewModel groupSale = new CommandTreeGroupViewModel("Müük");
            Commands.Add(groupSale);

            CommandTreeItemViewModel commandSalesOrders =
                new CommandTreeItemViewModel("Müügitellimused", new RelayCommand(() => WorkspaceManager.OpenWorkspace<SalesOrderListViewModel>()));
            groupSale.CommandTreeItems.Add(commandSalesOrders);

            //purchase
            CommandTreeGroupViewModel groupPurchase = new CommandTreeGroupViewModel("Ost");
            Commands.Add(groupPurchase);

            CommandTreeItemViewModel commandPurchaseDeliveryNotes =
                new CommandTreeItemViewModel("Saatelehed", new RelayCommand(() => { }));
            commandPurchaseDeliveryNotes.IsEnabled = false;
            groupPurchase.CommandTreeItems.Add(commandPurchaseDeliveryNotes);

            //warehouses
            CommandTreeGroupViewModel groupWarehouses = new CommandTreeGroupViewModel("Valmiskaubalaod");
            Commands.Add(groupWarehouses);

            CommandTreeItemViewModel commandWarehouses =
                new CommandTreeItemViewModel("Valmiskaubalaod", new RelayCommand(() => { }));
            commandWarehouses.IsEnabled = false;
            groupWarehouses.CommandTreeItems.Add(commandWarehouses);

            CommandTreeItemViewModel commandDeliveryNotes =
                new CommandTreeItemViewModel("Saatelehed", new RelayCommand(() => { }));
            commandDeliveryNotes.IsEnabled = false;
            groupWarehouses.CommandTreeItems.Add(commandDeliveryNotes);

            //stores
            CommandTreeGroupViewModel groupStores = new CommandTreeGroupViewModel("Poed");
            Commands.Add(groupStores);

            CommandTreeItemViewModel commandStores =
                new CommandTreeItemViewModel("Poed", new RelayCommand(() => { }));
            commandStores.IsEnabled = false;
            groupStores.CommandTreeItems.Add(commandStores);

            CommandTreeItemViewModel commandStoreDeliveryNotes =
                new CommandTreeItemViewModel("Saatelehed", new RelayCommand(() => { }));
            commandStoreDeliveryNotes.IsEnabled = false;
            groupStores.CommandTreeItems.Add(commandStoreDeliveryNotes);

            //commission sale
            CommandTreeGroupViewModel groupCommissionSale = new CommandTreeGroupViewModel("Komisjonimüük");
            Commands.Add(groupCommissionSale);

            CommandTreeItemViewModel commandCommissionWarehouses =
                new CommandTreeItemViewModel("Komisjonilaod", new RelayCommand(() => { }));
            commandCommissionWarehouses.IsEnabled = false;
            groupCommissionSale.CommandTreeItems.Add(commandCommissionWarehouses);

            CommandTreeItemViewModel commandCommissionDeliveryNotes =
                new CommandTreeItemViewModel("Saatelehed", new RelayCommand(() => { }));
            commandCommissionDeliveryNotes.IsEnabled = false;
            groupCommissionSale.CommandTreeItems.Add(commandCommissionDeliveryNotes);

            //permanent data
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);

            CommandTreeItemViewModel commandCompanies =
                new CommandTreeItemViewModel("Firmad", new RelayCommand(() => WorkspaceManager.OpenWorkspace<CompaniesViewModel>()));
            groupPermanentData.CommandTreeItems.Add(commandCompanies);
            CommandTreeItemViewModel commandProducts =
                new CommandTreeItemViewModel("Tooted", new RelayCommand(() => WorkspaceManager.OpenWorkspace<ProductListViewModel>()));
            groupPermanentData.CommandTreeItems.Add(commandProducts);
            CommandTreeItemViewModel commandMaterials =
                new CommandTreeItemViewModel("Materjalid", new RelayCommand(() => WorkspaceManager.OpenWorkspace<MaterialsViewModel>()));
            groupPermanentData.CommandTreeItems.Add(commandMaterials);
        }

        private void UpdateDataTransferDateTime(bool isOnlyClearNeeded = false)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("DataTransferDateTime");
            if (!isOnlyClearNeeded)
            {
                config.AppSettings.Settings.Add("DataTransferDateTime", DateTime.Now.ToString());
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            RaisePropertyChanged(nameof(DataTransferDateTime));
        }
        #endregion
    }
}
