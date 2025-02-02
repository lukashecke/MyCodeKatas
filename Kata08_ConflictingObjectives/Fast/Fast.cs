﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives.Fast
{
    static class Fast
    {
        static Stopwatch stopwatch = new Stopwatch();
        public static void Start()
        {
            stopwatch.Start();
            Console.WriteLine("Fast Program running...");
            HashSet<string> wordsIAmLookingFor = new HashSet<string>();
            string[] relevantWords = File.ReadAllLines(Program.UrlPrefix + "wordlist.txt").Where(s => s.Length < 7).ToArray(); // Einzigr Dateizugriff
            string[] subWords = new string[26423];
            string[] sixLetteredWords = new string[28337];
            Parallel.Invoke(
                ()=>sixLetteredWords = relevantWords.Where(word => word.Length == 6).ToArray(),
                () => subWords = relevantWords.Where(s => s.Length < 6).ToArray()
            );
            

            string[][] groupedSubWords = { 
                subWords.Where(s => s.Length ==1).ToArray(),
                subWords.Where(s => s.Length == 2).ToArray(),
                subWords.Where(s => s.Length == 3).ToArray(),
                subWords.Where(s => s.Length == 4).ToArray(),
                subWords.Where(s => s.Length ==5).ToArray()};
            object monitor = new object();
            Parallel.ForEach(sixLetteredWords, (word) =>
            {
                for (int i = 1; i < 6; i++)
                {
                    if (groupedSubWords[i - 1].Contains(word.Substring(0, i)))
                    {
                        if (groupedSubWords[5 - i].Contains(word.Substring(i, word.Length - i)))
                        {
                            lock (monitor)
                            {
                                wordsIAmLookingFor.Add(string.Format($"{word.Substring(0, i)} + {word.Substring(i, word.Length - i)} => {word}"));
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
