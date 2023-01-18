using Microsoft.Win32;
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
using ZooShop.Data.Validators;

namespace ZooShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        Product product = new Product();
        public AddProductPage()
        {
            InitializeComponent();
            this.DataContext = product;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            var validations = new ProductValidator();
            var res = validations.Validate(product);
            if (res.Errors.Count > 0)
            {
                MessageBox.Show(String.Join("\n", res.Errors));
            }
            else
            {
                DbConnection.DB.Product.Add(product);
                DbConnection.DB.SaveChanges();
                NavigationService.RemoveBackEntry();
                NavigationService.Navigate(new MainPage());
                NavigationService.RemoveBackEntry();
            }

        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                LoadedImage.Source = new BitmapImage(new Uri(op.FileName));
            }
            product.Image = System.IO.File.ReadAllBytes(op.FileName);
        }
    }
}
