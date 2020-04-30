using System;
using Kata13_CountingCodeLines;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata13_CountingCodeLinesTests
{
    [TestClass]
    public class JavaFileTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            // Arrange
            LineCounter3 lineCounter3 = new LineCounter3("SimpleTest.java");
            int expectedResult = 3;
            // Act
            int result = lineCounter3.linesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void AdvancedTest()
        {
            // Arrange
            LineCounter3 lineCounter3 = new LineCounter3("AdvancedTest.java");
            int expectedResult = 5;
            // Act
            int result = lineCounter3.linesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void UltimateTest()
        {
            // Arrange
            LineCounter3 lineCounter3 = new LineCounter3("UltimateTest.java");
            int expectedResult = 7;
            // Act
            int result = lineCounter3.linesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
