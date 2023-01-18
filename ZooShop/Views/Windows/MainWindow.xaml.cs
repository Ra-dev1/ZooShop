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
using ZooShop.Views.Pages;

namespace ZooShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = DbConnection.account;
            Refresh();
            MainFrame.Navigate(new MainPage());
            RoleLabel.Content = DbConnection.accountROle.Name;
            if (DbConnection.account.Role_id != 1)
            {
                HotelsBtn.Visibility = Visibility.Hidden;
            }
        }

        private void Refresh()
        {
            if (MainFrame.CanGoBack)
                BackBtn.Visibility = Visibility.Visible;
            else
                BackBtn.Visibility = Visibility.Hidden;
            if (MainFrame.CanGoForward)
                ForwardBtn.Visibility = Visibility.Visible;
            else
                ForwardBtn.Visibility = Visibility.Hidden;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
            Refresh();
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoForward();
            Refresh();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void HotelsBtn_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new AddUserPage());
            Refresh();
        }

        private void ReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddProductPage());
            Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CartPage());
            Refresh();
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage()) ;
            Refresh();
        }

        private void AccoutingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountingPage());
            Refresh();
        }
    }
}
