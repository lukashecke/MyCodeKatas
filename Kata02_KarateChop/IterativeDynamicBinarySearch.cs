using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    public class IterativeDynamicBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            if (number >= sortedArray[0] && number <= sortedArray[sortedArray.Length-1]) // Pre-Search
            {
                return IterativeDynamicBinarySearchSearch(number, sortedArray);
            }
            return -1;
        }

        private int IterativeDynamicBinarySearchSearch(int number, int[] sortedArray)
        {
            int index = 0;
            while (sortedArray.Length>1)
            {
                int mid = sortedArray.Length / 2;
                if (sortedArray[mid] == number)
                {
                    index += mid;
                    break;
                }
                if (sortedArray[mid] > number)
                {
                    sortedArray = sortedArray.Take(mid).ToArray();     
                }
                else
                {
                    sortedArray = sortedArray.Skip(mid).ToArray();
                    index += mid;
                }
            }
            return index;
        }
    }
}
