using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class Equitable
	{
		[Test]
		public void NotSameObject()
		{
			var city1 = new City(5000000, "Rome");
			var city2 = city1;

			Assert.IsTrue(Object.ReferenceEquals(city1, city2));
			Assert.IsTrue(city1.Equals(city2));
			Assert.IsTrue(Object.ReferenceEquals(null, null));

			city2 = new City(5000000, "Rome");

			Assert.IsFalse(Object.ReferenceEquals(city1, city2));
			Assert.IsFalse(city1.Equals(city2));
		}

		[Test]
		public void SameObject()
		{
			var city1 = new EquitableCity(5000000, "Rome");
			var city2 = new EquitableCity(5000000, "Rome");

			Assert.IsTrue(city1.Equals(city2));
			Assert.IsTrue(city1 == city2);
		}
	}

	public class City
	{
		public string Name { get; private set; }
		public long Population { get; private set; }

		public City(long population , string name)
		{
			Population = population;
			Name = name;
		}
	}

	public class EquitableCity : City, IEquatable<City>
	{
		public EquitableCity(long population, string name) : base(population, name) { }

		public bool Equals(City other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Name, other.Name) && Population == other.Population;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is City)) return false;
			return Equals((City)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Population.GetHashCode();
			}
		}

		public static bool operator ==(EquitableCity left, EquitableCity right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(EquitableCity left, EquitableCity right)
		{
			return !Equals(left, right);
		}
	}
}