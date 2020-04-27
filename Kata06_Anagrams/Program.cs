using System;

namespace Kata06_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlPrefix = TryGetPrefix(args);
            Anagram anagram = new Anagram(urlPrefix);
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
