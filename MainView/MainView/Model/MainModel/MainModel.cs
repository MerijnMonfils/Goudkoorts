using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using MainView.Model.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class MainModel
    {
        public IRail EndOflevelLink { get; set; }
        
        private Dictionary<int, ISwitchRail> _switches;
        private Dictionary<Symbols, Warehouse> _warehouses;
        private Dictionary<int, Dock> _docks;

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
    }
}
