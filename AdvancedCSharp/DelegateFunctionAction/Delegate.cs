using System;
using NUnit.Framework;

namespace DelegateFunctionAction
{
	/*
	 * .NET delegate type is a type-safe object that “points to” a method that can be invoked at a later time.
	 *		address, parameters and return type
	*/

	[TestFixture]
	public class Delegate
	{
		public delegate int BinaryOp(int x, int y); //the compiler generate a sealed class with 3 method: Invoke, BeginInvoke and EndInvoke

		[Test]
		public void AddOperation()
		{
			var d = new BinaryOp(SimpleMathStatic.Add);

			//compile error - delegate are type-safe
			//var d2 = new BinaryOp(SimpleMath.SquareNumber);

			Console.WriteLine("10 + 10 is {0}", d(10, 10));
			Console.WriteLine("10 + 10 is {0}", d.Invoke(10, 10));
		}

		[Test]
		public void SubOperation()
		{
			var math = new SimpleMath();
			var d = new BinaryOp(math.Subtract); //if method is not static I've to create an istance of class to create the delegate

			Console.WriteLine("10 - 3 is {0}", d(10, 3));
		}

		public delegate T BinOp<T>(T x);

		[Test]
		public void Calc()
		{
			var square = new BinOp<int>(SimpleMathStatic.SquareNumber);
			var factorial = new BinOp<int>(SimpleMathStatic.Factorial);

			const int number = 7;

			Console.WriteLine("square of {0}: {1}", number, square(number));
			Console.WriteLine("factorial of {0}: {1}", number, factorial.Invoke(number));
		}

		public static class SimpleMathStatic
		{
			public static int Add(int x, int y)
			{
				return x + y;
			}

			public static int SquareNumber(int a)
			{
				return a * a;
			}

			public static int Factorial(int x)
			{
				if (x <= 1) return 1;
				return x * Factorial(x - 1);
			}
		}

		public class SimpleMath
		{
			public int Subtract(int x, int y)
			{
				return x - y;
			}
		}
	}
}