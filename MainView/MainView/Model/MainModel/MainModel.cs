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
        private List<Dock> _docks;
        private List<Ship> _ships;
        private List<Cart> _carts;

        private Thread _game, _counter;
        private Lockdown _lockdown;
        private Intervals _intervals;

        private InputViewVM _input;

        public MainModel(InputViewVM input)
        {
            _switches = new Dictionary<int, ISwitchRail>();
            _warehouses = new Dictionary<Symbols, Warehouse>();
            _docks = new List<Dock>();
            _carts = new List<Cart>();
            _ships = new List<Ship>();
            _input = input;
        }

        public void AddCart(Cart cart)
        {
            _carts.Add(cart);
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
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
            _lockdown = new Lockdown(main, input);
            _lockdown.Start();
        }        

        public void AddSwitch(int pos, ISwitchRail obj)
        {
            _switches.Add(pos, obj);
        }

        public void AddWarehouse(Symbols type, Warehouse obj)
        {
            _warehouses.Add(type, obj);
        }

        public void AddDock(Dock obj)
        {
            _docks.Add(obj);
        }
        public ISwitchRail GetSwitch(int pos)
        {
            return _switches[pos];
        }

        public List<Dock> GetAllDocks()
        {
            return _docks;
        }

        public int AmountOfShips()
        {
            int amountOfShips = 0;
            foreach (Ship s in GetAllShips())
                amountOfShips++;
            return amountOfShips;
        }

        public int AmountOfDocks()
        {
            int amountOfShips = 0;
            foreach (Dock d in GetAllDocks())
                amountOfShips++;
            return amountOfShips;
        }

        public Warehouse GetWarehouse(Symbols type)
        {
            return _warehouses[type];
        }

        public List<Cart> GetAllCarts()
        {
            return _carts;
        }

        public List<Ship> GetAllShips()
        {
            return _ships;
        }
    }
}
