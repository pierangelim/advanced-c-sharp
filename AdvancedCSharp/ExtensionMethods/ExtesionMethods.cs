using NUnit.Framework;

namespace ExtensionMethods
{
	[TestFixture]
	public class ExtesionMethods
	{
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(3, 6)]
		[TestCase(7, 5040)]
		public void Factorial(int number, int factorial)
		{
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