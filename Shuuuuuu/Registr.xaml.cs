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
    /// Interaction logic for Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        //Кнопка регистрации
        private void ReistrBtn_Click(object sender, RoutedEventArgs e)
        {
            if(LoginBox.Text != "")
            {
                if (LoginBox.BorderBrush != Brushes.Red && PasswordBox.BorderBrush != Brushes.Red)
                {
                    if (CheckUser() == false)
                    {
                        AddUser();
                        MessageBox.Show("Регистрация прошла успешно");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Пользователь{LoginBox.Text} уже существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Избавьтесь от ошибок!");
                }
            }
            else
            {
                MessageBox.Show("Избавьтесь от ошибок!");
            }
        }

        private void AddUser()
        {
            using(PodgotovkaEgzEntities1 bd = new PodgotovkaEgzEntities1())
            {
                User user = new User();
                user.Login = LoginBox.Text;
                user.Password = PasswordBox.Password;
                bd.User.Add(user);
                bd.SaveChanges();
            }
        }

        private bool CheckUser()
        {
            bool user = false;

            var search = PodgotovkaEgzEntities1.GetContext().User.Where(p => p.Login == LoginBox.Text).FirstOrDefault();
            if(search != null)
            {
                user = true;
            }
            return user;
        }

        //Праверка на ошибки        
        private void CheckError()
        {
            StringBuilder login = new StringBuilder();
            StringBuilder password = new StringBuilder();
            
            if(LoginBox.Text.Length < 5)
            {
                login.AppendLine("Ваш логин слишком короткий");
            }
            if(PasswordBox.Password.Length < 5)
            {
                password.AppendLine("Ваш пароль слишком короткий");
            }
            if (!PasswordBox.Password.Intersect("!@#$%^&*.").Any())
            {
                password.AppendLine("У вас отсутствует один из перечисленных спец символов (!@#$%^&*.)");
            }
            if (!PasswordBox.Password.Any(char.IsDigit))
            {
                password.AppendLine("У вас в пароле должна быть хотябы одна цифра!");
            }
            if(login.Length > 0)
            {
                LoginBox.ToolTip = login;
                LoginBox.BorderBrush = Brushes.Red;
            }
            else
            {
                LoginBox.ToolTip = null;
                LoginBox.BorderBrush = Brushes.Transparent;
            }
            if(password.Length > 0)
            {
                PasswordBox.ToolTip = password;
                PasswordBox.BorderBrush = Brushes.Red;
            }
            else
            {
                PasswordBox.ToolTip = null;
                PasswordBox.BorderBrush = Brushes.Transparent;
            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckError();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckError();
        }
    }
}
