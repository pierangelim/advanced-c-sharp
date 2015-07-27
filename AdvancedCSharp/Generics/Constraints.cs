using System;
using NUnit.Framework;

namespace Generics
{
    public class Comparer<T> : IComparer<T> where T : System.IComparable<T>
    {
        public int Compare(T a, T b)
        {
            return a.CompareTo(b);
        }
    }

    public class ObjectFactory<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    [TestFixture]
    public class Constraints
    {
        [Test]
        public void Interface()
        {
            var intComparer = new Comparer<int>();
            var result1 = intComparer.Compare(1, 0);
            Assert.That(result1, Is.EqualTo(1));

            var stringComparer = new Comparer<string>();
            var result2 = stringComparer.Compare("aaaa", "bbbb");
            Assert.That(result2, Is.EqualTo(-1));
        }

        [Test]
        public void Constructor()
        {
            var dateTimeFactory = new ObjectFactory<DateTime>();
            Assert.That(dateTimeFactory.Create(), Is.Not.Null);

            var intComparerFactory = new ObjectFactory<Comparer<int>>();
            Assert.That(intComparerFactory.Create(), Is.Not.Null);
        }
    }
}