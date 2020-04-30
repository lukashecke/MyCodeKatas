using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata06_Anagrams
{
    class Anagram
    {
        List<string> Anagrams { get; set; }
        public Anagram(string urlPrefix)
        {
            Anagrams = new List<string>();
            string[] wordList = File.ReadAllLines(urlPrefix + "wordlist.txt");
            List<List<string>> groupedWords = GroupByCharOccurence(wordList);
            List<List<string>> anagramsList = FilterAnagrams(groupedWords);
            Anagrams = JoinAnagramsToLines(anagramsList);
            string longestAnagram = GetLongestAnagram(anagramsList);
            Console.WriteLine("Longest Anagram:");
            Console.WriteLine(longestAnagram);
            string biggestAnagramSet = GetBiggestAnagramSet(anagramsList);
            Console.WriteLine("Biggest Anagram Set:");
            Console.WriteLine(biggestAnagramSet);
            Console.ReadKey();
        }

        private string GetBiggestAnagramSet(List<List<string>> anagramsList)
        {
            List<string> biggestAnagramSet = new List<string>() { "" };
            foreach (List<string> anagrams in anagramsList)
            {
                if (anagrams.Count>biggestAnagramSet.Count)
                {
                    biggestAnagramSet = anagrams;
                }
            }
            return String.Join(", ", biggestAnagramSet.ToArray()); // List<string> names --> string names_together = "John, Anna, Monica"
        }

        private string GetLongestAnagram(List<List<string>> anagramsList)
        {
            List<string> longestAnagrams = new List<string>() { "" };
            foreach (List<string> anagrams in anagramsList)
            {
                if (anagrams.First().Length > longestAnagrams.First().Length)
                {
                    longestAnagrams = anagrams;
                }
            }
            return String.Join(", ", longestAnagrams.ToArray()); // List<string> names --> string names_together = "John, Anna, Monica"
        }

        private List<string> JoinAnagramsToLines(List<List<string>> anagramList)
        {
            return anagramList.Select(x => string.Join(" ", x)).ToList();
        }
        private List<List<string>> FilterAnagrams(List<List<string>> groupedWords)
        {
            return groupedWords.Where(g => g.Count() > 1).ToList();
        }
        /// <summary>
        /// * THE MAGIC HAPPENS HERE *
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private List<List<string>> GroupByCharOccurence(string[] wordList)
        {
            var temp = wordList.GroupBy(w => new string(w.OrderBy(c => c).ToArray()));
            List<List<string>> list = new List<List<string>>();
            foreach (var item in temp)
            {
                list.Add(item.ToList());
            }
            return list;
        }

        /// <summary>
        /// AnagramalistParallelLinq-attempt by Filip Kucharczyk
        /// https://github.com/inwenis/anagrams_kata2
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string[] FindAllAnagrams(string[] words)
        {
            var anagrams = words
                .AsParallel()
                .GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                .Where(g => g.Count() > 1)
                .Select(x => string.Join(" ", x))
                .ToArray();
            return anagrams.ToArray();
        }

        #region old tries
        //        private void FillAnagrams(string[] wordList)
        //        {
        //            Anagrams = new string[wordList.Length + 1];
        //            Anagrams[0] = "0";
        //            int nextFreeIndex = 0;
        //            foreach (string word in wordList)
        //            {
        //                if (word.Length == 1)
        //                {
        //                    Console.WriteLine(word); // See progress while testing
        //                }
        //                bool foundPartner = false;
        //                for (int i = 0; i < Anagrams.Length; i++)
        //                {
        //                    if (i < nextFreeIndex) // check before for entry
        //                    {
        //                        string vergleichswort = Anagrams[i]?.Split(' ')[0];
        //                        if (vergleichswort.Equals("boaters") || vergleichswort.Equals("borates"))
        //                        {
        //                            Console.WriteLine();
        //                        }
        //                        if (word.Length == vergleichswort?.Length) // pre-filtering for better runtime
        //                        {
        //                            char[] arr = word.ToCharArray();
        //                            Array.Sort(arr);
        //                            char[] arr2 = Anagrams[i].ToCharArray();
        //                            Array.Sort(arr2);
        //                            if (new string(arr).Equals(new string(arr2))) // NUR SO KÖNNEN CHARARRAYS VERGLIHEN WERDEN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //                            {
        //                                Anagrams[i] += " " + word;
        //                                foundPartner = true;
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        break; // To not search threw the wohle empty spaces
        //                    }
        //                }
        //                if (!foundPartner)
        //                {

        //                    Anagrams[nextFreeIndex++] = word; // new Anagram line
        //                }
        //            }
        //        }

        //        private void FillAnagrams2(string[] wordList) 
        //        {
        //            // test
        //            // wordList = new string[5] { "test", "n", "tset", "sdret", "002" };

        //            AnagramList = new List<string>();
        //            HashSet<string> usedAnagrams = new HashSet<string>();

        //            foreach (string word in wordList)
        //            {

        //                //// Progress while testing
        //                //if (word.Length == 1)
        //                //{
        //                //    Console.WriteLine(word); // See progress while testing
        //                //}


        //                string anagrams = string.Empty;

        //                var arr = word.ToCharArray();
        //                Array.Sort(arr);
        //                string anagramComparison = new string(arr);
        //                if (!usedAnagrams.Contains(anagramComparison)) // Anagramme bereits ausgelesen und verarbeitet
        //                {
        //                    foreach (string test in wordList)
        //                    {
        //                        var arr2 = test.ToCharArray();
        //                        Array.Sort(arr2);
        //                        string testinfo = new string(arr2);

        //                        if (testinfo.Equals(anagramComparison))
        //                        {
        //                            anagrams += " " + test;
        //                        }
        //                    }
        //                    AnagramList.Add(anagrams);
        //                    usedAnagrams.Add(anagramComparison);
        //                }
        //            }
        //        }

        //        private void FillAnagrams3(string[] wordList)
        //        {

        //            // test
        //            //wordList = new string[5] { "test", "n", "tset", "sdret", "002" };
        //            List<string>[] useThisArray = new List<string>[GetLongestWordLength(wordList)];
        //            AnagramList = new List<string>();
        //            HashSet<string> usedAnagrams = new HashSet<string>();
        //            List<string>[] groupedArray = GroupByAmountOfLetters(wordList);
        //            foreach (var item in groupedArray)
        //            {
        //                int wordLengths = item.First().Length;
        //                useThisArray[wordLengths - 1] = item.ToList();
        //            }




        //            foreach (string word in wordList)
        //            {
        //                string anagramComparison = String.Concat(word.OrderBy(c => c));
        //                if (!usedAnagrams.Contains(anagramComparison)) // Anagramme bereits ausgelesen und verarbeitet
        //                {
        //                    string line = string.Empty;
        //                    var temp = useThisArray[word.Length - 1].Where(element => String.Concat(element.OrderBy(c => c)).Equals(anagramComparison)).AsParallel();

        //                    foreach (var item in temp)
        //                    {

        //                        line += " " + item;
        //                    }
        //                        if (temp.Count()>1)
        //                        {
        //                            Console.WriteLine(line);
        //                        }

        //                    AnagramList.Add(line);

        //                    //Console.WriteLine(line);
        //                    usedAnagrams.Add(anagramComparison);
        //                }
        //            }
        //        }

        //        private void FillAnagramsInternetSolutin(string [] wordList)
        //        {
        //            AnagramList = new List<string>();
        //            wordList.GroupBy(w => String.Concat(w.OrderBy(c => c)))
        //.Where(g => g.Count() > 1)
        //.ToList().ForEach(g => AnagramList.Add(String.Join(" ", g)));
        //        }



        //private int GetLongestWordLength(string[] wordList)
        //{
        //    string longestWord = string.Empty;
        //    foreach (string word in wordList)
        //    {
        //        if (word.Length > longestWord.Length)
        //        {
        //            longestWord = word;
        //        }
        //    }
        //    return longestWord.Length;
        //}

        //private List<string>[] GroupByAmountOfLetters(string[] wordList)
        //{
        //    var subList = wordList.GroupBy(s => ((string)s).Length).Select(group => group.ToList()); // runtime optimization 

        //    return subList.OrderBy(list => list[0].Length).ToArray();
        //}
        //private string GetComparisonString(string word)
        //{
        //    var arr = word.ToCharArray();
        //    Array.Sort(arr);
        //    return new string(arr);
        //}
        #endregion
    }
}
