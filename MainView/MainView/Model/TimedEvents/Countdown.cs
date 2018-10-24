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
        private readonly int _time = 5000;
        private int _counter;

        public Countdown(MainModel mainModel)
        {
            _main = mainModel;
            _counter = _time;
        }

        public void Start()
        {
            Thread.Sleep(_counter);
            _main.IsLocked = true;
            Thread.Sleep(_main.GetRoundTime());
            _main.IsLocked = false;
            Restart();
        }

        private void Restart()
        {
            _counter = _time;
            Start();
        }
    }
}
