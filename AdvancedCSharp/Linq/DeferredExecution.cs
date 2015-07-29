using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class DeferredExecution
    {
        [Test]
        public void Basic()
        {
            //Query operators are execute not when constructed, but when enumerated (in other words, when MoveNext is called on its enumerator).

            var numbers = new List<int>() { 1, 2, 3, 4 };

            var query = numbers.Select(n => n * 10);

            numbers.Add(5);

            foreach (var n in query)
                Console.Write(n + "|");
        }

        [Test]
        public void MultipleEnumeration()
        {
            var numbers = Enumerable.Range(0, 10);

            var squares = numbers.Select(n =>
            {
                Console.WriteLine("Processing n: {0}", n);
                return n * n;
            });

            Console.WriteLine("--------------- STARING -----------------");

            Print(squares);

            Console.WriteLine("--------------------------------");

            Print(squares);

            Console.WriteLine("--------------- STOPING -----------------");
        }

        [Test]
        public void ImmediateExecution()
        {
            var numbers = Enumerable.Range(0, 10);

            var squares = numbers.Select(n =>
            {
                Console.WriteLine("Processing n: {0}", n);
                return n * n;
            }).ToList();

            Console.WriteLine("--------------- STARING -----------------");

            Print(squares);

            Console.WriteLine("--------------------------------");

            Print(squares);

            Console.WriteLine("--------------- STOPING -----------------");
        }

        private static void Print<T>(IEnumerable<T> enumerbale, string separator = ", ")
        {
            Console.WriteLine(String.Join(separator, enumerbale));
        }
    }
}