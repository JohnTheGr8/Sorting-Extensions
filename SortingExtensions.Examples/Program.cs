using System;
using System.Collections.Generic;
using System.Linq;
using SortingExtensions;

namespace SortingExtensions.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("------------\nElements: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------");
                var sortme = new List<int>();
                var orderme = new List<Foo>();
                DateTime startTime;

                Random randNum = new Random();
                IReadOnlyList<int> li = Enumerable.Repeat(0, n).Select(i => randNum.Next(0, 500)).ToArray();

                Console.WriteLine("\n** Sort items by value **\n");

                sortme = new List<int>(li);
                startTime = DateTime.Now;
                sortme.BubbleSort();
                Console.WriteLine("Bubble took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                sortme = new List<int>(li);
                startTime = DateTime.Now;
                sortme.InsertionSort();
                Console.WriteLine("Insertion took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                sortme = new List<int>(li);
                startTime = DateTime.Now;
                sortme.SelectionSort();
                Console.WriteLine("Selection took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                sortme = new List<int>(li);
                startTime = DateTime.Now;
                sortme.HeapSort();
                Console.WriteLine("Heap took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                sortme = new List<int>(li);
                startTime = DateTime.Now;
                sortme.MergeSort();
                Console.WriteLine("Merge took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                Console.WriteLine();

                Console.WriteLine("\n** Sort items by key **\n");

                IReadOnlyList<Foo> list = new List<int>(li).ConvertAll(x => new Foo { bar = x });

                orderme = new List<Foo>(list);
                startTime = DateTime.Now;
                orderme.BubbleSort(x => x.bar);
                Console.WriteLine("Bubble took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                orderme = new List<Foo>(list);
                startTime = DateTime.Now;
                orderme.InsertionSort(x => x.bar);
                Console.WriteLine("Insertion took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                orderme = new List<Foo>(list);
                startTime = DateTime.Now;
                orderme.SelectionSort(x => x.bar);
                Console.WriteLine("Selection took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                orderme = new List<Foo>(list);
                startTime = DateTime.Now;
                orderme.HeapSort(x => x.bar);
                Console.WriteLine("Heap took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                orderme = new List<Foo>(list);
                startTime = DateTime.Now;
                orderme.MergeSort(x => x.bar);
                Console.WriteLine("Merge took: {0} ms", (DateTime.Now - startTime).TotalMilliseconds);

                Console.WriteLine();
            }
        }

        class Foo
        {
            public int bar;
        }
    }
}
