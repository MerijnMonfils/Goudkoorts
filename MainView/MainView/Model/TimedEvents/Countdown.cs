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
        private int _counter;

        public Countdown()
        {
            _counter = 100000;
        }

        public ThreadStart StartTimer()
        {
            // timer logic
            // Thread.Sleep(_counter);
            // TODO: ASK MAIN TO GET ONE GAME CYCLE/ROUND AND SLEEP
            // AFTERWARDS RESET ISLOCKED TO FALSE AND RESTART THE TIMER
            return null;
        }
    }
}
