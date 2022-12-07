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
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            int? MaxOstat = Entities.GetContext().Material.Max(z => z.Ostat)==null?0: Entities.GetContext().Material.Max(z => z.Ostat);
            var data = Entities.GetContext().Material.Where(x => x.Ostat == MaxOstat).First();
            DataContext = data;
        }
    }
}
