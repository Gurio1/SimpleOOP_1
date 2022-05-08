using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaPPTRY3
{
    class Dessert : Product, ICalloriable
    {
        public Dessert(decimal price, string name, int weight) : base(price, name, weight)
        {
            
        }
        public  double GetCallories()
        {
            return Weight * 3;
        }
    }
}
