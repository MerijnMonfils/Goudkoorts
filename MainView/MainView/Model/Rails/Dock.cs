using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    class Dock : IRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail AboveRail;
        private IRail BelowRail;
        private char TypeOfRail;
        private IMoveableObject ContainsCart;
        private bool Locked;

        private int _amount { get; set; }

        public Dock(Symbols type)
        {
            TypeOfRail = (char)type;
        }

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public char Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IMoveableObject ContainsMoveableObject { get { return ContainsCart; } set { ContainsCart = value; } }
        
        public IMoveableObject ContainsShip { get; set; }

        public bool IsLocked { get { return Locked; } set { Locked = value; } }

        public bool IsOnHold(IRail obj)
        {
            return false;
        }

        public Ship SpawnShip()
        {
            Ship s = new Ship();
            s.IsOnRail = GetRandomShipLocation();
            return s;
        }

        private IRail GetRandomShipLocation()
        {
            var temp = this.Above;
            int amountOfRows = 0;
            int amountOfColumns = 0;
            while(temp.Above != null)
            {
                amountOfRows++;
                temp = temp.Above;
            }
            while(temp.Previous != null)
            {
                temp = temp.Previous;
            }
            var temp2 = temp;
            while(temp2.Next != null)
            {
                amountOfColumns++;
                temp2 = temp2.Next;
            }
        }

        public void UpdateShip()
        {
            _amount++;
            if (_amount == 8)
            {
                // TODO: update score
                this.ContainsShip = null;
            }
            this.Above.Type = char.Parse(_amount.ToString());
        }

        public void SetSideIcons()
        {
            this.Above.Next.Type = (char)Symbols.ShipRight;
            this.Above.Previous.Type = (char)Symbols.ShipLeft;
            this.Above.Type = char.Parse(_amount.ToString());
        }
    }
}
