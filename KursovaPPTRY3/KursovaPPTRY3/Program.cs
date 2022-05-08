using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;



namespace KursovaPPTRY3
{
    partial class Program
    {

        delegate void KeyWords(string[] args);
        static Dictionary<string, KeyWords> Commands = new Dictionary<string, KeyWords>();
        static List<Product> Products = new List<Product>();
        static List<Orders> Orders = new List<Orders>();
        static NamesDictionary typeNames = new NamesDictionary();
        static bool Izhod = true;
        static Program()
        {
            var culture = CultureInfo.InvariantCulture;
            Commands.Add("салата", args => Products.Add(new Salad(Convert.ToDecimal(args[3], culture), args[1], int.Parse(args[2]))));
            Commands.Add("супа", args => Products.Add(new Soup(Convert.ToDecimal(args[3], culture), args[1], Convert.ToInt32(args[2]))));
            Commands.Add("десерт", args => Products.Add(new Dessert(Convert.ToDecimal(args[3], culture), args[1], Convert.ToInt32(args[2]))));
            Commands.Add("напитка", args => Products.Add(new Drinks(Convert.ToDecimal(args[3], culture), args[1], Convert.ToInt32(args[2]))));
            Commands.Add("основно ястие", args => Products.Add(new PrimiryFood(Convert.ToDecimal(args[3], culture), args[1], Convert.ToInt32(args[2]))));
            Commands.Add("make_order", args =>
            {
                Product[] orderedProducts = args.Skip(1).Select(a => Products.First(Product => Product.Name.Equals(a))).ToArray();
                Orders.Add(new Orders(Convert.ToInt32(args[0]), orderedProducts));
            });
            Commands.Add("продажби", Stats);
            Commands.Add("изход", Final);


        }
        static void Final(string[] args)
        {
            Stats(args);
            Izhod = false;
        }
        static void Stats(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine($"Общо заети маси през деня:{Orders.Select(order => order.Table).Distinct().Count()}");
            Console.WriteLine($"Общо продажби:{Orders.SelectMany(orders => orders.products).Count()} ------{Orders.Aggregate(0m, (price, order) => price + order.products.Aggregate(0m, (IPrice, product) => IPrice + product.Price))}");
            var types = Orders.SelectMany(orders => orders.products.Select(product => product.GetType()));
            Console.WriteLine("По категории");
            foreach (var type in types.Distinct())
            {
                Console.WriteLine($"   - {typeNames[type.Name]}: {types.Where(t => t == type).Count()}---{Orders.SelectMany(orders => orders.products.Where(product => product.GetType() == type)).Aggregate(0m, (price, item) => price + item.Price)}");
            }
 
           
        }

        static void Main()
        {
            while (Izhod)
            {
                string[] args = Console.ReadLine().ToLower().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0].All(c => char.IsNumber(c)))
                {
                    int TableNumber = int.Parse(args[0]);
                    if (TableNumber > 30 | TableNumber < 0)
                    {
                        Console.WriteLine("The restaurant has 30 tables. No more, no less.");
                    }
                    else
                        Commands["make_order"](args);
                }
                else
                    Commands[args[0]](args);

            }


        }
    }
}