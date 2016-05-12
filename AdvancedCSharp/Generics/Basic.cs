using System;
using NUnit.Framework;

namespace Generics
{
    [TestFixture]
    public class Basic
    {
        private static void SwapObject(ref object left, ref object right)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        [Test]
        public void SwapIntObjects()
        {
            var a = 2;
            var b = 4;

            object aObj = a;
            object bObj = b;

            SwapObject(ref aObj, ref bObj);

            Assert.IsTrue((int)aObj == 4);
            Assert.IsTrue((int)bObj == 2);
        }

        [Test]
        public void SwapDateTimeObjects()
        {
            var a = new DateTime(2015, 12, 25);
            var b = new DateTime(2015, 8, 15);

            object aObj = a;
            object bObj = b;

            SwapObject(ref aObj, ref bObj);

            Assert.IsTrue((DateTime)aObj == new DateTime(2015, 8, 15));
            Assert.IsTrue((DateTime)bObj == new DateTime(2015, 12, 25));
        }

        //Inheritance expresses reusability with a base type, generics express reusability with a “template” that contains “placeholder” types.
        //Generics, when compared to inheritance, can increase type safety and reduce casting and boxing.

        private static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        [Test]
        public void SwapInts()
        {
            var a = 2;
            var b = 4;

            Swap(ref a, ref b);

            Assert.IsTrue(a == 4);
            Assert.IsTrue(b == 2);
        }

        [Test]
        public void SwapDateTims()
        {
            var a = new DateTime(2015, 12, 25);
            var b = new DateTime(2015, 8, 15);

            Swap(ref a, ref b);

            Assert.IsTrue(a == new DateTime(2015, 8, 15));
            Assert.IsTrue(b == new DateTime(2015, 12, 25));
        }
    }
}

