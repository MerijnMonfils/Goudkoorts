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
        private readonly int _time = 2000;
        private int _timeLeft;
        private bool _spawn = false;
        
        public Intervals (MainModel main, InputViewVM input)
        {
            this._main = main;
            this._input = input;
            _random = new Random();
            _timeLeft = _time;
        }

        public void Start()
        {
            while (true)
            {
                if (GameOver())
                    return;

                Thread.Sleep(_timeLeft);
                SlowDownTime();
                SpawnRandomCart();
                CheckToSpawnShip();
                MoveAllShips();
                MoveAllCarts();
                _input.Redraw(_main);
            }
        }

        private void SlowDownTime()
        {
            if (_timeLeft < 500)
                return;
            _timeLeft = _timeLeft - 30;
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
            if (!_spawn)
            {
                if (_random.Next(6) == 2)
                {
                    //If the integer is equal to 2, Spawn a cart. Else, keep waiting.
                    _spawn = true;
                }

            }

            int letter = _random.Next(1, 4);
                if (_spawn)
                {
                    switch (letter)
                    {
                        case 1:
                            _main.AddCart(_main.GetWarehouse(Symbols.WarehouseA).SpawnCart());
                            _spawn = false;
                            break;
                        case 2:
                            _main.AddCart(_main.GetWarehouse(Symbols.WarehouseB).SpawnCart());
                            _spawn = false;
                            break;
                        case 3:
                            _spawn = false;
                            _main.AddCart(_main.GetWarehouse(Symbols.WarehouseC).SpawnCart());
                            break;
                    }
                }
         
        }
            

        private void MoveAllCarts()
        {
            foreach(Cart c in _main.GetAllCarts())
            {
                c.Move();
                
            }
        }
        private bool GameOver() {
            foreach (Cart c in _main.GetAllCarts())
            {
                if (c.GameOverChecks())
                {
                    return true;
                }

            }

            return false;
        }

        public int GetTime()
        {
            return _time;
        }
    }
}
