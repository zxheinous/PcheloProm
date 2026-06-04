using System.Windows;
using PcheloProm.ViewModels;

namespace PcheloProm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}