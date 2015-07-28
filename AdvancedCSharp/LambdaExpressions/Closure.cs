using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LambdaExpressions
{
    [TestFixture]
    public class Closure
    {
        [Test]
        public void OuterVariables()
        {
            //Outer variables referenced by a lambda expression are called captured variables. A
            //lambda expression that captures variables is called a closure.

            const int factor = 2;

            Func<int, int> multiplier = n => n * factor;

            Console.WriteLine(multiplier(3));
        }

        [Test]
        public void OuterVariablesEvalutaion()
        {
            var factor = 0;
            Func<int, int> multiplier = n => n * factor;

            factor = 2;
            Console.WriteLine(multiplier(3));

            factor = 3;
            Console.WriteLine(multiplier(3));

            factor = 10;
            Console.WriteLine(multiplier(3));
        }

        [Test]
        public void ChangeOuterVariables()
        {
            var seed = 0;

            Func<int> natural = () => seed++;

            Console.WriteLine(natural());
            Console.WriteLine(natural());
            Console.WriteLine(seed);
        }

        [Test]
        public void Loop()
        {
            var actions = new List<Action>();

            for (var i = 0; i < 3; i++)
                actions.Add(() => Console.Write("Index: " + i));

            foreach (var action in actions)
            {
                action();
            }
        }

        [Test]
        public void IndexLoop()
        {
            var actions = new List<Action>();

            for (var i = 0; i < 3; i++)
            {
                var currentIndex = i;
                actions.Add(() => Console.Write(currentIndex));
            }

            foreach (var action in actions)
            {
                action();
            }
        }
    }
}