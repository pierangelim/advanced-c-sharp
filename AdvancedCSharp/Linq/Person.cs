using System;
using System.Collections.Generic;

namespace Linq
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return String.Format("{0} [{1}]", Name, Age);
        }
    }

    public static class People
    {
        public static readonly List<Person> All = new List<Person>
        {
            new Person { Name = "Marco", Age = 18 },
            new Person { Name = "Valentina", Age = 22 },
            new Person { Name = "Matteo", Age = 16 },
            new Person { Name = "Alessia", Age = 13 },
            new Person { Name = "Carlotta", Age = 21 },
            new Person { Name = "Gianni", Age = 23 },
            new Person { Name = "Paola", Age = 17 },
            new Person { Name = "Antonio", Age = 30 },
            new Person { Name = "Marina", Age = 25 },
            new Person { Name = "Carlo", Age = 27 },
        };
    }

}