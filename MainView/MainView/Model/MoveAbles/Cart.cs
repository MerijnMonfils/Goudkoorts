using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Icon = (char)type;
        }

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }

        public char Type { get { return Icon; } set { Icon = (char)value; } }

        public void Move()
        {
            var newDirection = (GetNextDirection(CameFrom));
            while (true)
            {
                // went through all possible moves
                if (newDirection.Equals(CameFrom))
                    break;
                else
                {
                    if(!(_moveTo is EmptyRail) && _moveTo != null)
                    {
                        CheckForPossibleMove();
                    }
                }
                newDirection = (GetNextDirection(newDirection));
            }
        }

        private void CheckForPossibleMove()
        {
            if (CartOnHold())
                return;
            if(_moveTo is Dock)
            {
                CheckForOtherCarts();
            }
            if(_moveTo is HoldingRail)
            {
                // move to holdingRail
            }
        }

        /// <summary>
        /// Will check for the current cart if it is on a rail that is on a hold.
        /// </summary>
        /// <returns>true if the cart is on hold</returns>
        private bool CartOnHold()
        {
            if (_moveTo is ISwitchRail)
            {
                if (_moveTo.IsOnHold(_currentRail))
                {
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        private void CheckForOtherCarts()
        {
            if (_moveTo.ContainsMoveableObject != null)
            {
                if (OppositeCartCanMove())
                {
                    // move
                } else
                {
                    // GAME OVER
                }
            }
        }

        public bool OppositeCartCanMove()
        {
            return true;
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
                    _moveTo = _currentRail.Below;
                    return Direction.Down;
                case Direction.Down:
                    _moveTo = _currentRail.Previous;
                    return Direction.Left;
                case Direction.Left:
                    _moveTo = _currentRail.Next;
                    return Direction.Right;
                case Direction.Right:
                    _moveTo = _currentRail.Above;
                    return Direction.Up;
                default:
                    return Direction.Up;
            }
        }
    }
}

