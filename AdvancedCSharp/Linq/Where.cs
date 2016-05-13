using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class Where
    {
        [Test]
        public void Basic()
        {
            var enumerable = Enumerable.Range(0, 10);

            var even = enumerable.Where(i => i % 2 == 0);

            even.Print();
        }

        [Test]
        public void Copy()
        {
            var enumerable = Enumerable.Range(0, 10);

            var bigNumbers = enumerable.Where(i => i > 5);

            bigNumbers.Print();
            enumerable.Print();
        }

        [Test]
        public void ComplexTypes()
        {
            var people = People.All.Where(p => p.Name.StartsWith("M"));
            people.Print();

            var seniors = People.All.Where(p => p.Age >= 18);
            seniors.Print();
        }

        [Test]
        public void IndexedWhere()
        {
            var oddPeople = People.All.Where((p, index) => index % 2 != 0);

            oddPeople.Print();
        }

        [Test]
        public void CombineWhere()
        {
            var pepole = People.All
                .Where(p => p.Age > 20)
                .Where(p => p.Name.StartsWith("C"))
                .Where(p => p.Name.Length == 8);

            pepole.Print();
        }
    }
}
