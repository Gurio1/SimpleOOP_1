﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaPPTRY3
{
    class PrimiryFood : Product, ICalloriable
    {
       
        public PrimiryFood(decimal price, string name, int weight) : base(price, name, weight)
        {
            
        }
        public  double GetCallories()
        {
            return Weight;
        }
    }
}
