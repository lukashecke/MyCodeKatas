using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlPrefix = TryGetPrefix(args);
            Dictionary dictionary = new Dictionary(urlPrefix);
            Console.WriteLine(dictionary.Words.First());
            Console.ReadKey();
        }

        private static string TryGetPrefix(string[] args)
        {
            string urlPrefix = string.Empty;
            if (args.Length > 0 && args[0].Equals("managerStartMode"))
            {
                urlPrefix = AppDomain.CurrentDomain.BaseDirectory.Replace("\\MyCodeKatas\\bin\\Debug\\", "\\Kata06_Anagrams\\bin\\Debug\\");
            }
            return urlPrefix;
        }
    }
}
