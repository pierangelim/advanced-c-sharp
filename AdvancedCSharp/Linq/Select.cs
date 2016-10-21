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

            squares.Print();
        }

        [Test]
        public void Mapping()
        {
            var enumerable = Enumerable.Range(1, 12);

            var months = enumerable.Select(i => new DateTime(2015, i, 1).ToString("MMMM"));

            months.Print();
        }

        [Test]
        public void Projection()
        {
            var ages = People.All.Select(p => p.Age);

            ages.Print();
        }

        [Test]
        public void AnonymousType()
        {
            var projected = People.All.Select(p => new
            {
                Initial = p.Name.First(), 
                BirthYear = DateTime.Now.AddYears(-p.Age).Year
            });

            projected.Print();
        }

        [Test]
        public void Combine()
        {
            var projected = People.All
                .Select(p => p.Name)
                .Select(n => n.ToUpper())
                .Select(n => n.PadRight(15, '.'));

            projected.Print(Environment.NewLine);
        }

        [Test]
        public void SelectMany()
        {
            var fullNames = new [] { "Anne Williams", "John Fred Smith", "Sue Green" };

            var result = fullNames.SelectMany(name => name.Split());

            result.Print("|");
        }

        [Test]
        public void Flatten()
        {
            var listA = new List<int> { 1, 2, 3, 4, 5 };
            var listB = new List<int> { 6, 7, 8, 9, 10 };
            var listC = new List<int> { 11, 12, 13, 14, 15 };

            var lists = new List<List<int>> { listA, listB, listC };

            var theList = lists.SelectMany(x => x);

            theList.Print();
        }
    }
}
