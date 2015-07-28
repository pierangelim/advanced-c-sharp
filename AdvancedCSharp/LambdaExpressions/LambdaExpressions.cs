using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LambdaExpressions
{
    [TestFixture]
    public class LambdaExpressions
    {
        [Test]
        public void FunctionAndDelegate()
        {
            Func<int, int> sqr = delegate(int x) { return x * x; };

            Assert.That(sqr(10), Is.EqualTo(100));
        }

        [Test]
        public void LambdaExpression()
        {
            Func<int, int> sqr = x => x * x;

            Assert.That(sqr(10), Is.EqualTo(100));
        }

        [Test]
        public void MoreParametersFunction()
        {
            Func<int, int, int> sum = (a, b) => a + b;

            Console.WriteLine("Sum : " + sum(5, 5));
        }

        [Test]
        public void ComplexTypesFunction()
        {
            Func<DateTime, string> toLocal = str => str.ToString("dd MMM yyyy HH:mm:ss");

            var dateTime = new DateTime(2015, 7, 31, 10, 20, 45);
            Console.WriteLine(toLocal(dateTime));
        }

        [Test]
        public void NoParametersFunction()
        {
            Func<string> createGuid = () => Guid.NewGuid().ToString().Replace("-", String.Empty);

            Console.WriteLine(createGuid());
        }

        [Test]
        public void MultiLine()
        {
            Func<string> createGuid = () =>
            {
                var guid = Guid.NewGuid().ToString();
                return guid.Replace("-", String.Empty);
            };

            Console.WriteLine(createGuid());
        }


        [Test]
        public void Action()
        {
            Action<string, DateTime> log = (message, timestamp) => Console.WriteLine("{0}: {1}", timestamp, message);

            log("Starting appplication ...", DateTime.Now);
            log("Hello World!", DateTime.Now);
            log("Stopping application ...", DateTime.Now);
        }

        [Test]
        public void LambdaAsParameter()
        {
            var list = Enumerable.Range(0, 50).ToList();

            var result = list.FindAll(i => (i % 2 == 0) && (i % 3 == 0));

            var output = String.Join(", ", result);
            Console.WriteLine(output);
        }

        [Test]
        public void DeferredExecution()
        {
            Process(10000, l => Console.WriteLine("Completed in {0}", l));
            Process(50000, l => Console.WriteLine("Completed in {0}", l));
            Process(100000, l => Console.WriteLine("Completed in {0}", l));
        }

        private static void Process(int count, Action<long> onComplete)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (var i = 0; i < count; i++)
            {
                Thread.Yield();
            }
            stopwatch.Stop();

            onComplete(stopwatch.ElapsedMilliseconds);
        }
    }
}
