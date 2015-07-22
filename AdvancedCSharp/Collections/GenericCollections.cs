using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Collections
{
	[TestFixture]
	public class GenericCollections
	{
		/*
		  * migliori performance perchè non deve fare box e unbox dei value type
		  * sono type safe perchè contengono solo tipi di oggetti specificati
		  * riduce la necessità di crearsi collection custom
		  */

		[Test]
		public void ListIsTypeSafe()
		{
			var list = new List<string>();
			list.Add("Matteo ha");
			list.Add("31");
			list.Add("anni");

			list.ForEach(Console.WriteLine);
		}

		[Test]
		public void ListObjInitialization()
		{
			var people = new List<Person>
			{
				new Person { Name = "Matteo", Age = 12 },
				new Person { Name = "Valerio", Age = 13 }
			};

			people.Insert(1, new Person { Name = "Antonio", Age = 23 });

			foreach (var person in people)
			{
				Console.WriteLine(person.Name);
			}

			var a = people.ToArray();
			foreach (var person in a)
			{
				Console.WriteLine(person.Name);
			}
		}

		//Stack<T> e Queue<T>

		[Test]
		public void Dicitonary()
		{
			var people = new Dictionary<string, Person>();
			var matteo = new Person();
			matteo.Name = "Matteo";
			matteo.Age = 12;
			var valerio = new Person();
			valerio.Name = "Valerio";
			valerio.Age = 13;

			people.Add(matteo.Name, matteo);
			people.Add(valerio.Name, valerio);

			//compile time error!
			//people.Add(valerio.Name, valerio.Age);

			foreach (var key in people.Keys)
			{
				Console.WriteLine("{0} ha {1} anni.", key, people[key].Age);
			}
		}
	}

	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}
}