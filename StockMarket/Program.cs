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
            MathLogic math = new MathLogic();

            //Title Card
            Console.WriteLine("Welcome to uTrade Solutions \n press enter to begin");
            Console.ReadLine();
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


            int counter = 1;
            List<Stock> stockList = new List<Stock>(); // make new list of stock classes
            foreach(string name in stockNames) // make a stock class for each stock name and assign the names to the stocks
            {
                Stock stock = new Stock(name);
                stockList.Add(stock);
            }
// game start shows chart of stocks
            Console.WriteLine("Current prices for each stock are as follows:");
            Console.Write("Name:");
            for (int i = 0; i < math.charCountMax(stockList); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Price     History      History Two");
            foreach (Stock stockrelay in stockList)
            {

                Console.Write(stockrelay.Name);
                for(int i=0; i < math.charCountMax(stockList) - stockrelay.Name.Length;i++)
                {
                    Console.Write(" ");
                }
                Console.Write("     " + stockrelay.Price + "          " + stockrelay.History + "           " +  stockrelay.HistoryTwo);
                Console.WriteLine();
            }
            Console.ReadLine();




        }// main
    }
}
