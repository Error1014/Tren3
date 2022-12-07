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
using System.Windows.Shapes;

namespace Tren3.Windows
{
    /// <summary>
    /// Логика взаимодействия для StorageWindow.xaml
    /// </summary>
    public partial class StorageWindow : Window
    {
        public StorageWindow(int rejime)
        {
            InitializeComponent();
            if (rejime == 1) ShowData();
            else ShowDataStorageDistinct();

        }
        private void ShowData()
        {
            var DataStorage = from x in Entities.GetContext().Storage.ToList()
                              join y in Entities.GetContext().TypeMaterial.ToList() on x.TypeMaterialID equals y.ID
                              select new { addres = x.Address, type = y.Title, distantion = x.DistanceCenter };
            ListViewStorage.ItemsSource = DataStorage;
        }
        private void ShowDataStorageDistinct()
        {
            var DataStorage = from z in Entities.GetContext().Material.ToList()
                              join x in Entities.GetContext().Storage.ToList() on z.StorageID equals x.ID
                              join y in Entities.GetContext().TypeMaterial.ToList() on x.TypeMaterialID equals y.ID
                              select new { addres = x.Address, type = y.Title, distantion = x.DistanceCenter };
            ListViewStorage.ItemsSource = DataStorage.Distinct();
        }
    }
}
