namespace DelegateFunctionAction
{
	public class SimpleMath
	{
		private const double Error = 0.1;

		public int Subtract(int x, int y)
		{
			return x - y;
		}

		public double SubtractWithError(int x, int y)
		{
			return x - y - Error;
		}

		public static int Add(int x, int y)
		{
			return x + y;
		}

		public static int SquareNumber(int a)
		{
			return a * a;
		}

		public static long SquareNumber(long a)
		{
			return a * a;
		}

		public static int Factorial(int x)
		{
			if (x <= 1) return 1;
			return x * Factorial(x - 1);
		}
	}
}