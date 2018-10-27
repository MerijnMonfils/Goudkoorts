using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Enum;
using Goudkoorts.Enums;
using Goudkoorts.Model.Rails;
using MainView.Model.Rails;

namespace Goudkoorts.Model.MoveAbles
{
    class Cart : IMoveableObject
    {
        private IRail _currentRail;
        private IRail _moveTo;
        private Direction LastMove;
        private char Icon;

        public Cart(Symbols type)
        {
            CameFrom = Direction.Left;
            this.Icon = (char)type;
        }

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }

        public char Type { get { return Icon; } set { Icon = (char)value; } }

        public bool DestroyCart {get; private set;}

        public void Move()
        {
            var newDirection = (GetNextDirection(CameFrom));
            while (true)
            {
                // went through all possible moves
                if (newDirection.Equals(CameFrom))
                    return;

                if (IsOnRail.Previous == null && this.Type.Equals((char)Symbols.EmptyCart))
                {
                    DestroyCart = true;
                    return;
                }

                if (IsOnRail is HoldingRail && IsOnRail.Next == null)
                    return;

                if (IsOnRail is HoldingRail && IsOnRail.Previous.ContainsMoveableObject is Cart)
                    return;


                if (!(_moveTo is EmptyRail) && _moveTo != null)
                    if (CheckForPossibleMove(newDirection))
                        return;

                newDirection = (GetNextDirection(newDirection));
            }
        }

        public bool GameOverChecks()
        {
            //Rangrail colission
            if (IsOnRail.Previous.ContainsMoveableObject is Cart && IsOnRail.Previous is HoldingRail && !(IsOnRail is HoldingRail))
            {
                return true;
            }

            //switch colission
            if (IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Below is SwitchConversion ||
                IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Below is SwitchDiversion)
            {
                return true;
            }

            if (IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Above is SwitchConversion ||
              IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Above is SwitchDiversion)
            {
                return true;
            }

            if (IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Next is SwitchConversion ||
           IsOnRail.Next != null && IsOnRail.Next.ContainsMoveableObject is Cart && IsOnRail.Next.Next is SwitchDiversion)
            {
                return true;
            }
            return false;
        }

        private bool CheckForPossibleMove(Direction newDirection)
        {
            if (MoveToSwitch(newDirection))
                return true;
            if (_moveTo is NormalRail)
            {
                if (!MoveIsOnHold(newDirection))
                    return true;
                return false;
            }
            if (_moveTo is HoldingRail)
            {
                MoveCart(newDirection);
                return true;
            }
            if (_moveTo is Dock)
            {
                MoveCart(newDirection);
                Dock d = (Dock)_currentRail;
                d.UpdateShip();
                Type = (char)Symbols.EmptyCart;
                return true;
            }
            return false;
        }

        public bool CheckForDestroy()
        {
            if (DestroyCart)
                return true;
            return false;
        }

        private bool MoveIsOnHold(Direction newDirection)
        {
            if (_currentRail is ISwitchRail)
                if (_currentRail.IsOnHold(_moveTo))
                    return true;
                else
                {
                    MoveCart(newDirection);
                    return false;
                }
            else
            {
                MoveCart(newDirection);
                return false;
            }
        }

        private bool MoveToSwitch(Direction newDirection)
        {
            if (_moveTo is ISwitchRail)
                if (_moveTo.IsOnHold(_currentRail))
                    return false;
                else
                {
                    MoveCart(newDirection);
                    return true;
                }
            return false;
        }

        private void MoveCart(Direction newDirection)
        {
            var temp = this;
            this._currentRail.ContainsMoveableObject = null;
            _moveTo.ContainsMoveableObject = temp;
            temp._currentRail = _moveTo;
            CameFrom = GetOpposite(newDirection);
        }

        public Direction GetOpposite(Direction move)
        {
            switch (move)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    return Direction.Up;
            }
        }

        public Direction GetNextDirection(Direction lastMove)
        {
            switch (lastMove)
            {
                case Direction.Up:
                    _moveTo = _currentRail.Next;
                    return Direction.Right;
                case Direction.Right:
                    _moveTo = _currentRail.Below;
                    return Direction.Down;
                case Direction.Down:
                    _moveTo = _currentRail.Previous;
                    return Direction.Left;
                case Direction.Left:
                    _moveTo = _currentRail.Above;
                    return Direction.Up;
                default:
                    return Direction.Up;
            }
        }
    }
}

