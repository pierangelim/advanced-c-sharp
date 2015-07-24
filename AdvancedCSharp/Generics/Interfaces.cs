using NUnit.Framework;

namespace Generics
{

    public interface IComparable<T>
    {
        int CompareTo(T other);
    }

    public class Age : IComparable<Age>
    {
        private readonly int _value;

        public Age(int value)
        {
            _value = value;
        }

        public int CompareTo(Age other)
        {
            return _value.CompareTo(other._value);
        }
    }


    public interface IComparer<T>
    {
        int Compare(T a, T b);
    }

    public class AgeComparer : IComparer<Age>
    {
        public int Compare(Age a, Age b)
        {
            return a.CompareTo(b);
        }
    }

    public class InverseAgeComparer : IComparer<Age>
    {
        public int Compare(Age a, Age b)
        {
            return b.CompareTo(a);
        }
    }

    [TestFixture]
    public class Interfaces
    {
        [Test]
        public void Compare()
        {
            var a = new Age(20);
            var b = new Age(40);

            Assert.That(a.CompareTo(a), Is.EqualTo(0));
            Assert.That(b.CompareTo(a), Is.EqualTo(1));
            Assert.That(a.CompareTo(b), Is.EqualTo(-1));
        }

        [Test]
        public void MoreDifficult()
        {
            var a = new Age(20);
            var b = new Age(40);

            var comparer = new AgeComparer();

            Assert.That(Compare(a, a, comparer), Is.EqualTo(0));
            Assert.That(Compare(b, a, comparer), Is.EqualTo(1));
            Assert.That(Compare(a, b, comparer), Is.EqualTo(-1));

            var inverseComparer = new InverseAgeComparer();

            Assert.That(Compare(a, a, inverseComparer), Is.EqualTo(0));
            Assert.That(Compare(b, a, inverseComparer), Is.EqualTo(-1));
            Assert.That(Compare(a, b, inverseComparer), Is.EqualTo(1));
        }

        private int Compare<T>(T a, T b, IComparer<T> comparer)
        {
            return comparer.Compare(a, b);
        }
    }
}
