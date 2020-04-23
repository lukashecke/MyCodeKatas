using Kata02_KarateChop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata02_KarateChopTests
{
    public class BinarySearchTestBase
    {
        protected int[] sortedRandomArray = new int[1000000];
        
        public BinarySearchTestBase()
        {
            GenerateTestArrays();
        }

        private void GenerateTestArrays()
        {
            Random randNum = new Random();
            for (int i = 0; i < sortedRandomArray.Length; i++)
            {
                sortedRandomArray[i] = randNum.Next(int.MinValue+1, int.MaxValue-1);
            }
            QuickSort quickSort = new QuickSort();
            sortedRandomArray = quickSort.Sort(sortedRandomArray, 0,999999);
        }

        #region TestMethods
        protected virtual void SearchRandomNumberTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int randomNumber = new Random().Next(int.MinValue, int.MaxValue);
            List<int> list = sortedRandomArray.ToList();
            int expectedResult = list.IndexOf(randomNumber);

            // Act
            int result = searchClassobject.Search(randomNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        protected virtual void SearchLowerNumberTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int lowerNumber = int.MinValue;
            int expectedResult = -1;

            // Act
            int result = searchClassobject.Search(lowerNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        protected virtual void SearchFirstNumberTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int firstNumber = sortedRandomArray[0];
            int expectedResult = 0;

            // Act
            int result = searchClassobject.Search(firstNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        protected virtual void SearchExactMiddleTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int middleNumber = sortedRandomArray[sortedRandomArray.Length/2];
            int expectedResult = sortedRandomArray.Length / 2;

            // Act
            int result = searchClassobject.Search(middleNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        protected virtual void SearchLastNumberTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int lastNumber = sortedRandomArray[sortedRandomArray.Length-1];
            int expectedResult = sortedRandomArray.Length - 1;

            // Act
            int result = searchClassobject.Search(lastNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        protected virtual void SearchBiggerNumberTest<T>() where T : IBinarySearch, new()
        {
            // Arrange
            T searchClassobject = new T();
            int biggerNumber = int.MaxValue;
            int expectedResult = -1;

            // Act
            int result = searchClassobject.Search(biggerNumber, sortedRandomArray);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion
    }
}