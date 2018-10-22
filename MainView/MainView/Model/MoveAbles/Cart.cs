using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model.Rails;

namespace Goudkoorts.Model.MoveAbles
{
    class Cart : IMoveableObject
    {
        private IRail _currentRail;
        private int _speed;

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public int Speed { get { return _speed; } set { _speed = value; } }
    }
}
