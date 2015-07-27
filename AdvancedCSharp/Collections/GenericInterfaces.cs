using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Collections
{
    [TestFixture]
    public class GenericInterfaces
    {
        [Test]
        public void Enumerable()
        {
            //IEnumerable<T> 					Returns the IEnumerator<T> interface for a given object.
            //IEnumerator<T> 					Enables foreach-style iteration over a generic collection.

            var ints = System.Linq.Enumerable.Range(0, 10);
            ForEach(ints);

            Console.WriteLine();

            var strings = System.Linq.Enumerable.Repeat("°-,¸¸,-°", 10);
            ForEach(strings);

            Console.WriteLine();

            //Cast
            var zeros = System.Linq.Enumerable.Repeat<object>(0, 10);
            ForEach(zeros.Cast<int>()); 
        }

        private static void ForEach<T>(IEnumerable<T> enumerable)
        {
            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.Write(enumerator.Current);
                }
            }
        }

        [Test]
        public void Collection()
        {
            //ICollection<T> 					Defines general characteristics (e.g., size, enumeration, and thread safety) for all generic collection types.

            ICollection<int> collection = new List<int>();

            collection.Add(1); 
            collection.Add(2);
            collection.Add(3);

            collection.Remove(1);

            Assert.That(collection.Count, Is.EqualTo(2));
            Assert.IsTrue(collection.Contains(2));

            collection.Clear();
            Assert.That(collection.Count, Is.EqualTo(0));
        }

        [Test]
        public void List()
        {
            //IList<T> 						Provides behavior to add, remove, and index items in a sequential list of objects.

            IList<int> list = new List<int>();

            list.Add(2);
            list.Add(3);

            Assert.That(list[0], Is.EqualTo(2));
            Assert.That(list[1], Is.EqualTo(3));

            list[0] = 3;
            Assert.That(list[0], Is.EqualTo(3));
        }

        [Test]
        public void Dictionary()
        {
            //IDictionary<TKey, TValue> 		Allows a generic collection object to represent its contents using key/value pairs.

            IDictionary<int, string> dictionary = new Dictionary<int, string>();

            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");

            Assert.IsTrue(dictionary.ContainsKey(1));

            ForEach(dictionary.Keys);
            ForEach(dictionary.Values);

            string output;
            Assert.False(dictionary.TryGetValue(12, out output));
        }

        [Test]
        public void Set()
        {
            //ISet<T> 						Provides the base interface for the abstraction of sets.

            ISet<int> set = new HashSet<int>();

            set.Add(1);
            set.Add(2);

            Assert.IsFalse(set.Add(1));

            set.IntersectWith(new [] {2, 3});
            Assert.That(set.Count, Is.EqualTo(1));
            Assert.That(set.Contains(2));

            var isSubset = set.IsSubsetOf(new[] { 2, 4, 6 });
            Assert.IsTrue(isSubset);
        }
    }
}