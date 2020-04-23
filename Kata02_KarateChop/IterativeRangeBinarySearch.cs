using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    /// <summary>
    /// Vorteil: Keine zusätzliche Parameterübergabe benötigt
    /// Vorteil: Selbe Funktionsweise wie rekursives Gegenstück, jedoch iterativ (sicherer und verständlicher)
    /// </summary>
    public class IterativeRangeBinarySearch : IBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            if (number >= sortedArray[0] && number <= sortedArray[sortedArray.Length - 1]) // Pre-Search
            {
                return IterativeRangeBinarySearchSearch(number, sortedArray);
            }
            return -1;
        }

        private int IterativeRangeBinarySearchSearch(int number, int[] sortedArray)
        {
            int left = 0, right = sortedArray.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (sortedArray[mid] == number)
                {
                    return mid;
                }
                if (sortedArray[mid] < number)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
