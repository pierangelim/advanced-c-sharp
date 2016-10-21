using System;
using NUnit.Framework;

namespace Events
{
    [TestFixture]
    public class DelegateEvents
    {
        [Test]
        public void Events()
        {
            var button = new DelegateButton();

            button.Click += delegate { Console.WriteLine("Pressed!"); };

            button.Press();
        }

        [Test]
        public void EncapsulationIssue_1()
        {
            var button = new DelegateButton();

            button.Click += delegate { Console.WriteLine("Pressed!"); };

            //Malicious Code
            button.Click.Invoke();
        }

        [Test]
        public void EncapsulationIssue_2()
        {
            var button = new DelegateButton();

            button.Click += delegate { Console.WriteLine("Do Something Important"); };

            //Malicious Code
            button.Click = delegate { Console.WriteLine("Do Nothing"); };

            button.Press();
        }
    }

    public class DelegateButton
    {
        public Click Click;

        public void Press()
        {
            if (Click != null)
                Click.Invoke();
        }
    }
}