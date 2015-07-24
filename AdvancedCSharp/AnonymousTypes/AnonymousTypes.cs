using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AnonymousTypes
{
    [TestFixture]
    public class  AnonymousTypes
    {
        [Test]
        public void Base()
        {
            var car = new { Manufacturer = "BMW", Color = "Black", Speed = 90 };

            Assert.That(car.Manufacturer, Is.EqualTo("BMW"));
            Assert.That(car.Color, Is.EqualTo("Black"));
            Assert.That(car.Speed, Is.EqualTo(90));
        }

        [Test]
        public void Complex()
        {
            var car = new { Manufacturer = new Manufacturer("BMW"), Color = new Color("Black"), Speed = 90 };

            Assert.That(car.Manufacturer, Is.EqualTo(new Manufacturer("BMW")));
            Assert.That(car.Color, Is.EqualTo(new Color("Black")));
            Assert.That(car.Speed, Is.EqualTo(90));
        }

        [Test]
        public void ComplexAnonymousType()
        {
            var car = new { Manufacturer = new Manufacturer("BMW"), Color = new Color("Black"), Speed = new { Value = 90, Unit = "mph"} };

            Assert.That(car.Manufacturer, Is.EqualTo(new Manufacturer("BMW")));
            Assert.That(car.Color, Is.EqualTo(new Color("Black")));
            Assert.That(car.Speed.Value, Is.EqualTo(90));
            Assert.That(car.Speed.Unit, Is.EqualTo("mph"));
        }

        [Test]
        public void HandlingAnonymousType()
        {
            var anonType = Create("Mario", "Rossi");

            var handler = (dynamic)anonType;

            Assert.That(handler.Name, Is.EqualTo("Mario"));
            Assert.That(handler.Name, Is.EqualTo("Mario"));
        }

        private static object Create(string name, string surname)
        {
            return new { Name = name, Surname = surname };
        }
    }
}
