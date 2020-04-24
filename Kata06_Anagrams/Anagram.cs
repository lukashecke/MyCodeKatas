using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata06_Anagrams
{
    class Anagram
    {
        string[] Anagrams { get; set; }
        public Anagram(string urlPrefix)
        {
            string[] wordList = File.ReadAllLines(urlPrefix + "wordlist.txt");
            FillAnagrams(wordList);
        }

        private void FillAnagrams(string[] wordList)
        {
            Anagrams = new string[wordList.Length];
            int firstFreeIndex = 0;
            foreach (string word in wordList)
            {
                for (int i = 0; i < Anagrams.Length; i++)
                {
                    if (word.Length == Anagrams[i]?.Split(' ')[0].Length) // pre-filtering for better runtime
                    {
                        char[] arr = word.ToCharArray();
                        Array.Sort(arr);
                        char[] arr2 = Anagrams[i].ToCharArray();
                        Array.Sort(arr2);
                        if (arr.Equals(arr2))
                        {
                            Anagrams[i] += " " + word;
                            break;
                        }
                    }
                }
                Anagrams[firstFreeIndex++] = word; // new Anagram line
            }
        }

        internal void PrintAnagrams()
        {
            foreach (string anagramLine in Anagrams)
            {
                Console.WriteLine(anagramLine);
            }
        }
    }
}
