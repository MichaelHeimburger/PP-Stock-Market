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
        public string News { get; set; }
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
            GetNews();
        }
        public void GetNews()
        {
            int diceroll = RandomNumber(1, 4); // three sided dice roll
            if(diceroll == 2) // two in three chance for nothing to happen
            {
                News = null;
            }
            else
            {
                diceroll = RandomNumber(1, 19);
                switch(diceroll)
                {
                    case 1:
                        News =  Name + "'s Chief CEO reports they are restructuring their company by \" temporarily releaseing \" employees across the board........" ;
                        Price = RandomNumber((History  - 12), (History - 2));
                        break;
                    case 2:
                        News ="BOYCOTT "+ Name.ToUpper() + "!. " + Name + "just layed off thousands and replaced them with robots........";
                        Price = RandomNumber((History - 12), (History + 2));
                        break;
                    case 3:
                        News = Name + "Has reported a great quarter and expects big growth ........";
                        Price = RandomNumber((History + 5), (History + 20));
                        break;
                    case 4:
                        News = " After 5 long years " + Name + "'s CEO has been replaced by a promising young individual.....";
                        Price = RandomNumber((History -10), (History +20));
                        break;
                    case 5:
                        News = Name + "'s popularity may have peaked in foreign markets................";
                        Price = RandomNumber((History - 12), (History - 2));
                        break;
                    case 6:
                        News = Name + "Announces new revolutionary new product you wont believe........";
                        Price = RandomNumber((History + 5), (History + 20));
                        break;
                    case 7:
                        News = Name + "'s CEO popularity on the downfall after releasing this tweet........";
                        Price = RandomNumber((History - 15), (History -  5));
                        break;
                    case 8:
                        News = "Analysts predict that " + Name + " will experience extrodinarily large growth this quarter..........";
                        Price = RandomNumber((History - 20), (History +30));
                        break;
                    case 9:
                        News = Name + "reports heavy losses this quarter due to oil shortages...........";
                        Price = RandomNumber((History -  25), (History - 5));
                        break;
                    case 11:
                        News = Name + " is currently buying back stock in an effort to please investors ...........";
                       
                        break;
                    case 12:

                        News = Name + " will be underoging a stock split soon in an effort to increase trading......";
                        Price /= 2;
                        Owned *= 2;
                        break;
                    case 13:
                        News = Name + " is currently researching what? Why you should be worried and happy!....."; // "Fake" news
                        break;
                    case 14:
                        News = "Analysts rejoince as " + Name + " reports is most succsessful quarter of all time";
                        Price = RandomNumber((History + 10), (History +50));
                        break;
                    case 15:
                        News = "Good news for " + Name + " as oil prices rise they continue to profit....";
                        Price = RandomNumber((History + 1), (History + 10));
                        break;
                    case 16:
                        News = "10 reasons why puppies are the greatest......";// "Fake" news
                        break;
                    case 17:
                        News = "10 reasons why kittens are the greatest......";// "Fake" news
                        break;
                    case 18:
                        News = "The president tweeted WHAT?? and other mishaps...";// "Fake" news
                        break;

                }









            }

        }



    }
}
