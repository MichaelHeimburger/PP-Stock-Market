using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Stock
    {
        public int Price { get; set; }
        public int Owned { get; set; }
        public int History { get; set; }
        public int HistoryTwo { get; set; }
        public string Name { get; set; }
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public Stock(string stockname)
        {
            Random randomprice = new Random();
            Name = stockname;
            Price = RandomNumber(10, 100);
            Month();
            Month();
            Month();
            Month();
        }
        public void Month() // like a tick method advances the prices after each month
        {
            HistoryTwo = History;
            History = Price;
            Price = RandomNumber((History-10), (History + 10));
        }



    }
}
