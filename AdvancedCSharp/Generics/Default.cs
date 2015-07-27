using System;
using NUnit.Framework;

namespace Generics
{
    [TestFixture]
    public class Default
    {
        [Test]
        public void Values()
        {
            var a = default(int);
            Assert.That(a, Is.EqualTo(0));

            var b = default(DateTime);
            Assert.That(b, Is.EqualTo(new DateTime()));

            var c = default(string);
            Assert.That(c, Is.Null);

            var d = default(object);
            Assert.That(d, Is.Null);
        }

        [Test]
        public void Factory()
        {
            Assert.That(GetDefault<int>(), Is.EqualTo(0));
            Assert.That(GetDefault<DateTime>(), Is.EqualTo(new DateTime()));

            Assert.That(GetDefault<string>(), Is.Null);
            Assert.That(GetDefault<object>(), Is.Null);
        }

        private static T GetDefault<T>()
        {
            return default(T);
        }
    }
}