using System;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class ImmediateOperators
    {
        //Conversion operators: ToArray, ToList, ToDictionary, ToLookup
        //Operators that return a single element or scalar value

        [Test]
        public void Count()
        {
            var result = Enumerable.Range(0, 10)
                .CustomSelect(x => x)
                .Count();

            Console.WriteLine("----------------");
            Console.WriteLine(result);
        }

        [Test]
        public void First()
        {
            var result = Enumerable.Range(0, 10)
                .CustomSelect(x => x)
                .First();

            Console.WriteLine("----------------");
            Console.WriteLine(result);
        }

        [Test]
        public void FirstWithPredicate()
        {
            var result = Enumerable.Range(0, 10)
                .CustomSelect(x => x)
                .First(x => x % 2 == 0);

            //var result = Enumerable.Range(0, 10)
            //    .Where(x => x % 2 == 0)
            //    .First();

            Console.WriteLine("----------------");
            Console.WriteLine(result);
        }

        [Test]
        public void FirstException()
        {
            Assert.Throws<InvalidOperationException>(() => Enumerable.Range(0, 0).First());
        }

        [Test]
        public void FirstOrDefault()
        {
            var first = Enumerable.Range(0, 0).FirstOrDefault();
            Assert.That(first, Is.EqualTo(default(int)));
        }

        [Test]
        public void Single()
        {
            var result = Enumerable.Range(0, 10)
                .CustomSelect(x => x)
                .Single(x => x == 5);

            //var result = Enumerable.Range(0, 10)
            //    .Where(x => x == 5)
            //    .Single();

            Console.WriteLine("----------------");
            Console.WriteLine(result);
        }

        [Test]
        public void SingleWithoutPredicate()
        {
            var result = Enumerable.Range(0, 1).Single();

            Console.WriteLine("----------------");
            Console.WriteLine(result);
        }

        [Test]
        public void SingleException()
        {
            Assert.Throws<InvalidOperationException>(() => Enumerable.Range(0, 0).Single());

            Assert.Throws<InvalidOperationException>(() => Enumerable.Range(0, 10).Single(x => x % 2 == 0));

        }

        [Test]
        public void SingleOrDefault()
        {
            var single = Enumerable.Range(0, 0).SingleOrDefault();
            Assert.That(single, Is.EqualTo(default(int)));

            Assert.Throws<InvalidOperationException>(() => Enumerable.Range(0, 10).SingleOrDefault(x => x % 2 == 0));
        }
    }
}