using System;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class CurrentCommand : ICommand
    {
        public CurrentCommand(MainViewModel viewModel)
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
            ViewModel.SetCurrent();
            //ViewModel.SetButtons(true, false, true, true);
        }
    }
}