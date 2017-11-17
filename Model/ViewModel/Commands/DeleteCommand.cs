using System;
using System.Windows.Input;

namespace ViewModel
{
    public class DeleteCommand : ICommand
    {
        public DeleteCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public MainViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.DeleteAccommodation();
        }
    }
}