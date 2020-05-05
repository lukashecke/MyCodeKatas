using System;
using Kata13_CountingCodeLines;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata13_CountingCodeLines.Language_specifications;

namespace Kata13_CountingCodeLinesTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void DirectoryTest()
        {
            // Arrange
            LineCounter lineCounter3 = new LineCounter("TestFiles");
            int expectedResult = 30;
            // Act
            int result = lineCounter3.totalLinesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}