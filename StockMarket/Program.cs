using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //declared up here for convienince
            int stockSelection;
            StockMath math = new StockMath();
            User user = new User();
            int stockOrder;

            //Title Card
            Console.WriteLine("Welcome to uTrade Solutions \n Press any key to begin");
            Console.ReadKey();
            Console.Clear();

            //Adding Stocks to a list, soliciting user input
            Console.WriteLine("What Stocks would you like to trade today \n Enter the name to add them to the list to view, type done when finished.");
            List<string> stockNames = new List<string>(); // declaing a string list to add the names to
            string nameBuffer = "";
            while (5 > 1) // infintie loop
            {
                nameBuffer = Console.ReadLine();
                if (nameBuffer.ToLower() == "done") // checks to see if the user is done entering names before adding the name to the list
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    stockNames.Add(nameBuffer); // adds name to list if not done
                }
                Console.Clear(); // clears ui and reiprints ui writing the list and soliciting input again
                Console.WriteLine("What Stocks would you like to trade today? \n ");
                Console.WriteLine(" \n \n \n List of Stocks Currently Added \n");
                for (int i = 0; i < stockNames.Count; i++)
                {
                    Console.WriteLine(stockNames[i]);
                }
                Console.WriteLine(" \n \n \n \n \n Enter the name to add them to the list to view, type done when finished."); // writes out the names from the list
            } //end input loop


            List<Stock> stockList = new List<Stock>(); // make new list of stock classes
            foreach(string name in stockNames) // make a stock class for each stock name and assign the names to the stocks
            {
                Stock stock = new Stock(name);
                stockList.Add(stock);
            }
            List<Stock> assets = new List<Stock>(); // list of owned stocks
                                                    // game start shows chart of stocks and options
            while (5 > 1)
            {
                Console.Clear();
                StockStatus(stockList, math, user); // show status of all stocks
                Console.WriteLine("You have ${0}.", user.Money);
                Console.WriteLine("\n \n \n");
                Console.WriteLine("You currently have ${0} availible.", user.Money);
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine(" [1] Buy stocks \n [2] Sell stocks \n [3] Read the news \n [4] Go to Next month \n [5] Leave uTrade");
                var keyin = Console.ReadKey();
                switch (keyin.KeyChar)
                {
                    case '1':
                        // BUY STOCKS CASE

                        Console.Clear();
                        StockStatusNum(stockList, math);
                        Console.WriteLine("\n \n Enter the number of the Stock you would like to buy");
                        stockSelection = int.Parse(Console.ReadLine()); stockSelection--;
                        Console.WriteLine(" \n And how many of that stock would you like to buy?");
                        stockOrder = int.Parse(Console.ReadLine());
                        if (stockOrder * stockList[stockSelection].Price > user.Money)
                        {
                            Console.WriteLine("Sorry you dont have the funds in your account \n press any key to continue..........");
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Money -= stockOrder * stockList[stockSelection].Price;
                            stockList[stockSelection].Owned += stockOrder;
                        }

                        break;
                    case '2':
                        // SELL STOCK CASE

                        Console.Clear();
                        StockStatusNum(stockList, math);
                        Console.WriteLine("\n \n Enter the number of the Stock you would like to buy");
                        stockSelection = int.Parse(Console.ReadLine()); stockSelection--;
                        Console.WriteLine("\n How many {0} would you like to sell?", stockList[stockSelection].Name);
                        stockOrder = int.Parse(Console.ReadLine());
                        if (stockOrder > stockList[stockSelection].Owned)
                        {
                            Console.WriteLine("Sorry you dont have that many {0} \n press any key to continue.........", stockList[stockSelection].Name);

                        }
                        else
                        {
                            user.Money += stockOrder * stockList[stockSelection].Price;
                            stockList[stockSelection].Owned -= stockOrder;
                        }
                        break;
                    case '3':
 // News Case
                        Console.Clear();
                        foreach(Stock stocknews in stockList)
                        {
                            Console.WriteLine(stocknews.News);
                        }
                        Console.WriteLine("Press any key to go back to the console.");
                        Console.ReadKey();
                        break;
                    case '4':
                        // Advance month case
                        math.AllMonth(stockList);
                        break;
                    case '5':
                        break;
                }
            }


        }// main end
         static public void StockStatus(List<Stock> stockList, StockMath math, User user) // DISPLAYS STATUS OF ALL STOCKS
        {
            Console.WriteLine("uTrade TM:");
            Console.Write("Name:");
            for (int i = 0; i < math.charCountMax(stockList); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Amt Owned     Price     History      History Two");
            foreach (Stock stockrelay in stockList)
            {

                Console.Write(stockrelay.Name);
                for (int i = 0; i < math.charCountMax(stockList) - stockrelay.Name.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("          " + stockrelay.Owned + "          " + stockrelay.Price + "         " + stockrelay.History + "             " + stockrelay.HistoryTwo);
                Console.WriteLine();
               
            } 

        }// STOCK STATUS
        static public void StockStatusNum(List<Stock> stockList, StockMath math) // DISPLAYS STATUS OF ALL STOCKS, NUMBERS FOR BUYING/SELLING
        {
            int counter = 1;
            Console.WriteLine("uTrade TM:");
            Console.Write("Num: Name:");
            for (int i = 0; i < math.charCountMax(stockList); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Amt Owned     Price     History      History Two");
            foreach (Stock stockrelay in stockList)
            {
                Console.WriteLine();
                Console.Write("[{0}] ", counter); Console.Write(" " + stockrelay.Name);
                
                for (int i = 0; i < math.charCountMax(stockList) - stockrelay.Name.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("          " + stockrelay.Owned + "          " + stockrelay.Price + "         " + stockrelay.History + "             " + stockrelay.HistoryTwo);
                Console.WriteLine();
                counter++;
            }

        }// STOCK STATUS
    }
}
