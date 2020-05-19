using System;
using Kata11_SortingItOut;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata11_SortingItOutTests
{
    [TestClass]
    public class DecodeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string expected = "aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy";
            MyList<string> myList = new MyList<string>() { "When not studying nuclear physics, Bambi likes to play beach volleyball." };
            // Act
            string actual = myList.Decode(myList[0]);
            // Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}