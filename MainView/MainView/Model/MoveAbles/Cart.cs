using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private Direction LastMove;
        private char Icon;
        private bool disableLeft = false;
        
        

        public Cart(Symbols type)
        {
            this.Icon = (char)type;
        }

        public IRail IsOnRail { get { return _currentRail; } set { _currentRail = value; } }

        public Direction CameFrom { get { return LastMove; } set { LastMove = value; } }

        public char Type { get { return Icon; } set { Icon = (char)value; } }

        public void Move()
        {


        
           
            if (_currentRail.Next == null && _currentRail.Below is EmptyRail )
            {
                LastMove = Direction.Down;
            }

            if (_currentRail.Next == null && _currentRail.Above is EmptyRail)
            {
                LastMove = Direction.Up;
            }

            if (_currentRail.Above == null && _currentRail.Next == null)
            {
                LastMove = Direction.Right;
            }

            if (_currentRail.Below == null && _currentRail.Next == null)
            {
                LastMove = Direction.Right;
            }

         

            if (LastMove == Direction.Left) 
            {
                _currentRail.Next.ContainsMoveableObject = this;
                _currentRail.ContainsMoveableObject = null;
                _currentRail = _currentRail.Next;

            }

            if (LastMove == Direction.Right)
            {
                _currentRail.Previous.ContainsMoveableObject = this;
                _currentRail.ContainsMoveableObject = null;
                _currentRail = _currentRail.Previous;
            }

            if (LastMove == Direction.Up)
            {
                _currentRail.Below.ContainsMoveableObject = this;
                _currentRail.ContainsMoveableObject = null;
                _currentRail = _currentRail.Below;
            }

            if (LastMove == Direction.Down)
            {
                _currentRail.Above.ContainsMoveableObject = this;
                _currentRail.ContainsMoveableObject = null;
                _currentRail = _currentRail.Above;
            }

            

        }
    }
}

