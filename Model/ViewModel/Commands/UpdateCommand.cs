using System;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public class UpdateCommand : ICommand
    {
        public UpdateCommand(MainViewModel viewModel)
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
            ViewModel.UpdateAccommodation();
            ViewModel.CloseWindow(parameter as Window);
        }
    }
}