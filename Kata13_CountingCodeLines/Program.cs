using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    class Program
    {
        static void Main(string[] args)
        {
            LineCounter lineCounter3;
            if (args.Length > 0)
            {
                lineCounter3 = new LineCounter(args.First());
            }
            else
            {
                Console.WriteLine(" adding \" -turbocs\" after the path will aproximately count all C# lines of code");
                Console.WriteLine("Please insert root directory oder so:");
                string userInput = Console.ReadLine();
                if (userInput.Split(' ')[1].Equals("-turbocs"))
                {
                    TurboCounterCSharp turboCounter = new TurboCounterCSharp(userInput.Split(' ')[0]);
                }
                else
                {
                lineCounter3 = new LineCounter(userInput);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Program finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
