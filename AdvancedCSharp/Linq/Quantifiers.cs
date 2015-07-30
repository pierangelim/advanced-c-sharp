using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
	[TestFixture]
	public class Quantifiers
	{
		[Test]
		public void ContainsAnyAll()
		{
			var persons = People.All;
			Console.WriteLine("Is there Matteo 16 years old? {0}", persons.Contains(new Person { Name = "Matteo", Age = 16 }, new PersonComparer()));
			Console.WriteLine("Are there some adults? {0}", persons.Any(p => p.Age > 18));
			Console.WriteLine("Are people all adults? {0}", persons.All(p => p.Age > 18));
		}
	}

	public class PersonComparer : IEqualityComparer<Person>
	{
		public bool Equals(Person x, Person y)
		{
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			if (ReferenceEquals(y, null)) return false;
			if (x.GetType() != y.GetType()) return false;
			return string.Equals(x.Name, y.Name) && x.Age == y.Age;
		}

		public int GetHashCode(Person obj)
		{
			unchecked
			{
				return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^ obj.Age;
			}
		}
	}
}