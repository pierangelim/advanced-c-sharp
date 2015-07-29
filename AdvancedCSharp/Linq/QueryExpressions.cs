using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Linq.Expressions;
using System.Linq;


namespace Linq
{
    [TestFixture]
    public class QueryExpressions
    {
        [Test]
        public void Basic()
        {
            var result = from person in People.All
                where person.Age > 18
                where person.Age < 25
                orderby person.Age
                select person.Name;

            Print(result);
        }

        [Test]
        public void LetKeyword()
        {
            var result = from person in People.All
                let birthDate = DateTime.Now.AddYears(-person.Age).Year
                where birthDate > 1995
                select new
                {
                    Id = String.Format("[{0}]", person.Name),
                    BirthDate = birthDate
                };

            Print(result);
        }

        [Test]
        public void IntoKeyword()
        {
            var result = from person in People.All
                where person.Name.StartsWith("M")
                select new
                {
                    Id = String.Format("[{0}]", person.Name),
                    Age = person.Age
                }
                into record
                where record.Age > 20
                select record.Id;
                    
            Print(result);
        }

        private static void Print<T>(IEnumerable<T> enumerbale, string separator = ", ")
        {
            Console.WriteLine(String.Join(separator, enumerbale));
        }
    }
}