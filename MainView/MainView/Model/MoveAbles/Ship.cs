using Goudkoorts.Model.Rails;
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
        private int _speed = 10;

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public int Speed { get { return _speed; } set { return; } }
    }
}
