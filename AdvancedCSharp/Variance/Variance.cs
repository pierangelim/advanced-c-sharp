using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Variance
{
	[TestFixture]
	public class Variance
	{
		[Test]
        public void TheProblem()
        {
            List<Fruit> fruits = new List<Fruit>();

            fruits.Add(new Apple());
            fruits.Add(new Orange());

            //List<Fruit> apples = new List<Apple>();
            //apples.Add(new Apple());
            //apples.Add(new Orange()); //BOOM!

            //Comparer<Fruit> comparer = new Comparer<Apple>();
            //comparer.compare(new Apple(), new Orange()); //BOOM!
        }

        [Test]
		public void Covariance() 
		{
            //The type parameter is present only as output parameter

            IBag<Fruit> fruits = new Bag<Apple>();

			var theFruit = fruits.FirstOrDefault();
		}

        [Test]
		public void Controvariance()
		{
            //The type parameter is present only as input parameter

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
		private readonly List<T> _list;

		public Bag()
		{
			_list = new List<T>();
		}

		public void Add(T item)
		{
			_list.Add(item);
		}

		public T FirstOrDefault()
		{
			return _list.FirstOrDefault();
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