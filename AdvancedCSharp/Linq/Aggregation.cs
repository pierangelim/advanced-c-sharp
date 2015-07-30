using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
	[TestFixture]
	public class Aggregation
	{
		[Test]
		public void Count()
		{
			IEnumerable<Person> people = People.All;
			Console.WriteLine("People are {0}", people.Count());

			Console.WriteLine("Adults are {0}", people.Count(p => p.Age > 18));
		}

		[Test]
		public void MinAndMax()
		{
			Console.WriteLine("higher age is {0} and the first alphabetically name is {1}", People.All.Max(p => p.Age), People.All.Min(p => p.Name));
		}

		[Test]
		public void SumAndAverage()
		{
			Console.WriteLine("total ages {0}. the average name lenght is {1}", People.All.Sum(p => p.Age), People.All.Average(p => p.Name.Length));
		}

		[Test]
		public void Factorial()
		{
			const int number = 7;
			var range = Enumerable.Range(0, number + 1);
			var result = range.Aggregate((total, i) =>
			{
				if (i <= 1) return 1;
				return total * i;
			});

			Console.WriteLine("{0} factorial is {1}", number, result);

			var x = range.Aggregate("Enumerate numbers: ", (totalString, i) => totalString + (" " + i));
			Console.WriteLine(x);
		}
	}
}
