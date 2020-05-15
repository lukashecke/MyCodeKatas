using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives.Extendible
{
    static class Extendible // TODO: Factorypattern umsetzen und interfaces
    {
           static  Stopwatch stopwatch = new Stopwatch();
        public static void Start()
        {
            stopwatch.Start();
            Console.WriteLine("Extendible Program running...");
            SearchForComposedWords(Program.UrlPrefix + "wordlist.txt", 6, OutputMode.Regular);
        }
        private static void SearchForComposedWords(string filePath, int wordLength, OutputMode outputMode)
        {
            // Initializing needed Lists/ Arrays ,etc.
            HashSet<string> wordsIAmLookingFor = new HashSet<string>();
            string[] targetWords = File.ReadAllLines(filePath).Where(word => word.Length == wordLength).ToArray();
            string[] subWords = File.ReadAllLines(Program.UrlPrefix + "wordlist.txt").Where(s => s.Length < wordLength).ToArray();
            List<string[]> temp = new List<string[]>();
            for (int i = 1; i < wordLength; i++)
            {
                temp.Add(subWords.Where(s => s.Length == i).ToArray());
            }
            string[][] groupedSubWords = temp.ToArray();

            // Parallel searching
            object monitor = new object();
            Parallel.ForEach(targetWords, (word) =>
            {
                for (int i = 1; i < wordLength; i++)
                {
                    if (groupedSubWords[i - 1].Contains(word.Substring(0, i)))
                    {
                        if (groupedSubWords[(wordLength-1) - i].Contains(word.Substring(i, word.Length - i)))
                        {
                            switch (outputMode)
                            {
                                case OutputMode.Regular:
                                    lock (monitor)
                                    {
                                        wordsIAmLookingFor.Add(string.Format($"{word.Substring(0, i)} + {word.Substring(i, word.Length - i)} => {word}"));
                                    }
                                    break;
                                case OutputMode.Reversed:
                                    lock (monitor)
                                    {
                                        wordsIAmLookingFor.Add(string.Format($"{word} => {word.Substring(0, i)} + {word.Substring(i, word.Length - i)}"));
                                    }
                                    break;
                                case OutputMode.InWords:
                                    lock (monitor)
                                    {
                                        wordsIAmLookingFor.Add(string.Format($"The word \"{word}\" is composed from \"{word.Substring(0, i)}\" and \"{word.Substring(i, word.Length - i)}\""));
                                    }
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                    }
                }
            });
            stopwatch.Stop();
            Console.WriteLine(wordsIAmLookingFor.Count + " combinations found in " + stopwatch.Elapsed.TotalSeconds + " s.");
        }
    }
}
