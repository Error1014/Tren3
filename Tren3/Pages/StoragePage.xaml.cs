using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tren3.Pages
{
    /// <summary>
    /// Логика взаимодействия для StoragePage.xaml
    /// </summary>
   
    public partial class StoragePage : Page
    {
        private Storage SelectedStorage = null;
        private bool isAdd = false;
        public StoragePage()
        {
            InitializeComponent();
            TitleModul.Text = "Модуль редактирования";
            UpdateListView();
        }


        private void SelectStorage(object sender, MouseButtonEventArgs e)
        {
            SelectedStorage = (sender as Grid).DataContext as Storage;
            NumberTB.Text = SelectedStorage.Number.ToString();
            AddressTB.Text = SelectedStorage.Address.ToString();
            TypeCB.SelectedIndex = (int)SelectedStorage.TypeMaterialID - 1;
            DistanceTB.Text = SelectedStorage.DistanceCenter.ToString();
        }
        private void ReadData()
        {
            SelectedStorage= new Storage();
            SelectedStorage.Number = NumberTB.Text;
            SelectedStorage.Address = AddressTB.Text;
            SelectedStorage.TypeMaterialID = TypeCB.SelectedIndex + 1;
            SelectedStorage.DistanceCenter = Convert.ToDouble(DistanceTB.Text);
        }
        private void ClearEditBlock()
        {
            NumberTB.Text = "";
            AddressTB.Text = "";
            TypeCB.SelectedIndex = 0;
            DistanceTB.Text = "";
        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            ReadData();
            if (isAdd)
            {
                Entities.GetContext().Storage.Add(SelectedStorage);
            }
            Entities.GetContext().SaveChanges();
            UpdateListView();
            ClearEditBlock();
        }

        private void DeleteStorage(object sender, RoutedEventArgs e)
        {
            if (SelectedStorage!=null)
            {
                Entities.GetContext().Storage.Remove(SelectedStorage);
               
            }
            Entities.GetContext().SaveChanges();
            UpdateListView();
        }

        /// <summary>
        /// Редим создания или редактирования 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOderEditRejime(object sender, RoutedEventArgs e)
        {
            
            isAdd = !isAdd;
            if (isAdd)
            {
                SelectedStorage = null;
                TitleModul.Text="Модуль создания";
                (sender as Button).Content = "Редактировать склад";
            }
            else
            {
                TitleModul.Text = "Модуль редактирования";
                (sender as Button).Content = "Добавить новый склад";
            }
            ClearEditBlock();

        }

        /// <summary>
        /// обновляет данные в ListView
        /// </summary>
        private void UpdateListView()
        {
            var data = Entities.GetContext().Storage.ToList();
            ListViewStorage.ItemsSource = data;
            TypeCB.SelectedValuePath = "ID";
            TypeCB.DisplayMemberPath = "Title";
            TypeCB.ItemsSource = Entities.GetContext().TypeMaterial.ToList();
        }

        private void TextInputNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
