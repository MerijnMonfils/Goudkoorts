using Goudkoorts.Model.Rails;
using Goudkoorts.Enums;
using Goudkoorts.Enum;

namespace Goudkoorts.Model.MoveAbles
{
    class Ship : IMoveableObject
    {
        private IRail _currentRail;
        private Direction LastMove;
        private char Icon;

        public Ship(Symbols type)
        {
            this.Icon = (char)type;
        }

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }

        public char Type { get { return Icon; } set { Icon = (char)value; } }
    }
}
