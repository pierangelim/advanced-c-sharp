using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class CastOperators
	{
		/*
		 * In terms of the intrinsic numerical types, an explicit conversion is required
		 * when you attempt to store a larger value in a smaller container, as this could result in a loss of data
		 * Conversely, an implicit conversion happens automatically when you attempt
		 * to place a smaller type in a destination type that will not result in a loss of data
		*/
		[Test]
		public void NumericalCast()
		{
			int a = 123;
			Console.WriteLine("int a: {0}", a);

			double b = a; // Implicit conversion from int to long.
			Console.WriteLine("double b converted without loss from int a: {0}", b);
			b += 0.456;
			Console.WriteLine("double b: {0}", b);

			int c = (int)b; // Explicit conversion from long to int.
			Console.WriteLine("int c converted with loss from double b: {0}", c);
		}

		private class Base
		{
			public int p1 { get; set; }
		}

		private class Derived : Base
		{
			public int p2 { get; set; }

			public Derived(int p2)
			{
				this.p2 = p2;
				p1 = p2 * 2;
			}
		}

		//Class types may be related by classical inheritance (the “is-a” relationship).
		//In this case, the C# conversion process allows you to cast up and down the class hierarchy.
		[Test]
		public void HierarchyCast()
		{
			Base myBaseType;
			myBaseType = new Derived(33); // Implicit cast between derived to base.
			Console.WriteLine("base.p1: {0}", myBaseType.p1);
			//myBaseType.p2; --> compile error because Base is narrower than Derived

			Derived myDerivedType = (Derived)myBaseType; // Must explicitly cast to store Base reference in Derived type.
			Console.WriteLine("derivate.p1: {0}", myDerivedType.p1);
			Console.WriteLine("derivate.p2: {0}", myDerivedType.p2);
		}

		//However, what if you have two class types in different hierarchies
		//with no common parent (other than System.Object) that require conversions?
		[Test]
		public void ExplicitConversion()
		{
			var square = (Square)90; //Implicit conversion from Int32 to Square
			DrawSquare(square);

			var side = (int)square; //Implicit conversion from Square to Int32
			Console.WriteLine("Side length of square = {0}", side);
		}

		[Test]
		public void ImplicitConversion()
		{
			var square = new Square(7);

			Rectangle rectangle = square; //Implicit conversion from Square to Rectangle
			DrawRectangle(rectangle);
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

	public class Square
	{
		public int Length { get; private set; }

		public Square(int length)
		{
			Length = length;
		}

		public override string ToString()
		{
			return string.Format("[Length = {0}]", Length);
		}

		public static explicit operator Square(int sideLength)
		{
			return new Square(sideLength);
		}

		public static explicit operator int(Square s)
		{
			return s.Length;
		}
	}

	public class Rectangle
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Rectangle(int width, int height)
		{
			Width = width;
			Height = height;
		}
		public override string ToString()
		{
			return string.Format("[Width = {0}; Height = {1}]", Width, Height);
		}

		public static implicit operator Rectangle(Square s)
		{
			return new Rectangle(s.Length, s.Length * 2);
		}
	}
}