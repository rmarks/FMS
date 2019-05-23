using FMS.ViewModels;
using System;
using System.Collections.Generic;

namespace FMS.ViewModels
{
    public class MainWindowViewModel
    {
        public List<CommandTreeNodeViewModelBase> Commands { get; } = new List<CommandTreeNodeViewModelBase>();

        public MainWindowViewModel()
        {
            CreateCommands();
        }

        #region Helpers
        private void CreateCommands()
        {
            CommandTreeGroupViewModel groupPermanentData = new CommandTreeGroupViewModel("Püsiandmed");
            Commands.Add(groupPermanentData);
        }
        #endregion Helpers
    }
}
