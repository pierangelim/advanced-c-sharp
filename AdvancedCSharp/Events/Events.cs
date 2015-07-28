using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Events
{
    [TestFixture]
    public class Events
    {
        [Test]
        public void Event()
        {
            var button = new Button();

            button.Click += delegate { Console.WriteLine("Pressed!"); };

            button.Press();
        }

        [Test]
        public void UsingAction()
        {
            var textBox = new TextBox();

            textBox.TextChanged += delegate(string s) { Console.WriteLine("Text Changed: " + s); };

            textBox.SetText("Hello World!");
        }

        [Test]
        public void MemoryLeak()
        {
            var textBox = new TextBox();

            textBox.TextChanged += delegate(string s) { Console.WriteLine("Text Changed: " + s); };

            textBox.SetText("Hello World!");

            textBox.TextChanged -= delegate(string s) { Console.WriteLine("Text Changed: " + s); };
        }

        [Test]
        public void NoMemoryLeak()
        {
            var textBox = new TextBox();

            Action<string> onTextChanged = delegate(string s) { Console.WriteLine("Text Changed: " + s); };

            textBox.TextChanged += onTextChanged;

            textBox.SetText("Hello World!");

            textBox.TextChanged -= onTextChanged;
        }
    }

    public class Button
    {
        public event Click Click;

        public void Press()
        {
            if (Click != null)
                Click.Invoke();
        }
    }

    public class TextBox
    {        
        public event Action<String> TextChanged;

        public string Text { get; private set; }

        public void SetText(string text)
        {
            Text = text;

            if (TextChanged != null)
                TextChanged(Text);
        }
    }
}
