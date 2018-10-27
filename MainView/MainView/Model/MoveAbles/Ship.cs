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

        public bool IsMovingFromDock { private get; set; }
        public bool DestroyShip { get; private set; }

        public void Move()
        {
            if (_currentRail is Dock)
                return;
            if (IsMovingAway())
                return;

            int direction = _random.Next(1, 8);

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
                    if (_currentRail.Previous.Previous == null)
                        Move();
                    Move(_currentRail.Previous);
                    break;
                case 4: // right
                    CameFrom = GetOpposite(Direction.Right);
                    Move(_currentRail.Next);
                    break;
                default:
                    Move(_currentRail.Below);
                    break;
            }
        }

        public bool CheckForDestroy()
        {
            if (DestroyShip)
                return true;
            return false;
        }

        private bool IsMovingAway()
        {
            if (IsMovingFromDock)
            {
                if (_currentRail.Next is ShipRail)
                {
                    var temp = this;
                    this._currentRail.ContainsMoveableObject = null;
                    _currentRail.Next.ContainsMoveableObject = temp;
                    temp.IsOnRail = _currentRail.Next;
                } else
                {
                    this._currentRail.ContainsMoveableObject = null;
                    this.DestroyShip = true;
                }
                return true;
            }
            return false;
        }

        private void Move(IRail move)
        {
            if (move == null)
                Move();
            if (!(move is Dock) && !(move is ShipRail))
                Move();

            if (move is Dock || move is ShipRail)
            {
                var temp = this;
                this._currentRail.ContainsMoveableObject = null;
                move.ContainsMoveableObject = temp;
                temp._currentRail = move;

                if (move is Dock)
                {
                    Dock d = (Dock)move;
                    d.ContainsShip = this;
                    _currentRail = d;
                    d.SetSideIcons();
                }
            }
            try
            {
                if (move.Below is Dock && move is ShipRail)
                {
                    var temp = this;
                    this._currentRail.ContainsMoveableObject = null;
                    move.Below.ContainsMoveableObject = temp;
                    temp._currentRail = move.Below;
                    Dock d = (Dock)move.Below;
                    d.ContainsShip = this;
                    _currentRail = d;
                    d.SetSideIcons();

                }
            }
            catch (Exception e)
            {
                Move();
            }
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
            }
            return Direction.Up;
        }
    }
}
