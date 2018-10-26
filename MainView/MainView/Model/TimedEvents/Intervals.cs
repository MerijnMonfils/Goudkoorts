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
        private readonly int _time = 1000;

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
                MoveAllShips();
                MoveAllCarts();
                _input.Redraw(_main);
            }
        }

        private void MoveAllShips()
        {
            foreach(Ship s in _main.GetAllShips())
            {
                s.Move();
            }
        }

        private void CheckToSpawnShip()
        {
            if (_main.AmountOfDocks() == _main.AmountOfShips())
                return;
            else
                _main.AddShip(_main.GetAllDocks().First().SpawnShip());
        }

        private void SpawnRandomCart()
        {
            int letter = _random.Next(1, 4);

            switch (letter)
            {
                case 1:
                    _main.AddCart(_main.GetWarehouse(Symbols.WarehouseA).SpawnCart());
                    break;
                case 2:
                    _main.AddCart(_main.GetWarehouse(Symbols.WarehouseB).SpawnCart());
                    break;
                case 3:
                    _main.AddCart(_main.GetWarehouse(Symbols.WarehouseC).SpawnCart());
                    break;
            }
        }

        private void MoveAllCarts()
        {
            foreach(Cart c in _main.GetAllCarts())
            {
                c.Move();
            }
        }

        public int GetTime()
        {
            return _time;
        }
    }
}
