using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class Equals
	{
		[Test]
		public void AreDifferent()
		{
			Person matteo = new Person("Matteo", "Pierangeli", 13);
			Person anotherMatteo = new Person("Matteo", "Pierangeli", 13);

			//Assert.AreEqual(anotherMatteo, matteo);
			Assert.AreNotEqual(anotherMatteo, matteo);
		}

		[Test]
		public void AreEquals()
		{
			PersonExt matteo = new PersonExt("Matteo", "Pierangeli", 13);
			PersonExt anotherMatteo = new PersonExt("Matteo", "Pierangeli", 13);

			Assert.AreEqual(anotherMatteo, matteo);
		}
	}

	internal class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }

		public Person(string fName, string lName, int personAge)
		{
			FirstName = fName;
			LastName = lName;
			Age = personAge;
		}
	}

	internal class PersonExt
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }

		public PersonExt(string fName, string lName, int personAge)
		{
			FirstName = fName;
			LastName = lName;
			Age = personAge;
		}

		public override bool Equals(object obj)
		{
			if (obj is PersonExt && obj != null)
			{
				PersonExt temp = (PersonExt)obj;
				if (temp.FirstName == this.FirstName
					&& temp.LastName == this.LastName
					&& temp.Age == this.Age)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}
}
