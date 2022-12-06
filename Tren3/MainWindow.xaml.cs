using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tren3
{
    public partial class MainWindow : Window
    {
        public static Frame MainWindowFrame = new Frame();
        public MainWindow()
        {
            InitializeComponent();
            MainWindowFrame = MainFrame;
            MainWindowFrame.Content = new Pages.StoragePage();
        }

        private void StorageNavigate(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new Pages.StoragePage();
        }
        private void MaterialNavigate(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new Pages.MaterialPage();
        }
    }
}
