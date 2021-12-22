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

namespace Shuuuuuu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }

        private void VxodBtn_Click(object sender, RoutedEventArgs e)
        {
            VadimaMama();
            if(LoginBox.BorderBrush != Brushes.Red && PasswordBox.BorderBrush != Brushes.Red)
            {
                var users = PodgotovkaEgzEntities1.GetContext().User.Where(p => p.Login == LoginBox.Text).Where(p => p.Password == PasswordBox.Password);
                if(users.Count() != 0)
                {
                    Vxod vxod = new Vxod();
                    vxod.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверные данные для входа");
                }
            }     
        }

        private void VadimaMama()
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {
                LoginBox.ToolTip = "Заполните это поле";
                LoginBox.BorderBrush = Brushes.Red;
            }
            else
            {
                LoginBox.ToolTip = null;
                LoginBox.BorderBrush = Brushes.Transparent;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordBox.ToolTip = "Заполните это поле";
                PasswordBox.BorderBrush = Brushes.Red;
            }
            else
            {
                PasswordBox.ToolTip = null;
                PasswordBox.BorderBrush = Brushes.Transparent;
            }
        }
    }
}
