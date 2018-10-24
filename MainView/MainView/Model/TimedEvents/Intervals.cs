using Goudkoorts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts.Model.TimedEvents
{
    class Intervals
    {
        private MainModel _main;

        public Intervals(MainModel main)
        {
            this._main = main;
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(3000);
                _main.GetWarehouse(Symbols.WarehouseA).SpawnCart();
                MoveAllCarts();
            }
        }

        private void MoveAllCarts()
        {
            
        }
    }
}
