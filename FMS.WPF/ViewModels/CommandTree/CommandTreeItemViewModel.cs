using System;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CommandTreeItemViewModel : CommandTreeNodeViewModelBase
    {
        public ICommand Command { get; private set; }

        public CommandTreeItemViewModel(string displayName, ICommand command)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            base.DisplayName = displayName;
        }
    }
}
