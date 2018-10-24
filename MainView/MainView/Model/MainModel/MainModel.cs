using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using Goudkoorts.Model.Rails;
using Goudkoorts.Model.TimedEvents;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

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

        public MainModel()
        {
            _switches = new Dictionary<int, ISwitchRail>();
            _warehouses = new Dictionary<Symbols, Warehouse>();
            _docks = new Dictionary<int, Dock>();
            _carts = new List<Cart>();
        }

        public void AddCart(Cart cart)
        {
            _carts.Add(cart);
        }

        public void StartThreads()
        {
            _game = new Thread(() => StartGame(this));
            _game.Name = "Game";
            _game.Start();
            //_counter = new Thread(CreateCounter);
            //_counter.Name = "Counter";
            //_counter.Start();
        }

        private void StartGame(MainModel main)
        {
            Intervals intervals = new Intervals(main);
            intervals.Start();
        }

        private void CreateCounter()
        {
            // counter logic
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
