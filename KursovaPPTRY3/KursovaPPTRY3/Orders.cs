using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaPPTRY3
{
    class Orders
    {
        public int Table { get; private set; }
        public Product[] products { get; private set; }
        public Orders(int table,Product[] products)
        {
            Table = table;
            this.products = products;
        }
    }
}
