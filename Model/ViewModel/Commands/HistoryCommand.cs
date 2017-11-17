using System;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class HistoryCommand : ICommand
    {
        public HistoryCommand(MainViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public MainViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SetHistory();
        }
    }
}