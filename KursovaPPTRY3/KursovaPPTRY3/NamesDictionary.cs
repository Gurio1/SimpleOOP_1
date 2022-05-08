using System.Collections.Generic;



namespace KursovaPPTRY3
{
    partial class Program
    {
        class NamesDictionary
        {
            Dictionary<string, string> names;

            public NamesDictionary()
            {
                names = new Dictionary<string, string>();
                names.Add("Salad", "Салата");
                names.Add("Drinks", "Напитка");
                names.Add("Soup", "Супа");
                names.Add("Dessert", "Десерт");
                names.Add("PrimiryFood", "Основно ястие");
            }

            public string this[string name] => names[name];
        }
    }
}