using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts.Model.TimedEvents
{
    class Countdown
    {
        private MainModel _main;

        private int _counter;

        public Countdown(MainModel main)
        {
            _main = main;
            _counter = 100000;
        }

        public ThreadStart StartTimer()
        {
            // timer logic
            Thread.Sleep(_counter);
            _main.IsLocked = true;
            // TODO: ASK MAIN TO GET ONE GAME CYCLE/ROUND AND SLEEP
            // AFTERWARDS RESET ISLOCKED TO FALSE AND RESTART THE TIMER
            return null;
        }
    }
}
