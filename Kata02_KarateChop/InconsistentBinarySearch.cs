using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    /// <summary>
    /// Problem: Schleife muss umgekehrt werden um die Abfrage nach der Arrayhalbierung durchführen zu können
    /// </summary>
    public class InconsistentBinarySearch : IBinarySearch
    {
        public int Search(int number, int[] sortedArray)
        {
            if (sortedArray.Contains(number)) // Pre-Search
            {
                return IDKBinarySearchSearch(number, sortedArray);
            }
            return -1;
        }

        private int IDKBinarySearchSearch(int number, int[] sortedArray)
        {
            int index = 0;
            int mid = sortedArray.Length / 2;
            do
            {
                if (number < sortedArray[mid])
                {
                    sortedArray = GetHalve(1, sortedArray);
                }
                else if (number > sortedArray[mid])
                {
                    sortedArray = GetHalve(2, sortedArray);

                    index += mid;
                }
                mid = sortedArray.Length / 2;

            } while (sortedArray.Length >= 1 && sortedArray[sortedArray.Length / 2] != number);

            //while (sortedArray.Length > 1 && sortedArray[sortedArray.Length / 2] != number)
            //{
            //    mid = sortedArray.Length / 2;
            //    if (sortedArray[sortedArray.Length / 2] != number)
            //    {


            //        if (number < sortedArray[mid])
            //        {
            //            sortedArray = GetHalve(1, sortedArray);
            //        }
            //        else if (number > sortedArray[mid])
            //        {
            //            sortedArray = GetHalve(2, sortedArray);

            //            index += mid;
            //        }
            //    }
            //}
            return mid + index;
        }

        private int[] GetHalve(int halveNumber, int[] array)
        {
            if (halveNumber == 1)
            {
                return array.Take(array.Length / 2).ToArray();
            }
            else // halveNumber == 2
            {
                return array.Skip(array.Length / 2).ToArray();
            }
        }
    }
}
