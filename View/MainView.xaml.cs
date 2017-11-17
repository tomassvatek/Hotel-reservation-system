using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {
            AddView childAddView = new AddView();
            childAddView.Owner = this;
            childAddView.ShowDialog();
        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedItem != null)
            {
                UpdateView childUpdateView = new UpdateView();
                childUpdateView.Owner = this;
                childUpdateView.DataContext = viewModel;
                childUpdateView.ShowDialog();
            }
        }
    }
}
