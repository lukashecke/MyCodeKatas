using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata08_ConflictingObjectives.Readable
{
    internal class Dictionary
    {
        internal List<string> Words { get; set; }
        public Dictionary()
        {
            InitializeDictionary();
        }
        internal List<string> GetSixLetteredWords()
        {
            return Words.Where(word=>word.Length==6).ToList();
        }

        private void InitializeDictionary()
        {
            Words = new List<string>(File.ReadAllLines(Program.UrlPrefix + "wordlist.txt"));
        }
    }
}
