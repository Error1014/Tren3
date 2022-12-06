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

namespace Tren3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditStoragePage.xaml
    /// </summary>
    public partial class AddEditStoragePage : Page
    {
        private Storage MyStorage = new Storage();
        private bool isAdd = true;
        public AddEditStoragePage(Storage SelectStorage)
        {
            InitializeComponent();
            if (SelectStorage != null) isAdd = false;

        }
    }
}
