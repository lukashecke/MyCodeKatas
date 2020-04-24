using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata06_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlPrefix = TryGetPrefix(args);
            Anagram anagram = new Anagram(urlPrefix);
            anagram.PrintAnagrams();
            Console.ReadKey();
        }
         
        private static string TryGetPrefix(string[] args)
        {
            string urlPrefix = string.Empty;
            if (args.Length > 0 && args[0].Equals("managerStartMode"))
            {
                urlPrefix = AppDomain.CurrentDomain.BaseDirectory.Replace("\\MyCodeKatas\\bin\\Debug\\", "\\Kata04_DataMunging\\bin\\Debug\\");
            }
            return urlPrefix;
        }
    }
}
