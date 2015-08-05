using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Variance
{
	[TestFixture]
	public class Variance
	{
		//List<Fruit> frutta = new List<Apple>();
		IBag<Fruit> _frutta = new Bag<Apple>();

		[Test]
		public void Covariance()
		{
			//List<Fruit> frutta = new List<Apple>();
			IBag<Fruit> fruits = new Bag<Apple>();

			var theFruit = fruits.FirstOrDefault();
		}

		[Test]
		public void Controvariance()
		{
			IComparer<Apple> comparer = new Comparer<Fruit>();

			var a = new Apple();
			var b = new Apple();

			comparer.Compare(a, b);
		}
	}

	public class Fruit
	{ }

	public class Apple : Fruit
	{ }

	public class Orange : Fruit
	{ }


	public interface IBag<out T>
	{
		T FirstOrDefault();
	}

	public class Bag<T> : IBag<T>
	{
		private readonly List<T> list;

		public Bag()
		{
			list = new List<T>();
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		public T FirstOrDefault()
		{
			return list.FirstOrDefault();
		}
	}

	public interface IComparer<in T>
	{
		int Compare(T a, T b);
	}

	public class Comparer<T> : IComparer<T>
	{
		public int Compare(T a, T b)
		{
			return 0;
		}
	}
}