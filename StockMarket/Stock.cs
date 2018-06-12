using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Stock
    {
        private int price;
        private int history;
        private int historyTwo;
        private string name;
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public int Price
        { get { return this.price; } set { this.price = value; } }
        public int History
        { get { return this.history; } set { this.history = value; } }
        public int HistoryTwo
        { get { return this.historyTwo; } set { this.historyTwo = value; } }
        public string Name
        { get { return this.name; } set { this.name = value; } }

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
        public void Month() // like a tick method advances the prices after each transaction
        {
            HistoryTwo = History;
            History = Price;
            Price = RandomNumber(10, 100);
        }



    }
}
