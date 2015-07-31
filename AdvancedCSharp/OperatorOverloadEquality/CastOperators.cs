using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class CastOperators
	{
		/*
		 * In terms of the intrinsic numerical types, an explicit conversion is required when you attempt to store a larger value in a smaller container, as this could result in a loss of data
		 * Conversely, an implicit conversion happens automatically when you attempt to place a smaller type in a destination type that will not result in a loss of data
		*/
		[Test]
		public void NumericalCast()
		{
			int a = 123;
			Console.WriteLine(a);
			double b = a; // Implicit conversion from int to long.
			b += 0.456;
			Console.WriteLine(b);
			int c = (int)b; // Explicit conversion from long to int.
			Console.WriteLine(c);
		}

		//Class types may be related by classical inheritance (the “is-a” relationship). In this case, the C# conversion process allows you to cast up and down the class hierarchy.
		[Test]
		public void HierarchyCast()
		{
			// Implicit cast between derived to base.
			Base myBaseType;
			myBaseType = new Derived();
			// Must explicitly cast to store base reference
			// in derived type.
			Derived myDerivedType = (Derived)myBaseType;
		}

		//However, what if you have two class types in different hierarchies with no common parent (other than System.Object) that require conversions?
		[Test]
		public void ExplicitConversion()
		{
			var square = (Square)90;
			DrawSquare(square);

			var side = (int)square;
			Console.WriteLine("Side length of square = {0}", side);
			Console.ReadLine();
		}

		[Test]
		public void ImplicitConversion()
		{
			var square = new Square();
			square.Length = 7;

			DrawRectangle(square);
		}

		private static void DrawSquare(Square square)
		{
			Console.WriteLine("square = {0}", square);
		}

		private static void DrawRectangle(Rectangle rectangle)
		{
			Console.WriteLine("rectangle = {0}", rectangle);
		}
	}

	public class Derived : Base
	{
	}

	public class Base
	{
	}

	public struct Square
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
			return string.Format("[Width = {0}; Height = {1}]", Width, Height);
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