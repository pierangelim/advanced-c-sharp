using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class Select
    {
        [Test]
        public void Basic()
        {
            var enumerable = Enumerable.Range(0, 10);

            var squares = enumerable.Select(i => i * i);

            Print(squares);
        }

        [Test]
        public void Mapping()
        {
            var enumerable = Enumerable.Range(1, 12);

            var months = enumerable.Select(i => new DateTime(2015, i, 1).ToString("MMMM"));

            Print(months);
        }

        [Test]
        public void Projection()
        {
            var ages = People.All.Select(p => p.Age);

            Print(ages);
        }

        [Test]
        public void AnonymousType()
        {
            var projected = People.All.Select(p => new
            {
                Initial = p.Name.First(), 
                BirthYear = DateTime.Now.AddYears(-p.Age).Year
            });

            Print(projected);
        }

        [Test]
        public void Combine()
        {
            var projected = People.All
                .Select(p => p.Name)
                .Select(n => n.ToUpper())
                .Select(n => n.PadRight(15, '.'));

            Print(projected, Environment.NewLine);
        }

        private static void Print<T>(IEnumerable<T> enumerbale, string separator = ", ")
        {
            Console.WriteLine(String.Join(separator, enumerbale));
        }
    }
}