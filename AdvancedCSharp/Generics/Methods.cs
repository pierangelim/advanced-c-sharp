using System;
using System.Collections;
using System.IO;
using System.Security.AccessControl;
using NUnit.Framework;

namespace Generics
{
    [TestFixture]
    public class Methods
    {
        enum Colors
        {
            Blue,
            Green
        }

        enum Sports
        {
            Volley,
            Basket
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        [Test]
        public void RetrunValue()
        {
            Assert.IsTrue(ParseEnum<Colors>("Blue") == Colors.Blue);
            Assert.IsTrue(ParseEnum<Colors>("Green") == Colors.Green);

            Assert.IsTrue(ParseEnum<Sports>("Basket") == Sports.Basket);
            Assert.IsTrue(ParseEnum<Sports>("Volley") == Sports.Volley);
        }


        private static bool CompareAsString<T1, T2>(T1 a, T2 b)
        {
            return a.ToString() == b.ToString();
        }

        [Test]
        public void MultipleTypes()
        {
            Assert.IsTrue(CompareAsString("01/01/2015 00:00:00", new DateTime(2015, 1, 1)));
            Assert.IsTrue(CompareAsString(new Hashtable(), "System.Collections.Hashtable"));
            Assert.IsTrue(CompareAsString("12", 12));
        }
    }
}