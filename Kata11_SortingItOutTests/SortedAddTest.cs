using System;
using System.Collections;
using System.Collections.Generic;
using Kata11_SortingItOut;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata11_SortingItOutTests
{
    [TestClass]
    public class SortedAddTest
    {
        [TestMethod]
        public void SortingTest()
        {
            // Arange
            MyList<int> numbers = new MyList<int>();
            // Act
            numbers.SortedAdd(20); 
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { 20 },numbers);
            // Act
            numbers.SortedAdd(10);
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { 10, 20 }, numbers);
            // Act
            numbers.SortedAdd(30);
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { 10, 20, 30 }, numbers);
            // Act
            numbers.SortedAdd(15);
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { 10, 15, 20, 30 }, numbers);
            // Act
            numbers.SortedAdd(-1);
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { -1, 10, 15, 20, 30 }, numbers);
            // Act
            numbers.SortedAdd(31);
            // Assert
            CollectionAssert.AreEqual(new MyList<int>() { -1, 10, 15, 20, 30, 31 }, numbers);
            

        }
    }
}
