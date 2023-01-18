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

namespace ZooShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = DbConnection.cartListView;
            Refresh();
        }

        long? total = 0;
        private void Refresh() 
        {
            var product = DbConnection.cartListView.ToList();
            ProductsListView.ItemsSource = product;
            DbConnection.cartListView.ForEach(x => total += x.Price);
            TotalPriceTB.Content = total;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                    var selected = ProductsListView.SelectedItem as Product;
                    DbConnection.cartListView.Remove(selected);
                    Refresh();
                }
                catch
                {
                }
            
        }

        private void ConfirmBt_Click(object sender, RoutedEventArgs e)
        {

            var accounting = new Accounting();
            foreach (var item in DbConnection.cartListView)
            {
                accounting.id_worker = DbConnection.DB.Worker.Where(x => x.id == DbConnection.account.Worker_id).FirstOrDefault().id;
                accounting.Id_Product = item.Id;
                accounting.Amount = (long)item.Amount;
                accounting.Total_price = (long)item.Price;
                accounting.date = DateTime.Now;
                DbConnection.DB.Accounting.Add(accounting);
                DbConnection.DB.SaveChanges();
            }
            DbConnection.cartListView = new List<Product>();
            Refresh();
        }
    }
}
