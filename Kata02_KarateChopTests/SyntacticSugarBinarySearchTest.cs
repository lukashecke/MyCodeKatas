using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata02_KarateChop;
using System.Linq;
using System.Collections.Generic;

namespace Kata02_KarateChopTests
{
    [TestClass]
    public class SyntacticSugarBinarySearchTest : BinarySearchTestBase
    {
        protected override void SearchRandomNumberTest<SyntacticSugarBinarySearch>()
        {
            base.SearchRandomNumberTest<SyntacticSugarBinarySearch>();
        }
        protected override void SearchLowerNumberTest<SyntacticSugarBinarySearch>()
        {
            base.SearchLowerNumberTest<SyntacticSugarBinarySearch>();
        }
        protected override void SearchFirstNumberTest<SyntacticSugarBinarySearch>()
        {
            base.SearchFirstNumberTest<SyntacticSugarBinarySearch>();
        }
        protected override void SearchExactMiddleTest<SyntacticSugarBinarySearch>()
        {
            base.SearchExactMiddleTest<SyntacticSugarBinarySearch>();
        }
        protected override void SearchLastNumberTest<SyntacticSugarBinarySearch>()
        {
            base.SearchLastNumberTest<SyntacticSugarBinarySearch>();
        }
        protected override void SearchBiggerNumberTest<SyntacticSugarBinarySearch>()
        {
            base.SearchBiggerNumberTest<SyntacticSugarBinarySearch>();
        }
        [TestMethod]
        public void SearchRandomNumberTest() { }
        [TestMethod]
        public void SearchLowerNumberTest() { }
        [TestMethod]
        public void SearchFirstNumberTest() { }
        [TestMethod]
        public void SearchExactMiddleTest() { }
        [TestMethod]
        public void SearchLastNumberTest() { }
        [TestMethod]
        public void SearchBiggerNumberTest() { }
    }
}