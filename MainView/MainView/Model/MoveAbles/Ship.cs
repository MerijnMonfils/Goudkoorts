using Goudkoorts.Model.Rails;
using Goudkoorts.Enums;
using Goudkoorts.Enum;
using System;
using MainView.Model.Rails;

namespace Goudkoorts.Model.MoveAbles
{
    class Ship : IMoveableObject
    {
        private Random _random;
        private IRail _currentRail;
        private Direction LastMove;
        private char Icon;

        public Ship()
        {
            _random = new Random();
            CameFrom = Direction.Up;
        }

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }

        public char Type { get { return Icon; } set { Icon = value; } }

        public void Move()
        {
            if (_currentRail is Dock)
                return;

            int direction = _random.Next(1, 5);

            switch (direction)
            {
                case 1: // up
                    CameFrom = GetOpposite(Direction.Up);
                    if (CameFrom.Equals(Direction.Up))
                        Move(_currentRail.Below);
                    else
                        Move(_currentRail.Above);
                    break;
                case 2: // down
                    CameFrom = GetOpposite(Direction.Down);
                    Move(_currentRail.Below);
                    break;
                case 3: // left
                    CameFrom = GetOpposite(Direction.Left);
                    Move(_currentRail.Previous);
                    break;
                case 4: // right
                    CameFrom = GetOpposite(Direction.Right);
                    Move(_currentRail.Next);
                    break;
            }
        }

        private void Move(IRail move)
        {
            if (move == null)
                return;
            if (move is Dock)
            {
                move.ContainsMoveableObject = this;
                this._currentRail = move;
                this._currentRail.ContainsMoveableObject = null;
            }
            else if (move is ShipRail && !(_currentRail is Dock))
            {
                move.ContainsMoveableObject = this;
                this._currentRail = move;
                this._currentRail.ContainsMoveableObject = null;
            }
        }

        private Direction GetOpposite(Direction move)
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
            }
            return Direction.Up;
        }
    }
}
