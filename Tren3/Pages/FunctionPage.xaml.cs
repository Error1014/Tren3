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
using Tren3.Windows;

namespace Tren3.Pages
{
    /// <summary>
    /// Логика взаимодействия для FunctionPage.xaml
    /// </summary>
    public partial class FunctionPage : Page
    {
        public FunctionPage()
        {
            InitializeComponent();
        }
        private void Save()
        {
            Entities.GetContext().SaveChanges();
        }

        private void OstatMinus10Procent(object sender, RoutedEventArgs e)
        {
            var ListMaterial = Entities.GetContext().Material.ToList();
            foreach (var item in ListMaterial)
            {
                item.Ostat = item.Ostat-item.Ostat/10;
            }
            Save();
            MessageBox.Show("Вы успешно уменьшили остаток на 10%");
        }

        private void ShowWindowDataStorage(object sender, RoutedEventArgs e)
        {
            StorageWindow storageWindow = new StorageWindow(1);
            storageWindow.Show();
        }

        private void ShowMaterialInKomarovo(object sender, RoutedEventArgs e)
        {
            MaterialWindow materialInKomarowoWindow = new MaterialWindow(1);
            materialInKomarowoWindow.Show();
        }

        private void ShowMaterialReverce(object sender, RoutedEventArgs e)
        {
            MaterialWindow materialInKomarowoWindow = new MaterialWindow(2);
            materialInKomarowoWindow.Show();
        }

        private void ShowStorageDistinct(object sender, RoutedEventArgs e)
        {
            StorageWindow storageWindow = new StorageWindow(2);
            storageWindow.Show();
        }
    }
}
