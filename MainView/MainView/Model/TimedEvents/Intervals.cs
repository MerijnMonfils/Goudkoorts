using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
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
        private Random _random;
        private int _time = 3000;

        public Intervals(MainModel main)
        {
            this._main = main;
            _random = new Random();
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(_time);
                SpawnRandomCart();
                MoveAllCarts();
            }
        }

        private void SpawnRandomCart()
        {
            int letter = _random.Next(1, 4);

            switch (letter)
            {
                case 1:
                    _main.GetWarehouse(Symbols.WarehouseA).SpawnCart();
                    break;
                case 2:
                    _main.GetWarehouse(Symbols.WarehouseB).SpawnCart();
                    break;
                case 3:
                    _main.GetWarehouse(Symbols.WarehouseC).SpawnCart();
                    break;
            }
        }

        private void MoveAllCarts()
        {
            foreach(Cart c in _main.GetAllCarts())
            {
               // Move logic
            }
        }

        public int GetTime()
        {
            return _time;
        }
    }
}
