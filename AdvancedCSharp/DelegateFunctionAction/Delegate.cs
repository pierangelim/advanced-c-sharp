using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace DelegateFunctionAction
{
	/*
	 * in .NET a delegate is a type-safe object that points to another method (static and not).
	 * you must define the delegate to match the signature of the method(s) it will point to.
	 * it's composed by 3 pieces of information: address, parameters and return type
	*/

	[TestFixture]
	public class Delegate
	{
		private delegate int BinaryOp(int x, int y); // the compiler generate a sealed class with 3 method: Invoke, BeginInvoke and EndInvoke
		/*
		    public delegate int BinaryOp(int x, int y);

			sealed class BinaryOp : System.MulticastDelegate
			{
				public int Invoke(int x, int y);
				public IAsyncResult BeginInvoke(int x, int y, AsyncCallback cb, object state);
				public int EndInvoke(IAsyncResult result);
			}
		*/
		[Test]
		public void AddOperation()
		{
			var d = new BinaryOp(SimpleMath.Add); //static method
			//var d2 = new BinaryOp(SimpleMath.SquareNumber); // <-- compile-time error! it is type safe!

			DisplayDelegateInfo(d);
			Console.WriteLine("10 + 10 is {0}", d(10, 10));
			Console.WriteLine("10 + 10 is {0}", d.Invoke(10, 10)); // it is equivalent
		}

		[Test]
		public void SubOperation()
		{
			var math = new SimpleMath();
			var d = new BinaryOp(math.Subtract); //if method is not static I've to create an istance of class to create the delegate

			DisplayDelegateInfo(d);
			Console.WriteLine("10 - 3 is {0} (due to an error of calculator =] )", d(10, 3));
		}

		private delegate double BinaryOpDouble(int x, int y);
		[Test]
		public void SubWithErrOperation()
		{
			var math = new SimpleMath();
			var d = new BinaryOpDouble(math.SubtractWithError);

			DisplayDelegateInfo(d);
			Console.WriteLine("10 - 3 is {0} (due to an error of calculator =] )", d(10, 3));
		}

		private delegate void Writer(string text);
		[Test]
		public void Multicast()
		{
			var logger = new Writer(ConsoleLogger);
			logger += FileLogger; //delegate instances have multicast capability. can be used by the overloaded += operator

			DisplayDelegateInfo(logger);

			logger.Invoke("-------------------------------------");
			for (var i = 0; i <= 100; i+=10)
			{
				Thread.Sleep(500);
				var text = String.Format("[{0}] - {1}% complete", DateTime.Now, i);
				logger.Invoke(text);
			}
		}

		private static void ConsoleLogger(string text)
		{
			Console.WriteLine(text);
		}

		private static void FileLogger(string text)
		{
			var f = new FileInfo("log.txt");
			using (var w = f.AppendText())
			{
				w.WriteLine(text);
			}
		}

		private delegate T BinOp<T>(T x);
		[Test]
		public void Calc()
		{
			var square = new BinOp<long>(SimpleMath.SquareNumber);
			var factorial = new BinOp<int>(SimpleMath.Factorial);

			DisplayDelegateInfo(square);
			DisplayDelegateInfo(factorial);
			
			const long longNumber = 77214L;
			const int number = 7;
			Console.WriteLine("square of {0}: {1}", longNumber, square(longNumber));
			Console.WriteLine("factorial of {0}: {1}", number, factorial.Invoke(number));
		}

		private static void DisplayDelegateInfo(System.Delegate delObj)
		{
			foreach (System.Delegate d in delObj.GetInvocationList())
			{
				Console.WriteLine("Method Name: {0}", d.Method);
				
				// is used only only when the delegate points to a non-static method in order to have a reference.
				// for example for SimpleMath.SubtractWithError we have a target reference to SimpleMath (otherwise it would be impossible to access to a member variable)
				Console.WriteLine("Type Name: {0}", d.Target);
				
				Console.WriteLine(string.Join(", " , d.GetMethodInfo().GetParameters().Select(x => string.Format("{0} {1}", x.Name, x.ParameterType))));
			}
		}
	}
}