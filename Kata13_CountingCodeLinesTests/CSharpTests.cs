﻿using System;
using Kata13_CountingCodeLines;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata13_CountingCodeLines.Language_specifications;

namespace Kata13_CountingCodeLinesTests
{
    [TestClass]
    public class CSharpTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            LineCounter3 lineCounter3 = new LineCounter3("Empty.txt");
            int expectedResult = 3;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<CSharpFile>(new List<string>() { "TestFiles/CSharp/SimpleTest.cs" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void AdvancedTest()
        {
            // Arrange
            LineCounter3 lineCounter3 = new LineCounter3("Empty.txt");
            int expectedResult = 5;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<CSharpFile>(new List<string>() { "TestFiles/CSharp/AdvancedTest.cs" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void UltimateTest()
        {
            LineCounter3 lineCounter3 = new LineCounter3("Empty.txt");
            int expectedResult = 7;
            // Act
            int result = lineCounter3.GetAmountOfCodeLines<CSharpFile>(new List<string>() { "TestFiles/CSharp/UltimateTest.cs" });
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void DirectoryTest()
        {
            // Arrange
            LineCounter3 lineCounter3 = new LineCounter3("TestFiles/CSharp");
            int expectedResult = 15;
            // Act
            int result = lineCounter3.totalLinesOfCode;
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
