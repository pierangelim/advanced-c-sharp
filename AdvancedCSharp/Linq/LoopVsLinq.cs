using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
	[TestFixture]
	public class LoopVsLinq
	{
		private readonly string[] _currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

		[Test]
		public void Loop()
		{
            var finalVideoGames = new List<FinalGames>();

			var gamesWithSpaces = new string[5];
			for (var i = 0; i < _currentVideoGames.Length; i++)
			{
				if (_currentVideoGames[i].Contains(" "))
				{
					gamesWithSpaces[i] = _currentVideoGames[i];
				}
			}

			Array.Sort(gamesWithSpaces);

			foreach (var s in gamesWithSpaces)
			{
				if (s != null)
					finalVideoGames.Add(new FinalGames
					{
						Name = s,
						Lenght = s.Length
					});
			}

			finalVideoGames.ForEach(x => Console.WriteLine("VideoGame: {0} (lenght: {1})", x.Name, x.Lenght));
		}

		/*
		 * LINQ, or Language Integrated Query, is a set of language and framework features for writing structured type-safe queries over local object collections and remote data sources.
		 * LINQ works on IEnumerable<T>
		 * Fluent syntax is the most flexible and fundamental (thanks to extension methods)
		 * 
		 * LINQ to Objects:  queries to arrays and collections.
		 * LINQ to XML: to manipulate and query XML documents.
		 * LINQ to DataSet: queries to ADO.NET DataSet objects.
		 * LINQ to Entities: queries within the ADO.NET Entity Framework (EF) API.
		 * Parallel LINQ (a.k.a. PLINQ): for parallel processing of data returned from a LINQ query.
		*/
		[Test]
		public void Linq()
		{
		    var finalVideoGames = _currentVideoGames.Where(x => x.Contains(" "))
		        .OrderBy(x => x)
		        .Select(x => new FinalGames { Name = x, Lenght = x.Length })
		        .ToList();

            finalVideoGames.ForEach(x => Console.WriteLine("VideoGame: {0} (lenght: {1})", x.Name, x.Lenght));
		}
	}

	internal class FinalGames
	{
		public string Name { get; set; }
		public int Lenght { get; set; }
	}
}
