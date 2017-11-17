using System;
using System.Windows;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class SaveCommand : ICommand
    {
        public SaveCommand(AddViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public AddViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SaveAccommodation();
            ViewModel.CloseWindow(parameter as Window);
        }
    }
}