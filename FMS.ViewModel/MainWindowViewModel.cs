﻿using FMS.ViewModel.Commands;
using FMS.ViewModel.Factories;
using FMS.ViewModel.Utils;
using FMS.WPF.Application.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FMS.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private IDataTransferService _dataTransferService;
        #endregion Fields

        #region Constructors
        public MainWindowViewModel(IWorkspaceManager workspaceManager, IDataTransferService dataTransferService)
        {
            WorkspaceManager = workspaceManager;
            _dataTransferService = dataTransferService;
            CreateCommands();
        }
        #endregion Constructors

        #region Properties
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();

        public IWorkspaceManager WorkspaceManager { get; }

        public ObservableCollection<WorkspaceViewModelBase> Workspaces => WorkspaceManager.Workspaces;
        #endregion Properties

        #region Commands
        private ICommand _transferDataCommand;
        public ICommand TransferDataCommand => _transferDataCommand ?? (_transferDataCommand = new DelegateCommand(p => TransferData()));
        private void TransferData()
        {
            _dataTransferService.TransferData();
        }
        #endregion Commands

        #region Helpers
        private void CreateCommands()
        {
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);

            CommandTreeItemViewModel commandCompanies = 
                new CommandTreeItemViewModel("Firmad", new DelegateCommand(p => WorkspaceManager.OpenWorkspace<ICompaniesWorkspaceFactory>("Firmad")));
            groupPermanentData.CommandTreeItems.Add(commandCompanies);
        }
        #endregion Helpers
    }
}
