using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using Goudkoorts.ViewModel;
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
        private InputViewVM _input;
        private Random _random;
        private readonly int _time = 3000;

        public Intervals(MainModel main, InputViewVM input)
        {
            this._main = main;
            this._input = input;
            _random = new Random();
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(_time);
                SpawnRandomCart();
                CheckToSpawnShip();
                MoveAllCarts();
                _input.Redraw(_main);
            }
        }

        private void CheckToSpawnShip()
        {
            if(_main.GetDock(1).ContainsShip == null)
            {
                _main.AddShips(_main.GetDock(1).SpawnShip());
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
