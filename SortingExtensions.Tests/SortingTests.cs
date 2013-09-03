using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SortingExtensions.Tests
{
    [TestFixture]
    class SortingTests
    {
        private List<int> expected_int;
        private List<DateTime> expected_dt;
        private List<string> expected_str;

        private IReadOnlyList<int> randList_int;
        private IReadOnlyList<DateTime> randList_dt;
        private IReadOnlyList<string> randList_str;

        [SetUp]
        public void Setup()
        {
            var randNum = new Random();
            randList_int = Enumerable.Repeat(0, 1000).Select(i => randNum.Next(0, 1000)).ToArray();
            // Prepare expected (sorted) integer list
            expected_int = new List<int>(randList_int);
            expected_int.Sort();

            randList_dt =
                Enumerable.Repeat(0, 1000).Select(
                    i => DateTime.MinValue.AddDays(randNum.Next((DateTime.Today - DateTime.MinValue).Days))).ToList();
            // Prepare expected (sorted) DateTime list
            expected_dt = new List<DateTime>(randList_dt);
            expected_dt.Sort();

            randList_str = Enumerable.Repeat(0, 1000).Select(i => System.IO.Path.GetRandomFileName()).ToList();
            // Prepare expected (sorted) string list
            expected_str = new List<string>(randList_str);
            expected_str.Sort();
        }

        [Test]
        public void BubbleSort_ListGetsSorted()
        {
            // Test with integer list
            var actual_int = new List<int>(randList_int).BubbleSort();
            Assert.AreEqual(expected_int, actual_int);
            // Test with DateTime list
            var actual_dt = new List<DateTime>(randList_dt).BubbleSort();
            Assert.AreEqual(expected_dt, actual_dt);
            // Test with string list
            var actual_str = new List<string>(randList_str).BubbleSort();
            Assert.AreEqual(expected_str, actual_str);
        }

        [Test]
        public void HeapSort_ListGetsSorted()
        {
            // Test with integer list
            var actual_int = new List<int>(randList_int).HeapSort();
            Assert.AreEqual(expected_int, actual_int);
            // Test with DateTime list
            var actual_dt = new List<DateTime>(randList_dt).HeapSort();
            Assert.AreEqual(expected_dt, actual_dt);
            // Test with string list
            var actual_str = new List<string>(randList_str).HeapSort();
            Assert.AreEqual(expected_str, actual_str);
        }

        [Test]
        public void InsertionSort_ListGetsSorted()
        {
            // Test with integer list
            var actual_int = new List<int>(randList_int).InsertionSort();
            Assert.AreEqual(expected_int, actual_int);
            // Test with DateTime list
            var actual_dt = new List<DateTime>(randList_dt).InsertionSort();
            Assert.AreEqual(expected_dt, actual_dt);
            // Test with string list
            var actual_str = new List<string>(randList_str).InsertionSort();
            Assert.AreEqual(expected_str, actual_str);
        }

        [Test]
        public void MergeSort_ListGetsSorted()
        {
            // Test with integer list
            var actual_int = new List<int>(randList_int).MergeSort();
            Assert.AreEqual(expected_int, actual_int);
            // Test with DateTime list
            var actual_dt = new List<DateTime>(randList_dt).MergeSort();
            Assert.AreEqual(expected_dt, actual_dt);
            // Test with string list
            var actual_str = new List<string>(randList_str).MergeSort();
            Assert.AreEqual(expected_str, actual_str);
        }

        [Test]
        public void SelectionSort_ListGetsSorted()
        {
            // Test with integer list
            var actual_int = new List<int>(randList_int).SelectionSort();
            Assert.AreEqual(expected_int, actual_int);
            // Test with DateTime list
            var actual_dt = new List<DateTime>(randList_dt).SelectionSort();
            Assert.AreEqual(expected_dt, actual_dt);
            // Test with string list
            var actual_str = new List<string>(randList_str).SelectionSort();
            Assert.AreEqual(expected_str, actual_str);
        }
    }
}