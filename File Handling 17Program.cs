using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling_17
{
    class Program
    {
        static void Main(string[] args)
        {
            string linein;
            double cost;
            double totalcost = 0;
            string[] shop = new string[3];
            string tableformat = "{0,-10}{1,-10}{2,-10}{3,-10:c}";

            OutputEncoding = System.Text.Encoding.UTF8;


            FileStream fs3 = new FileStream("shop.txt", FileMode.Open, FileAccess.Read); //Open Connections
            StreamReader inputStream = new StreamReader(fs3);
            Console.WriteLine(tableformat, "Customer", "Item", "Quantity","Cost");


            linein = inputStream.ReadLine();
            while (linein != null)
            {
                shop = linein.Split(',');
                cost = measure(shop[1],shop[2]);
                totalcost = (totalcost + cost);
                WriteLine(tableformat,shop[0],shop[1],shop[2],cost);
                linein = inputStream.ReadLine();
            }

            WriteLine("\nTotal cost is: {0:c}",totalcost);
            inputStream.Close();
        }
        static double measure(string item, string quantity)
        {
            double cost = 0;
            int num = 0;
            int.TryParse(quantity, out num);

            switch (item)
            {
                case "Shirt":
                    cost = 25;
                    break;
                case "Jumper":
                    cost = 30;
                    break;
                case "Trousers":
                    cost = 35;
                    break;
                default:
                    break;
            }
            cost = (cost * num);

            if(cost> 50)
            {
                cost = cost * 0.90;
            }

            return cost;
        }
    }
}
