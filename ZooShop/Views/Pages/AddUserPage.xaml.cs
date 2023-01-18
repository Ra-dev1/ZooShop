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
using ZooShop.Data.Validators;
using ZooShop.Data;

namespace ZooShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        Worker worker = new Worker();
        Account account = new Account();
        public AddUserPage()
        {
            InitializeComponent();
            this.DataContext = worker;
            RoleCB.ItemsSource = DbConnection.DB.Role.ToList();
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            var validations = new AccountValidator();
            var workervalidations = new WorkerValidator();
            var selectedRole = RoleCB.SelectedItem as Role;
            account.Login = LoginTB.Text;
            account.Password = PasswordTB.Text;
            account.Role_id = selectedRole.id;
            var res = validations.Validate(account);
            var workerres = workervalidations.Validate(worker);
            if (res.Errors.Count > 0 || workerres.Errors.Count > 0)
            {
                MessageBox.Show(String.Join("\n", res.Errors) + "\n" +String.Join("\n", workerres.Errors));
            }
            else
            {
                DbConnection.DB.Worker.Add(worker);
                DbConnection.DB.SaveChanges();
                account.Worker_id = DbConnection.DB.Worker.Where(x => x.LastName == worker.LastName && x.FirstName == worker.FirstName && x.Patranomyc == worker.Patranomyc).FirstOrDefault().id;

                DbConnection.DB.Account.Add(account);
                DbConnection.DB.SaveChanges();
                NavigationService.RemoveBackEntry();
                NavigationService.Navigate(new MainPage());
                NavigationService.RemoveBackEntry();
            }
        }
    }
}
