using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class CastOperators
	{
		[Test]
		public void ExplicitConversion()
		{
			var square = (Square)90;
			Console.WriteLine("square = {0}", square);

			var side = (int)square;
			Console.WriteLine("Side length of square = {0}", side);
			Console.ReadLine();
		}

		[Test]
		public void ImplicitConversion()
		{
			var s3 = new Square();
			s3.Length = 7;
			Rectangle rect2 = s3;
			Console.WriteLine("rect2 = {0}", rect2);
		}
	}

	public class Square
	{
		public int Length { get; set; }

		public override string ToString()
		{
			return string.Format("[Length = {0}]", Length);
		}

		public static explicit operator Square(int sideLength)
		{
			var newSq = new Square();
			newSq.Length = sideLength;
			return newSq;
		}

		public static explicit operator int(Square s)
		{
			return s.Length;
		}
	}

	public struct Rectangle
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public override string ToString()
		{
			return string.Format("[Width = {0}; Height = {1}]",
				Width, Height);
		}

		public static implicit operator Rectangle(Square s)
		{
			var r = new Rectangle();
			r.Height = s.Length;
			r.Width = s.Length * 2;
			return r;
		}
	}
}