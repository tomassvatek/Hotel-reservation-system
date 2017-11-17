using System;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class AvaibleRoomsCommand : ICommand
    {
        public AvaibleRoomsCommand(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }

        public ViewModelBase ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.LoadRooms();
        }
    }
}
