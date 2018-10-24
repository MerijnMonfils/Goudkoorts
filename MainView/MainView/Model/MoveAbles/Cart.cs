using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Enum;
using Goudkoorts.Enums;
using Goudkoorts.Model.Rails;

namespace Goudkoorts.Model.MoveAbles
{
    class Cart : IMoveableObject
    {
        private IRail _currentRail;
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
            _currentRail.Next.ContainsMoveableObject = this;
            _currentRail.ContainsMoveableObject = null;
            _currentRail = _currentRail.Next;
        }
    }
}

