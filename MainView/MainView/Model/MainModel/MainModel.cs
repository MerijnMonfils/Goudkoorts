using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using Goudkoorts.Model.Rails;
using Goudkoorts.Model.TimedEvents;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Goudkoorts.ViewModel;

namespace Goudkoorts.Model
{
    class MainModel
    {
        public IRail EndOflevelLink { get; set; }
        public bool IsLocked { get; set; }

        private Dictionary<int, ISwitchRail> _switches;
        private Dictionary<Symbols, Warehouse> _warehouses;
        private Dictionary<int, Dock> _docks;
        private List<Cart> _carts;

        private Thread _game, _counter;
        private Countdown _countdown;
        private Intervals _intervals;

        private InputViewVM _input;

        public MainModel(InputViewVM input)
        {
            _switches = new Dictionary<int, ISwitchRail>();
            _warehouses = new Dictionary<Symbols, Warehouse>();
            _docks = new Dictionary<int, Dock>();
            _carts = new List<Cart>();

            _input = input;
        }

        public void AddCart(Cart cart)
        {
            _carts.Add(cart);
        }

        public void StartThreads()
        {
            _game = new Thread(() => StartGame(this, _input));
            _game.Name = "Game";
            _game.Start();
            _counter = new Thread(() => CreateCounter(this, _input));
            _counter.Name = "Counter";
            _counter.Start();
        }

        private void StartGame(MainModel main, InputViewVM input)
        {
            _intervals = new Intervals(main, input);
            _intervals.Start();
        }

        public int GetRoundTime()
        {
            return _intervals.GetTime();
        }

        private void CreateCounter(MainModel main, InputViewVM input)
        {
            _countdown = new Countdown(main, input);
            _countdown.Start();
        }        

        public void AddSwitch(int pos, ISwitchRail obj)
        {
            _switches.Add(pos, obj);
        }

        public void AddWarehouse(Symbols type, Warehouse obj)
        {
            _warehouses.Add(type, obj);
        }

        public void AddDock(int pos, Dock obj)
        {
            _docks.Add(pos, obj);
        }
        public ISwitchRail GetSwitch(int pos)
        {
            return _switches[pos];
        }

        public Dock GetDock(int pos)
        {
            return _docks[pos];
        }

        public Warehouse GetWarehouse(Symbols type)
        {
            return _warehouses[type];
        }

        public List<Cart> GetAllCarts()
        {
            return _carts;
        }
    }
}
