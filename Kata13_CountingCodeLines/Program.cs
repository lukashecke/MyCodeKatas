using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    class Program
    {
        static void Main(string[] args)
        {
            LineCounter lineCounter;
            if (args.Length > 0)
            {
                lineCounter = new LineCounter(args.First());
            }
            else
            {
                Console.WriteLine("Please insert root directory oder so:");
                string userInput = Console.ReadLine();
                lineCounter = new LineCounter(userInput);
            }
            Console.WriteLine();
            Console.WriteLine("Program finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
