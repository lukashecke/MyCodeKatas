using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    /// <summary>
    /// Vorteil: Gut zu lesen mit minimal längerer Laufzeit als RecursiveRange-Variante
    /// </summary>
    public class SyntacticSugarBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            int firstElement = sortedArray.First();
            int lastElement = sortedArray.Last();
            if (!(number < firstElement || number > lastElement)) // Pre-Search
            {
                return SyntacticSugarBinarySearchSearch(number, sortedArray, 0, sortedArray.Length - 1);
            }
            return -1;
        }

        private int SyntacticSugarBinarySearchSearch(int number, int[] sortedArray, int left, int right)
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
                    return SyntacticSugarBinarySearchSearch(number, sortedArray, left, mid - 1);
                }
                else if (sortedArray[mid] < number)
                {
                    return SyntacticSugarBinarySearchSearch(number, sortedArray, mid + 1, right);
                }
            }
            return -1;
        }
    }
}
