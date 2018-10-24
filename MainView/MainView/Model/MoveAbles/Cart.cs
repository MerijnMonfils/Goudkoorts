using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Enums;
using Goudkoorts.Model.Rails;

namespace Goudkoorts.Model.MoveAbles
{
    class Cart : IMoveableObject
    {
        private IRail _currentRail;
        private Direction LastMove;

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value;  } }

        public void Move()
        {
            if (!_currentRail.Next.IsOnHold(_currentRail))
            {

            }
        }
    }
}
