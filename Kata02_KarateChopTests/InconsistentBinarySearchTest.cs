using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata02_KarateChop;
using System.Linq;
using System.Collections.Generic;

namespace Kata02_KarateChopTests
{
    [TestClass]
    public class InconsistentBinarySearchTest
    {
        [TestMethod]
        public void SearchRandomNumberTest1()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            Random rnd = new Random();
            int number = rnd.Next(-499999, 1000000);
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            List<int> list = sortedArray.ToList();
            int expectedResult = list.IndexOf(number);
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchRandomNumberTest2()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            Random rnd = new Random();
            int number = rnd.Next(-499999, 1000000);
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            List<int> list = sortedArray.ToList();
            int expectedResult = list.IndexOf(number);
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchLowerNumberTest()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            int number = -500001;
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            int expectedResult = -1;
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchFirstNumberTest()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            int number = -500000;
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            int expectedResult = 0;
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchExactMiddleTest()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            int number = 0;
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            int expectedResult = 500000;
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchLastNumberTest()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            int number = 500000;
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            int expectedResult = 1000000;
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void SearchBiggerNumberTest()
        {
            // Arrange
            int[] sortedArray = Enumerable.Range(-500000, 1000001).ToArray();
            int number = 500001;
            InconsistentBinarySearch useless5thBinarySearch = new InconsistentBinarySearch();
            int expectedResult = -1;
            // Act (1 Zeile!)
            int result = useless5thBinarySearch.Search(number, sortedArray);
            // Assert rückgabe vom Act soll überprüft werden
            Assert.AreEqual(expectedResult, result);
        }
    }
}