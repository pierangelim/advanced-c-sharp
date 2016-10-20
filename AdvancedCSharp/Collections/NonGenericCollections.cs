using System;
using System.Collections;
using NUnit.Framework;

namespace Collections
{
	[TestFixture]
	public class NonGenericCollections
	{
		/*
		 * poor performance with value type
		 * clr have to permform many memory operations
		 * (box valuetype -> object e unbox object -> valuetype) -> stack/heap memory transfer
		 * 
		 * no type safe
		 * in order to have type safety you have to have your own class
		 * that implements IEnumerable and you have to cast/check at every operation
		 * E.g. PersonCollection class below
		 * 
		 * For every type you have to create a dedicated class
		 * very boring and verbose
		*/

		public class PersonCollection : IEnumerable
		{
			private ArrayList arPeople = new ArrayList();

			// Cast for caller.
			public Person GetPerson(int pos)
			{
				return (Person)arPeople[pos];
			}
			// Insert only Person objects.
			public void AddPerson(Person p)
			{
				arPeople.Add(p);
			}

			public void ClearPeople()
			{
				arPeople.Clear();
			}

			public int Count
			{
				get { return arPeople.Count; }
			}
			// Foreach enumeration support.
			IEnumerator IEnumerable.GetEnumerator()
			{
				return arPeople.GetEnumerator();
			}
		}

		/*
		 * Useful Types of System.Collections
		 * ArrayList, BitArray, Hashtable, Queue, SortedList and Stack
		 * 
		 * 
		 * .NET provides some interfaces implemented by system class used to manage data (e.g. ArrayList, BitArray, HashTable, Queue, SortedList, Stack ...).
		 * 
		 * ICollection Defines general characteristics (e.g., size, enumeration, and thread safety) for all nongeneric collection types.
		 * ICloneable Allows the implementing object to return a copy of itself to the caller.
		 * IDictionary Allows a nongeneric collection object to represent its contents using key/value pairs.
		 * IEnumerable Returns an object implementing the IEnumerator interface.
		 * IEnumerator Enables foreach style iteration of collection items.
		 * IList Provides behavior to add, remove, and index items in a sequential list of objects.
		*/

		[Test]
		public void ArrayListIsUnsafe()
		{
			var array = new ArrayList();
			array.Add("Matteo is");
			array.Add(31);
			array.Add("years old");

			//var a = 0;
			foreach (var e in array)
			{
				Console.WriteLine(e);
				//a += (int)e; //--> run-time exception!
			}
		}

		[Test]
		public void HashTable()
		{
			var cache = new Hashtable();
			cache.Add(123, "Matteo");
			cache.Add(124, "Pierangeli");
			cache.Add(125, 31);

			Assert.That(cache[123], Is.EqualTo("Matteo"));
		}

		[Test]
		public void Queue()
		{
			var queue = new Queue(10);
			queue.Enqueue("Matteo");
			queue.Enqueue("Pierangeli");

			Assert.That(queue.Dequeue(), Is.EqualTo("Matteo"));
		}

		[Test]
		public void Stack()
		{
			var stack = new Stack(10);
			stack.Push("Matteo");
			stack.Push("Pierangeli");

			Assert.That(stack.Pop(), Is.EqualTo("Pierangeli"));
		}

		[Test]
		public void SortedList()
		{
			var list = new SortedList();
			list.Add(5, "Matteo");
			list.Add(4, DateTime.UtcNow);
			list.Add(1, "Pierangeli");

			var firstPosition = list.GetKey(0);
			Assert.That(list[firstPosition], Is.EqualTo("Pierangeli"));
		}
	}
}