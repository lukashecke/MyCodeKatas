using System.Collections.Generic;
using System.IO;

namespace Kata08_ConflictingObjectives
{
    internal class Dictionary
    {
        internal List<string> Words { get; set; }
        public Dictionary(string urlPrefix)
        {
            Words = new List<string>(File.ReadAllLines(urlPrefix + "wordlist.txt"));
        }
    }
}