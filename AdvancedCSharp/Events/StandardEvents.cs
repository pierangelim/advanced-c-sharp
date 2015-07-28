using System;
using NUnit.Framework;

namespace Events
{
    [TestFixture]
    public class StandardEvents
    {

        [Test]
        public void EventArgs()
        {
            var timer = new Timer() { Name = "MyTimer"};

            timer.Starting += TimerOnStarting;

            timer.Start();
        }

        [Test]
        public void CustomEventArgs()
        {
            var timer = new Timer() { Name = "MyTimer" };

            timer.Stopping += TimerOnStopping;

            timer.Stop();
        }

        private void TimerOnStarting(object sender, EventArgs args)
        {
            Console.WriteLine("Timer {0} starting...", ((Timer)sender).Name);
        }

        private void TimerOnStopping(object sender, TimerEventArgs args)
        {
            Console.WriteLine("Timer {0} stopping. Elpased {1}!", ((Timer)sender).Name, args.Elapsed);
        }
    }

    public class Timer
    {
        
        public event EventHandler<EventArgs> Starting;
        public event EventHandler<TimerEventArgs> Stopping;

        public string Name { get; set; }

        public void Start()
        {
            if(Starting != null)
                Starting.Invoke(this, new EventArgs());
        }

        public void Stop()
        {
            if (Stopping != null)
                Stopping.Invoke(this, new TimerEventArgs(2500));
        }
    }

    public class TimerEventArgs : EventArgs
    {
        private readonly int _elapsed;

        public TimerEventArgs(int elapsed)
        {
            _elapsed = elapsed;
        }

        public int Elapsed
        {
            get { return _elapsed; }
        }
    }
}