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

namespace Shuuuuuu
{
    /// <summary>
    /// Interaction logic for Vxod.xaml
    /// </summary>
    public partial class Vxod : Window
    {
        public Vxod()
        {
            InitializeComponent();

            VxodData.ItemsSource = PodgotovkaEgzEntities1.GetContext().Product.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
