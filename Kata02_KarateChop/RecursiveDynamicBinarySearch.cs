using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    /// <summary>
    /// Jedem rekursiven Aufruf wird ein neues halbiertes Array mitgegeben.
    /// Vorteil: 
    /// Nachteil: Die Indizes entsprechen nicht mehr dem des Originalarrays. -> IndexOffset muss der Methode mitgegeben werden.
    /// Nachteil: Unnötig jedes mal ein neues Array zu erzeugen (Speicher + Laufzeit)
    /// </summary>
    public class RecursiveDynamicBinarySearch : IBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            if (number >= sortedArray[0] && number <= sortedArray[sortedArray.Length - 1]) // Pre-Search
            {
                return RekursiveDynamicBinarySearchSearch(number, sortedArray, 0);
            }
            return -1;
        }

        private int RekursiveDynamicBinarySearchSearch(int number, int[] sortedArray, int indexOffset)
        {
            int mid = sortedArray.Length / 2;
            if (sortedArray[mid] == number)
            {
                return mid + indexOffset;
            }
            else if (sortedArray[mid] > number && sortedArray.Length > 1)
            {
                return RekursiveDynamicBinarySearchSearch(number, sortedArray.Take(mid).ToArray(), indexOffset);
            }
            else if (sortedArray[mid] < number && sortedArray.Length > 1)
            {
                // Indexverschiebung mitgeben, falls 
                return RekursiveDynamicBinarySearchSearch(number, sortedArray.Skip(mid).ToArray(), indexOffset + mid);
            }
            return -1;
        }
    }
}
