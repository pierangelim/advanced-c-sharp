using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Collections
{
	[TestFixture]
	public class GenericCollections
	{
		/*
		 * better performance than nongeneric collection
		 * type safe
		 * custom class to handle typed collection is now useless
		 * 
		 * 
		 * Classes of System.Collections.Generic
		 * Dictionary<TKey, TValue>, LinkedList<T>, List<T>, Queue<T>, SortedDictionary<TKey, TValue>, SortedSet<T> and Stack<T>
		*/

		[Test]
		public void ListIsTypeSafe()
		{
			var list = new List<string>();
			list.Add("Matteo is");
			list.Add("31");
			list.Add("years old");
			//list.Add(12);  //--> compile error!

			list.ForEach(Console.WriteLine);
		}

		//You can apply collection initialization syntax only to classesthat support an Add() method,
		//which is formalized by the ICollection<T>/ICollection interfaces.
		[Test]
		public void ListCollectgionInitialization()
		{
			var people = new List<Person>
			{
				new Person { Name = "Matteo", Age = 12 }, //equivalent to people.Add(new Person { Name = "Matteo", Age = 12 }); add the object to the end of the list
				new Person { Name = "Valerio", Age = 13 }
			};

			people.Insert(1, new Person { Name = "Antonio", Age = 23 });

			foreach (var person in people)
			{
				Console.WriteLine(person.Name);
			}
		}

		[Test]
		public void Dicitonary()
		{
			var people = new Dictionary<string, Person>();
			var matteo = new Person
			{
				Name = "Matteo",
				Age = 12
			};
			var valerio = new Person
			{
				Name = "Valerio",
				Age = 13
			};

			people.Add(matteo.Name, matteo);
			people.Add(valerio.Name, valerio);

			//people.Add(valerio.Name, valerio.Age); // <-- compile-time error! it is type safe!
			
			foreach (var key in people.Keys)
			{
				Console.WriteLine("{0} is {1} years old.", key, people[key].Age);
			}
		}

		[Test]
		public void LinkedList()
		{
			var list = new LinkedList<string>();
			var first = list.AddFirst("Matteo");
			var second = list.AddAfter(first, "Pierangeli");
			var third = list.AddAfter(second, "ha");
			var fourth = list.AddAfter(third, "32");
			var fifth = list.AddAfter(fourth, "anni");

			Assert.That(third.Previous.Value, Is.EqualTo("Pierangeli"));
			Assert.That(third.Next.Value, Is.EqualTo("32"));
		}
	}
}