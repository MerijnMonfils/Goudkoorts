using System;
using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using Goudkoorts.Model.TimedEvents;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;

namespace Goudkoorts.Model
{
    class MainModel
    {
        public IRail EndOflevelLink { get; set; }
        public bool IsLocked { get; set; }

        private Dictionary<int, ISwitchRail> _switches;
        private Dictionary<Symbols, Warehouse> _warehouses;
        private Dictionary<int, Dock> _docks;
        private readonly Random _random = new Random();

        public MainModel()
        {
            _switches = new Dictionary<int, ISwitchRail>();
            _warehouses = new Dictionary<Symbols, Warehouse>();
            _docks = new Dictionary<int, Dock>();
        }

        public void AddSwitch(int pos, ISwitchRail obj)
        {
            _switches.Add(pos, obj);
        }

        public void StartGame()
        {
          GetWarehouse().SpawnCarts();
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

        public Warehouse GetWarehouse()
        {
            Symbols type = new Symbols();
            
            int letter = _random.Next(1, 4);

            switch (letter)
            {
                case 1:
                    type = Symbols.WarehouseA;
                    break;
                case 2:
                    type = Symbols.WarehouseB;
                    break;
                case 3:
                    type = Symbols.WarehouseC;
                    break;
            }
            return _warehouses[type];
        }


    }
}
