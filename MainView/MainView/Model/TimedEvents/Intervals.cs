using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using Goudkoorts.Model.Rails;
using Goudkoorts.ViewModel;
using System;
using System.Linq;
using System.Threading;

namespace Goudkoorts.Model.TimedEvents
{
    class Intervals
    {
        private MainModel _main;
        private InputViewVM _input;
        private Score.Score _score;
        private Random _random;
        private readonly int _time = 2000;
        private int _timeLeft;
        private bool _spawn = false;

        public Intervals(MainModel main, InputViewVM input, Score.Score score)
        {
            this._main = main;
            this._input = input;
            this._score = score;
            _random = new Random();
            _timeLeft = _time;
        }

        public void Start()
        {
            while (true)
            {
                if (GameOver())
                    return;

                SpawnRandomCart();
                Thread.Sleep(_timeLeft);
                SlowDownTime();
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
            _timeLeft = _timeLeft - 20;
        }

        private void MoveAllShips()
        {
            foreach (Ship s in _main.GetAllShips())
            {
                if (s.IsOnRail is Dock)
                {
                    Dock d = (Dock)s.IsOnRail;
                    if (d.Score == 8)
                        _score.SetScore(10);
                }
                s.Move();
                if (s.CheckForDestroy())
                {
                    _main.RemoveShip(s);
                }
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
                if (_random.Next(8) == 2)
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
            foreach (Cart c in _main.GetAllCarts())
            {
                if (c.IsOnRail.Previous is Dock)
                {
                    Dock d = (Dock)c.IsOnRail.Previous;
                    if (d.ContainsShip != null)
                        _score.SetScore(1);
                }
                c.Move();
            }
        }
        private bool GameOver()
        {
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
