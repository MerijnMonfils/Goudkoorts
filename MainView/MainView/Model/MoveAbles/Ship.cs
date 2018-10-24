using Goudkoorts.Model.Rails;
using Goudkoorts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.MoveAbles
{
    class Ship : IMoveableObject
    {
        private IRail _currentRail;
        private Direction LastMove;

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }
    }
}
