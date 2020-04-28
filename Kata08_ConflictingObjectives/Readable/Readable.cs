using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives.Readable
{
    static class Readable
    {
        internal static Dictionary Dictionary { get; set; }
        static List<string> WordsWithSixLetters { get; set; }
        public static void Start()
        {
            ShowTheStartUpText();
            CreateTheDictionary();
            GetAllTheSixLetteredWordsFromTheDictionary();
            ShowMeTheWordsIAmSearchingFor();
        }

        private static void ShowMeTheWordsIAmSearchingFor()
        {
            Searcher searcher = new Searcher(WordsWithSixLetters);
            List<string> outputLines = searcher.GetMeTheWordsIAmLookingFor();
            foreach (string line in outputLines)
            {
                Console.WriteLine(line);
            }
        }

        private static void GetAllTheSixLetteredWordsFromTheDictionary()
        {
            WordsWithSixLetters = Dictionary.GetSixLetteredWords();
        }

        private static void CreateTheDictionary()
        {
            Dictionary = new Dictionary();
        }

        private static void ShowTheStartUpText()
        {
            Console.WriteLine("Readable Program running...");
        }
    }
}
