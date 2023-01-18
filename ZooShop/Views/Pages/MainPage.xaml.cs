using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Data.Linq.Mapping;
using ZooShop.Data;
using System.Data.Linq;
using ZooShop.Views.Windows;
using ZooShop.Data.Validators;

namespace ZooShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Product> products;
        public MainPage()
        {
            InitializeComponent();
            if (FilterExpender.IsExpanded)
            {
                FilterColumn.Width = GridLength.Auto;
            }
            Refresh();
        }


        

        private void Refresh()
        {
            products = DbConnection.DB.Product.ToList();
            ProductsListView.ItemsSource = products;
            List<Product> filtredproducts = products;
            if (!String.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                filtredproducts = filtredproducts.Where(x => x.Name.ToUpper().Contains(NameTextBox.Text.ToUpper()) || x.Name.ToUpper().Contains(NameTextBox.Text.ToUpper())).ToList();
            }
            
            if (!String.IsNullOrWhiteSpace(MoreTextBox.Text))
            {
                filtredproducts = filtredproducts.Where(x => x.Price > Convert.ToInt32(MoreTextBox.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(LessTextBox.Text))
            {
                filtredproducts = filtredproducts.Where(x => x.Price < Convert.ToInt32(LessTextBox.Text)).ToList();
            }
            ProductsListView.ItemsSource = filtredproducts;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = ProductsListView.SelectedItem as Product;
                DbConnection.DB.Product.Remove(selected);
                DbConnection.DB.SaveChanges();
                Refresh();
            }
            catch
            {
            }

        }

        private void CartAddBtn_Click(object sender, RoutedEventArgs e)
        {

            var selected = ProductsListView.SelectedItem as Product;
            if (selected.Amount > 0)
            {
                DbConnection.selectedProduct = selected;
                DbConnection.cartListView.Add(selected);
                DbConnection.DB.Product.Attach(DbConnection.selectedProduct);
                //DbConnection.DB.SaveChanges();
                DbConnection.selectedProduct.Amount -= 1;
                //DbConnection.DB.Product.(DbConnection.selectedProduct);
                DbConnection.DB.SaveChanges();
                Refresh();
            }
            else
            {
                MessageBox.Show("товар закончился на складе");
            }
            
        }

        private void AmountAddBtn_Click(object sender, RoutedEventArgs e)
        {

            var selected = ProductsListView.SelectedItem as Product;

            DbConnection.selectedProduct = selected;
            var setAmaountwindow = new SetAmountWindow();
            if (setAmaountwindow.ShowDialog() == true)
            {
                    var validations = new AmountValidator();
                    var product = new Product();
                    product.Amount = Convert.ToInt32(setAmaountwindow.Amount);
                    var res = validations.Validate(product);
                    if (res.Errors.Count > 0)
                    {
                        MessageBox.Show(String.Join("\n", res.Errors));
                    }
                    else
                    {
                        DbConnection.DB.Product.Attach(DbConnection.selectedProduct);
                        //DbConnection.DB.SaveChanges();
                        DbConnection.selectedProduct.Amount += product.Amount;
                        //DbConnection.cartListView.Add(DbConnection.selectedProduct);
                        //DbConnection.DB.Product.Add(DbConnection.selectedProduct);
                        DbConnection.DB.SaveChanges();
                    }
            }
            else
            {
                MessageBox.Show("Данные не заданы");
            }
            Refresh();
        }
    }
}
