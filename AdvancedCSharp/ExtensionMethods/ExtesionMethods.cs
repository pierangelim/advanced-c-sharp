using NUnit.Framework;

namespace ExtensionMethods
{
	/*
	 * .NET 3.5 introduced the concept of extension methods,
	 * which allow you to add new methods or properties to a class or structure,
	 * without modifying the original type in any direct manner.
	*/
	[TestFixture]
	public class ExtesionMethods
	{
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(3, 6)]
		[TestCase(7, 5040)]
		public void Factorial(int number, int factorial)
		{
			Assert.That(IntegerExtensions.Factorial(number), Is.EqualTo(factorial));
			Assert.That(number.Factorial(), Is.EqualTo(factorial));
		}
	}

	public static class IntegerExtensions
	{
		public static int Factorial(this int x)
		{
			if (x <= 1) return 1;
			return x * Factorial(x - 1);
		}
	}
}