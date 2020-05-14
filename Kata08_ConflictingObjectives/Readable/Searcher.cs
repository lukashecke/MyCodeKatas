using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives.Readable
{
    class Searcher
    {
        private List<string> Words { get; set; }
        private List<List<string>> PossiblePreAndPostFixes { get; set; }

        public Searcher(List<string> words)
        {
            // TODO: Lesbarkeit verbessern
            Words = words;
             var temp = new Dictionary().Words.GroupBy(w => w.Length);

            PossiblePreAndPostFixes = new List<List<string>>();
            PossiblePreAndPostFixes.Add(temp.Where(l => l.Key==1).First().ToList());
            PossiblePreAndPostFixes.Add(temp.Where(l => l.Key == 2).First().ToList());
            PossiblePreAndPostFixes.Add(temp.Where(l => l.Key == 3).First().ToList());
            PossiblePreAndPostFixes.Add(temp.Where(l => l.Key == 4).First().ToList());
            PossiblePreAndPostFixes.Add(temp.Where(l => l.Key == 5).First().ToList());
        }

        

        internal List<string> GetMeTheWordsIAmLookingFor()
        {
            List<string> wordsIAmLookingFor = new List<string>();
            foreach (string word in Words)
            { // TODO: Refactoring in einzelne Methoden
                string wordComposition = string.Empty;
                List<List<string>> wordSplits = new List<List<string>>();
                for (int i = 1; i < 6; i++)
                {
                    List<string> wordSplit = new List<string>();
                    wordSplit.Add(word.Substring(0, i));
                    wordSplit.Add(word.Substring(i, word.Length - i));
                    wordSplits.Add(wordSplit);
                }
                foreach (List<string> wordSplit in wordSplits)
                {
                    if (PossiblePreAndPostFixes[wordSplit[0].Length-1].Contains(wordSplit[0]) && PossiblePreAndPostFixes[wordSplit[1].Length-1].Contains(wordSplit[1]))
                    {
                        wordComposition = string.Format($"{wordSplit[0]} + {wordSplit[1]} => {word}");
                        wordsIAmLookingFor.Add(wordComposition);
                    }
                }
            }
            return wordsIAmLookingFor;
        }
    }
}
