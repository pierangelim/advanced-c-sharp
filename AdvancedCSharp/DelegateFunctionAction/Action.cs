using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DelegateFunctionAction
{
	[TestFixture]
	public class Action
	{
		/*
		 * To use delegate in you code, yuo have to:
		 * - Define a custom delegate that matches the format of the method being pointed to.
		 * - Create an instance of your custom delegate, passing in a method name as a constructor argument.
		 * - Invoke the method indirectly, via a call to Invoke() on the delegate object.
		 * 
		 * You can use framework built-in generic delegate Action<> and Func<>
		*/

		private List<Func<int, int>> operationList = new List<Func<int, int>>();

		[Test]
		public void SquareFactorial() //As you can see, using the Function<> delegate saves you the bother of defining a custom delegate.
		{
			Func<int, int> sq = SimpleMathStatic.SquareNumber;
			Func<int, int> fa = SimpleMathStatic.Factorial;

			operationList.Add(sq);
			operationList.Add(fa);

			foreach (var operation in operationList)
			{
				Console.WriteLine(operation(7));
			}
		}

		[Test]
		public void AddOperation() //If you have to return void
		{
			Action<string, int, Func<int, int>> visualizer = Visualizer.MathOperationVisualizer;

			Func<int, int> sq = SimpleMathStatic.SquareNumber;
			Func<int, int> fa = SimpleMathStatic.Factorial;

			const int number = 7;

			visualizer("square", number, sq);
			visualizer("factorial", number, fa);
		}

		public static class SimpleMathStatic
		{
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

		public static class Visualizer
		{
			public static void MathOperationVisualizer(string operation, int number, Func<int, int> f)
			{
				Console.WriteLine("{0} of {1}: {2}", operation, number, f.Invoke(number));
			}
		}
	}
}