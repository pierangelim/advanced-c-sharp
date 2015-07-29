using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Linq
{
	[TestFixture]
	public class GroupBy
	{
		[Test]
		public void GroupingElection()
		{
			var election2015 = new List<Election>
			{
				new Election { Name = "Clinton", Votes = 8 },
				new Election { Name = "Gore", Votes = 4 },
				new Election { Name = "Bush", Votes = 1 },
				new Election { Name = "Obama", Votes = 4 }
			};

			var groups = election2015.GroupBy(x => x.Votes, x => x.Name);
			groups.ToList().ForEach(voteGroup =>
			{
				Console.WriteLine(voteGroup.Key);
				foreach (var candidate in voteGroup)
				{
					Console.WriteLine(candidate);
				}
			});
		}
	}

	public class Election
	{
		public string Name { get; set; }
		public int Votes { get; set; }
	}
}