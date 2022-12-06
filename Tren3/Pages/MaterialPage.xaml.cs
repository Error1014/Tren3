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
    /// Логика взаимодействия для MaterialPage.xaml
    /// </summary>
    public partial class MaterialPage : Page
    {
        private Material SelectedMaterial;
        private bool isAdd = false;
        public MaterialPage()
        {
            InitializeComponent();
            UpdateListView();
            EdIzmerCB.SelectedValuePath = "ID";
            EdIzmerCB.DisplayMemberPath = "Title";
            EdIzmerCB.ItemsSource = Entities.GetContext().EdIzmer.ToList();
        }
        private void ReadData()
        {
            SelectedMaterial.Number = NumberTB.Text;
            SelectedMaterial.Title = TitleTB.Text;
            SelectedMaterial.EdIzmerID = EdIzmerCB.SelectedIndex + 1;
            SelectedMaterial.Ostat = int.Parse(OstatTB.Text);
            //SelectedMaterial.StorageID = 0;
        }

        private void UpdateListView()
        {
            var data = Entities.GetContext().Material.ToList();
            ListViewMaterial.ItemsSource = data;
        }

        private void DeleteStorage(object sender, RoutedEventArgs e)
        {

        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            ReadData();
            if (isAdd)
            {
                Entities.GetContext().Material.Add(SelectedMaterial);
            }
            Entities.GetContext().SaveChanges();
            UpdateListView();
            ClearEditBlock();

        }
        private void ClearEditBlock()
        {
            NumberTB.Text = "";
            TitleTB.Text = "";
            EdIzmerCB.SelectedIndex = 0;
            OstatTB.Text = "";
            //Storage
        }

        private void AddOderEditRejime(object sender, RoutedEventArgs e)
        {
            isAdd = !isAdd;
            if (isAdd)
            {
                SelectedMaterial = null;
                TitleModul.Text = "Модуль создания";
                (sender as Button).Content = "Редактировать материал";
            }
            else
            {
                TitleModul.Text = "Модуль редактирования";
                (sender as Button).Content = "Добавить новый материал";
            }
            ClearEditBlock();
        }
        private void TextInputNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SelectMaterial(object sender, MouseButtonEventArgs e)
        {
            SelectedMaterial = (sender as Grid).DataContext as Material;
            NumberTB.Text = SelectedMaterial.Number.ToString();
            TitleTB.Text = SelectedMaterial.Title.ToString();
            EdIzmerCB.SelectedIndex = (int)(SelectedMaterial.EdIzmerID) == null ? 0 : (int)(SelectedMaterial.EdIzmerID - 1);
            OstatTB.Text = SelectedMaterial.Ostat.ToString();
            StorageIDTB.Text = SelectedMaterial.StorageID.ToString();
        }
        
    }
}
