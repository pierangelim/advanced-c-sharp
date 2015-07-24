using System;
using NUnit.Framework;

namespace Generics
{
    public class Stack<T>
    {
        private int _position;
        private readonly T[] _data = new T[100];

        public void Push(T obj)
        {
            _data[_position++] = obj;
        }

        public T Pop()
        {
            return _data[--_position];
        }
    }

    public class IntStack : Stack<int> { }

    [TestFixture]
    public class Classes
    {
        [Test]
        public void StringStack()
        {
            var stack = new Stack<string>();

            stack.Push("One");
            stack.Push("Two");

            Assert.That(stack.Pop(), Is.EqualTo("Two"));
            Assert.That(stack.Pop(), Is.EqualTo("One"));
        }

        [Test]
        public void TypeStack()
        {
            var stack = new Stack<Type>();

            stack.Push(typeof(Int32));
            stack.Push(typeof(String));

            Assert.That(stack.Pop(), Is.EqualTo(typeof(String)));
            Assert.That(stack.Pop(), Is.EqualTo(typeof(Int32)));
        }

        [Test]
        public void IntStack()
        {
            var stack = new IntStack();

            stack.Push(10);
            stack.Push(20);

            Assert.That(stack.Pop(), Is.EqualTo(20));
            Assert.That(stack.Pop(), Is.EqualTo(10));
        }
    }
}