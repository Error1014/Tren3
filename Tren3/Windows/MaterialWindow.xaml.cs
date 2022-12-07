﻿using System;
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
    /// Логика взаимодействия для MaterialInKomarowoWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        public MaterialWindow(int rejime)
        {
            InitializeComponent();
            if (rejime==1)
            {
                ShowDataMaterialInKomarowo();
                this.Title = "Материалы в Комарово";
            }
            else if (rejime==2)
            {
                ShowDataMaterialReverce();
                this.Title = "Материалы в обратном порядке";
            }
            else if (rejime==3)
            {
                ShowDataMaterial12km();
                this.Title = "Материалы в складах на расстоянии не менее 12 км";
            }
        }
        private void ShowDataMaterialInKomarowo()
        {
            var DataMaterial = from x in Entities.GetContext().Storage.ToList()
                               join y in Entities.GetContext().Material.ToList() on x.ID equals y.StorageID
                               join z in Entities.GetContext().EdIzmer.ToList() on y.EdIzmerID equals z.ID
                               where x.Address== "д.Комарово"
                               select y;
            ListViewMaterial.ItemsSource = DataMaterial;
        }
        private void ShowDataMaterialReverce()
        {
            var DataMaterial = from x in Entities.GetContext().Storage.ToList()
                               join y in Entities.GetContext().Material.ToList() on x.ID equals y.StorageID
                               join z in Entities.GetContext().EdIzmer.ToList() on y.EdIzmerID equals z.ID
                               select y;
            DataMaterial = DataMaterial.OrderBy(x=>-x.ID);
            ListViewMaterial.ItemsSource = DataMaterial;
        }
        private void ShowDataMaterial12km()
        {
            var DataMaterial = from x in Entities.GetContext().Storage.ToList()
                               join y in Entities.GetContext().Material.ToList() on x.ID equals y.StorageID
                               join z in Entities.GetContext().EdIzmer.ToList() on y.EdIzmerID equals z.ID
                               where x.DistanceCenter >= 12
                               select y;
            ListViewMaterial.ItemsSource = DataMaterial;
        }
    }
}
