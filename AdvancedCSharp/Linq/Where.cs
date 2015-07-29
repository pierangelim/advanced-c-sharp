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

            Print(even);
        }

        [Test]
        public void Copy()
        {
            var enumerable = Enumerable.Range(0, 10);

            var bigNumbers = enumerable.Where(i => i > 5);
            
            Print(bigNumbers);
            Print(enumerable);
        }

        [Test]
        public void ComplexTypes()
        {
            var people = People.All.Where(p => p.Name.StartsWith("M"));
            Print(people);

            var seniors = People.All.Where(p => p.Age >= 18);
            Print(seniors);
        }

        [Test]
        public void IndexedWhere()
        {
            var oddPeople = People.All.Where((p, index) => index % 2 != 0);

            Print(oddPeople);
        }

        [Test]
        public void CombineWhere()
        {
            var pepole = People.All
                .Where(p => p.Age > 20)
                .Where(p => p.Name.StartsWith("C"))
                .Where(p => p.Name.Length == 8);

            Print(pepole);
        }

        private static void Print<T>(IEnumerable<T> enumerbale, string separator = ", ")
        {
            Console.WriteLine(String.Join(separator, enumerbale));
        }
    }
}
