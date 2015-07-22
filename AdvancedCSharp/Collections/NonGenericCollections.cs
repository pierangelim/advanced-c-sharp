using System;
using System.Collections;
using NUnit.Framework;

namespace Collections
{
	[TestFixture]
	public class NonGenericCollections
	{
		/*
		 * poco performanti (clr deve fare molte operaizioni in memoria (box e unbox) quando si opera su classi che lavoro so Object)
		 * non sono type safe (eventulamente dovresti creare MyCollection che implementa IEnumerable che garantisce la type safety)
		 * 
		 * per ogni collection di tipo diverso si è costretti a creare una classe ad hoc
		 * public class PersonCollection : IEnumerable
			{
			private ArrayList arPeople = new ArrayList();
			// Cast for caller.
			public Person GetPerson(int pos)
			{ return (Person)arPeople[pos]; }
			// Insert only Person objects.
			public void AddPerson(Person p)
			{ arPeople.Add(p); }
			public void ClearPeople()
			{ arPeople.Clear(); }
			public int Count
			{ get { return arPeople.Count; } }
			// Foreach enumeration support.
			IEnumerator IEnumerable.GetEnumerator()
			{ return arPeople.GetEnumerator(); }
			}
		*/
		/*
			ICollection Defines general characteristics (e.g., size, enumeration, and thread safety) for all nongeneric collection types.
			ICloneable Allows the implementing object to return a copy of itself to the caller.
			IDictionary Allows a nongeneric collection object to represent its contents using key/value pairs.
			IEnumerable Returns an object implementing the IEnumerator interface (see next table entry).
			IEnumerator Enables foreach style iteration of collection items.
			IList Provides behavior to add, remove, and index items in a sequential list of objects.
		*/

		[Test]
		public void ArrayListIsUnsafe()
		{
			var array = new ArrayList();
			array.Add("Matteo ha");
			array.Add(31);
			array.Add("anni");

			//var a = 0;
			foreach (var e in array)
			{
				Console.WriteLine(e);
				//a += (int)e;
			}
		}

		[Test]
		public void HashTable()
		{
			var cache = new Hashtable();
			cache.Add(123, "matteo");
			cache.Add(124, "pierangeli");
			cache.Add(125, 31);

			Assert.That(cache[123], Is.EqualTo("matteo"));
		}

		[Test]
		public void Stack()
		{
			var s = new Stack(10);
			s.Push("matteo");
			s.Push("pierangeli");

			Assert.That(s.Pop(), Is.EqualTo("pierangeli"));
		}
	}
}