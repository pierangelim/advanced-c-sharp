using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class Operators
	{
		[Test]
		public void Operations()
		{
			var point1 = new Point(1, 2);
			var point2 = new Point(3, 4);

			var point3 = point1 + point2;
			Console.WriteLine("SUM: {0}", point3);

			var point4 = point2 - point1;
			Console.WriteLine("SUBSTRACTION: {0}", point4);
		}

		[Test]
		public void Operations2()
		{
			var point1 = new Point(1, 2);
			var point2 = new Point(3, 4);

			point1 += point2;
			Console.WriteLine("SUM: {0}", point1);

			point1 -= point2;
			Console.WriteLine("SUBSTRACTION: {0}", point1);
		}
	}

	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int xPos, int yPos)
		{
			X = xPos;
			Y = yPos;
		}

		public override string ToString()
		{
			return string.Format("[{0}, {1}]", X, Y);
		}

		//keyword operator can be used only with static and it can be used for overload the operator
		public static Point operator +(Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point operator -(Point p1, Point p2)
		{
			return new Point(p1.X - p2.X, p1.Y - p2.Y);
		}
	}
}