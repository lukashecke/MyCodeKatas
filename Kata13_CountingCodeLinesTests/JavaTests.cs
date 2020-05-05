using System;
using Kata13_CountingCodeLines;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata13_CountingCodeLines.Language_specifications;

namespace Kata13_CountingCodeLinesTests
{
    [TestClass]
    public class JavaTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            LineCounter lineCounter3 = new LineCounter("Empty.txt");
            int expectedResult = 3;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<JavaFile>(new List<string>() { "TestFiles/Java/SimpleTest.java" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void AdvancedTest()
        {
            // Arrange
            LineCounter lineCounter3 = new LineCounter("Empty.txt");
            int expectedResult = 5;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<JavaFile>(new List<string>() { "TestFiles/Java/AdvancedTest.java" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void UltimateTest()
        {
            LineCounter lineCounter3 = new LineCounter("Empty.txt");
            int expectedResult = 7;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<JavaFile>(new List<string>() { "TestFiles/Java/UltimateTest.java" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void DirectoryTest()
        {
            // Arrange
            LineCounter lineCounter3 = new LineCounter("TestFiles/Java");
            int expectedResult = 15;
            // Act
            int result = lineCounter3.totalLinesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
