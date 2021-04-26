using System.Windows;
using FlatBufChat.ViewModels;

namespace FlatBufChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
        }
    }
}
