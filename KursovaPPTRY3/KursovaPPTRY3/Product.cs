using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaPPTRY3
{
    class Product
    {
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public Product(decimal price, string name, int weight)
        {
            this.Price = price;
            this.Name = name;
            this.Weight = weight;
        }
    }
}
