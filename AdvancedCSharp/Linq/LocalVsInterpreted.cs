using System;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class LocalVsInterpreted
    {
        //LINQ provides two parallel architectures: local queries for local object collections,
        //and interpreted queries for remote data sources.

        //Local Queries: IEnumerable<T>
        //Interpreted Queries: IQueryable<T>

        //By contrast, interpreted queries are descriptive. They operate over sequences that
        //implement IQueryable<T>, and they resolve to the query operators in the
        //Queryable class, which emit expression trees that are interpreted at runtime.

        //There are two IQueryable<T> implementations in the .NET Framework:
        //• LINQ to SQL
        //• Entity Framework (EF)

        [Test]
        public void Queryable()
        {
            var source = Enumerable.Range(0, 10).AsQueryable();

            var queryable = source
                .Where(x => x % 2 == 0)
                .Select(x => x * x);

            var dataSet1 = queryable.ToList(); //Query execution on database

            var dataSet2 = queryable.OrderBy(x => x).ToList(); //Query execution on database (.. once again!)

            var size = queryable.Count(x => x != 0); //Query execution on database (... third time!)
        }

        [Test]
        public void AsEnumerable()
        {
            var source = Enumerable.Range(0, 10).AsQueryable();

            //This part will be executed on database;
            var queryable = source          
                .Where(x => x % 2 == 0)
                .Select(x => x * x);

            //This part will be executed in memory
            var enumerable = queryable.AsEnumerable()
                .Where(x => Math.Sign(x) == 0)
                .OrderBy(x => x);


            var dataSet1 = queryable.ToList(); //Execution: half on database, half in memory!

            var dataSet2 = queryable.OrderBy(x => x).ToList(); //Execution: half on database, half in memory (.. once again!)
        }
    }
}