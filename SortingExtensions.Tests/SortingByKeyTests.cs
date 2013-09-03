using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SortingExtensions.Tests
{
    [TestFixture]
    class SortingByKeyTests
    {
        private List<MyClass> expected_int;
        private List<MyClass> expected_dt;
        private List<MyClass> expected_str;

        private IReadOnlyList<int> randList_int;
        private IReadOnlyList<DateTime> randList_dt;
        private IReadOnlyList<string> randList_str;

        [SetUp]
        public void Setup()
        {
            var randNum = new Random();
            randList_int = Enumerable.Repeat(0, 1000).Select(i => randNum.Next(0, 1000)).ToArray();
            // Prepare expected -sorted by integer- list
            expected_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            expected_int = expected_int.OrderBy(x => x.myInt).ToList();

            randList_dt =
                Enumerable.Repeat(0, 1000).Select(
                    i => DateTime.MinValue.AddDays(randNum.Next((DateTime.Today - DateTime.MinValue).Days))).ToList();
            // Prepare expected -sorted by DateTime- list
            expected_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            expected_dt = expected_dt.OrderBy(x => x.myDt).ToList();

            randList_str = Enumerable.Repeat(0, 1000).Select(i => System.IO.Path.GetRandomFileName()).ToList();
            // Prepare expected -sorted by string- list
            expected_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            expected_str = expected_str.OrderBy(x => x.myStr).ToList();
        }

        [Test]
        public void BubbleSort_ListGetsSorted()
        {
            // Test sorting by the integer key
            var actual_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            actual_int.BubbleSort(x => x.myInt);

            Assert.AreEqual(expected_int.Count, actual_int.Count);
            expected_int.Each((o, i) => Assert.AreEqual(o.myInt, actual_int[i].myInt));

            //// Tessorting by theth DateTime key
            var actual_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            actual_dt.BubbleSort(x => x.myDt);

            Assert.AreEqual(expected_dt.Count, actual_dt.Count);
            expected_dt.Each((o, i) => Assert.AreEqual(o.myDt, actual_dt[i].myDt));

            //// Tessorting by theth string key
            var actual_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            actual_str.BubbleSort(x => x.myStr);

            Assert.AreEqual(expected_str.Count, actual_str.Count);
            expected_str.Each((o, i) => Assert.AreEqual(o.myStr, actual_str[i].myStr));
        }

        [Test]
        public void HeapSort_ListGetsSorted()
        {
            // Test sorting by the integer key
            var actual_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            actual_int.HeapSort(x => x.myInt);

            Assert.AreEqual(expected_int.Count, actual_int.Count);
            expected_int.Each((o, i) => Assert.AreEqual(o.myInt, actual_int[i].myInt));

            //// Tessorting by theth DateTime key
            var actual_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            actual_dt.HeapSort(x => x.myDt);

            Assert.AreEqual(expected_dt.Count, actual_dt.Count);
            expected_dt.Each((o, i) => Assert.AreEqual(o.myDt, actual_dt[i].myDt));

            //// Tessorting by theth string key
            var actual_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            actual_str.HeapSort(x => x.myStr);

            Assert.AreEqual(expected_str.Count, actual_str.Count);
            expected_str.Each((o, i) => Assert.AreEqual(o.myStr, actual_str[i].myStr));
        }

        [Test]
        public void InsertionSort_ListGetsSorted()
        {
            // Test sorting by the integer key
            var actual_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            actual_int.InsertionSort(x => x.myInt);

            Assert.AreEqual(expected_int.Count, actual_int.Count);
            expected_int.Each((o, i) => Assert.AreEqual(o.myInt, actual_int[i].myInt));

            //// Tessorting by theth DateTime key
            var actual_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            actual_dt.InsertionSort(x => x.myDt);

            Assert.AreEqual(expected_dt.Count, actual_dt.Count);
            expected_dt.Each((o, i) => Assert.AreEqual(o.myDt, actual_dt[i].myDt));

            //// Tessorting by theth string key
            var actual_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            actual_str.InsertionSort(x => x.myStr);

            Assert.AreEqual(expected_str.Count, actual_str.Count);
            expected_str.Each((o, i) => Assert.AreEqual(o.myStr, actual_str[i].myStr));
        }

        [Test]
        public void MergeSort_ListGetsSorted()
        {
            // Test sorting by the integer key
            var actual_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            actual_int = actual_int.MergeSort(x => x.myInt);

            Assert.AreEqual(expected_int.Count, actual_int.Count);
            expected_int.Each((o, i) => Assert.AreEqual(o.myInt, actual_int[i].myInt));

            //// Tessorting by theth DateTime key
            var actual_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            actual_dt = actual_dt.MergeSort(x => x.myDt);

            Assert.AreEqual(expected_dt.Count, actual_dt.Count);
            expected_dt.Each((o, i) => Assert.AreEqual(o.myDt, actual_dt[i].myDt));

            //// Tessorting by theth string key
            var actual_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            actual_str = actual_str.MergeSort(x => x.myStr);

            Assert.AreEqual(expected_str.Count, actual_str.Count);
            expected_str.Each((o, i) => Assert.AreEqual(o.myStr, actual_str[i].myStr));
        }

        [Test]
        public void SelectionSort_ListGetsSorted()
        {
            // Test sorting by the integer key
            var actual_int = new List<int>(randList_int).ConvertAll(x => new MyClass { myInt = x });
            actual_int.SelectionSort(x => x.myInt);

            Assert.AreEqual(expected_int.Count, actual_int.Count);
            expected_int.Each((o, i) => Assert.AreEqual(o.myInt, actual_int[i].myInt));

            //// Tessorting by theth DateTime key
            var actual_dt = new List<DateTime>(randList_dt).ConvertAll(x => new MyClass { myDt = x });
            actual_dt.SelectionSort(x => x.myDt);

            Assert.AreEqual(expected_dt.Count, actual_dt.Count);
            expected_dt.Each((o, i) => Assert.AreEqual(o.myDt, actual_dt[i].myDt));

            //// Tessorting by theth string key
            var actual_str = new List<string>(randList_str).ConvertAll(x => new MyClass { myStr = x });
            actual_str.SelectionSort(x => x.myStr);

            Assert.AreEqual(expected_str.Count, actual_str.Count);
            expected_str.Each((o, i) => Assert.AreEqual(o.myStr, actual_str[i].myStr));
        }
    }

    internal static class Extensions
    {
        /// <summary>
        /// Loop through the IEnumerable, get both T and its index
        /// </summary>
        public static void Each<T>(this IEnumerable<T> li, Action<T, int> action)
        {
            var i = 0;
            foreach (var e in li.ToArray()) action(e, i++);
        }
    }

    internal class MyClass
    {
        public int myInt = 0;
        public DateTime myDt = DateTime.MinValue;
        public string myStr = string.Empty;
    }
}