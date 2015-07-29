using System;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
	[TestFixture]
	public class OrderBy
	{
		[Test]
		public void OrderedPeopleByAge()
		{
			var people = People.All;
			people.OrderBy(p => p.Age).ToList().ForEach(Console.WriteLine);
		}
		[Test]
		public void OrderedPeopleByAgeName()
		{
			var people = People.All;
			people.OrderBy(p => p.Age).ThenBy(p => p.Name).ToList().ForEach(Console.WriteLine);
		}
	}
}