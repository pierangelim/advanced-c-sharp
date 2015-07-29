using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var squares = numbers.CustomSelect(n => n * n).ToList();

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

            var squares = numbers.CustomSelect(n => n * n).ToList();

            Console.WriteLine("--------------- STARING -----------------");

            Print(squares);

            Console.WriteLine("--------------------------------");

            Print(squares);

            Console.WriteLine("--------------- STOPING -----------------");
        }

        [Test]
        public void ToDictionary()
        {
            var numbers = Enumerable.Range(0, 10);

            var squares = numbers
                .Select(n => new { Value = n, Square = n * n })
                .ToDictionary(o => o.Value, o => o.Square);

            Print(squares);
        }

        [Test]
        public void HowItWorks()
        {
            var result = Generate()
                .CustomSelect(n => n * n)
                .Skip(5)
                .CustomSelect(n => String.Format("Square: {0}", n))
                .Take(5)
                .ToArray();

            Console.WriteLine();

            Print(result);
        }

        [Test]
        public void Why()
        {
            //Deferred execution is important because it decouples query construction from query
            //execution. This allows you to construct a query in several steps, as well as making
            //database queries possible.

            var objects = ListOfBigObjects();

            Console.WriteLine();

            Print(objects.Take(5));
        }

        private IEnumerable<object> ListOfBigObjects()
        {
            return Enumerable.Range(0, 10000).CustomSelect(i => ReadBigFile());
        }

        private static byte[] ReadBigFile()
        {
            return new byte[0];
        }

        private IEnumerable<int> Generate()
        {
            for (var i = 0; ; i++)
            {
                Console.WriteLine("Producing Number {0}", i);
                yield return i;
            }
        }

        private static void Print<T>(IEnumerable<T> enumerbale, string separator = ", ")
        {
            Console.WriteLine(String.Join(separator, enumerbale));
        }
    }
}