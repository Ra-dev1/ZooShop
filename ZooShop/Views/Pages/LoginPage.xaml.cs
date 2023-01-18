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
using ZooShop.Data;
using ZooShop.Views.Windows;

namespace ZooShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static LoginWindow lw;
        public LoginPage(LoginWindow loginWindow)
        {
            InitializeComponent();
            lw = loginWindow;
        }

        private void LoginIn()
        {
            string message = "";
            var client = DbConnection.DB.Account.FirstOrDefault(x => x.Login == LoginTextBox.Text && x.Password == PasswordPasswordBox.Password);
            if (client != null)
            {
                DbConnection.account = client;
                DbConnection.accountROle = DbConnection.DB.Account.FirstOrDefault(x => x.Login == LoginTextBox.Text && x.Password == PasswordPasswordBox.Password).Role;
                new MainWindow().Show();
                lw.Close();
            }
            else if (String.IsNullOrEmpty(LoginTextBox.Text) || String.IsNullOrEmpty(PasswordPasswordBox.Password))
            {
                if (String.IsNullOrEmpty(LoginTextBox.Text))
                    message += "Введите Логин";
                if (String.IsNullOrEmpty(PasswordPasswordBox.Password))
                    message += "\nВведите Пароль";
                MessageBox.Show(message);
            }
            else
                MessageBox.Show("Не правельный логин или пароль");

        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginIn();
        }
    }
}
