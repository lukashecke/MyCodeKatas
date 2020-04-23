using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    /// <summary>
    /// Jedem rekursiven Aufruf wirden Suchbegrenzungen für das Array mitgegeben.
    /// Vorteil: Speicherfreundlich und Abbruchbedingung kann einfach über die Suchbegrenzungen geschehen.
    /// Vorteil: Auf schnelligkeit ausgerichtet.
    /// Nachteil: Die Mitte ist bei geraden (Sub)Arrays immer +-1. -> Die Übergebenen Suchbegrenzungsindezes müssen dass unbeachtete Element mit -+1 wieder greifen.
    /// </summary>
    public class RecursiveRangeBinarySearch : IBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            if (number >= sortedArray[0] && number <= sortedArray[sortedArray.Length - 1]) // Pre-Search
            {
                return RecursiveRangeBinarySearchSearch(number, sortedArray, 0, sortedArray.Length-1);
            }
            return -1;
        }

        private int RecursiveRangeBinarySearchSearch(int number, int[] sortedArray, int left, int right)
        {
            if (right >= left)
            {
                int mid = (left + right) / 2;
                if (sortedArray[mid] == number)
                {
                    return mid;
                }
                else if (sortedArray[mid] > number)
                {
                    return RecursiveRangeBinarySearchSearch(number, sortedArray, left, mid - 1);
                }
                else if (sortedArray[mid] < number)
                {
                    return RecursiveRangeBinarySearchSearch(number, sortedArray, mid + 1, right);
                }
            }
            return -1;
        }
    }
}
