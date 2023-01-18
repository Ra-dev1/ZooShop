using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Data
{
    public static class DbConnection
    {
        public static ZooShopEntities DB = new ZooShopEntities();
        public static Account account;
        public static Role accountROle;
        public static int amountChange;
        public static Product selectedProduct;
        public static List<Product> cartListView = new List<Product>();
    }
}
