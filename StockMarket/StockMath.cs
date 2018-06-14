using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class StockMath
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        public StockMath()
        {

        }
        public int charCountMax(List<Stock> stocklist)
        {
            int num = 1;
            int relay;
            foreach(Stock stock in stocklist)
            {    
                relay = stock.Name.Length;
                if (num < relay)
                {
                    num = relay;
                }
            }          
            return num;
        }

        public void AllMonth(List<Stock> stocklist)
        {
            foreach(Stock stock in stocklist)
            {
                stock.Month();
            }
        }

    }
}
