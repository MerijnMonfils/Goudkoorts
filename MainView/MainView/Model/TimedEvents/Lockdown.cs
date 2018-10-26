using Goudkoorts.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts.Model.TimedEvents
{
    class Lockdown
    {
        private MainModel _main;
        private InputViewVM _input;
        private readonly int _time = 5000;
        private int _counter;

        public Lockdown(MainModel mainModel, InputViewVM input)
        {
            _main = mainModel;
            _input = input;
            _counter = _time;
        }

        public void Start()
        {
            Thread.Sleep(_counter);
            _main.IsLocked = true;
            _input.Redraw(_main);
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
