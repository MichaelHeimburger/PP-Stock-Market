using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class User
    {
        public int Money { get; set; }
        public int MoneyHistory { get; set; }

        public User()
        {
            Money = 10000;
        }

    }
}
