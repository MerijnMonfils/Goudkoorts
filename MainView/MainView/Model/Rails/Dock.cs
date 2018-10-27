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
        private Random _random;

        public Dock(Symbols type)
        {
            TypeOfRail = (char)type;
            _random = new Random();
        }

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public char Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IMoveableObject ContainsMoveableObject { get { return ContainsCart; } set { ContainsCart = value; } }
        
        public IMoveableObject ContainsShip { get; set; }

        public bool IsLocked { get { return Locked; } set { Locked = value; } }

        public int Score { get; private set; }

        public bool IsOnHold(IRail obj)
        {
            return false;
        }

        public Ship SpawnShip()
        {
            Ship s = new Ship();
            var temp = GetRandomShipLocation();
            s.IsOnRail = temp;
            temp.ContainsMoveableObject = s;
            s.Type = (char)Symbols.ShipFull;
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
            int randomRow = _random.Next(0, amountOfRows+1);
            int randomColumn = _random.Next(1, amountOfColumns);
            for(int x = 0; x < randomRow; x++)
                temp = temp.Below;
            for (int i = 0; i < randomColumn; i++)
                temp = temp.Next;
            return temp;
        }

        public void UpdateShip()
        {
            if (this.ContainsShip == null)
                return;
            Score++;
            if (Score == 8)
                InitiateMoveAway();
            this.Above.Type = char.Parse(Score.ToString());
        }

        private void InitiateMoveAway()
        {
            if (this.ContainsShip == null)
                return;
            Ship s = (Ship)this.ContainsShip;
            s.Type = (char)Symbols.ShipFull;
            s.IsMovingFromDock = true;
            this.ContainsShip = null;
            this.Above.ContainsMoveableObject = s;
            s.IsOnRail = this.Above;
            RemoveSideIcons();
        }

        private void RemoveSideIcons()
        {
            this.Above.Next.Type = (char)Symbols.Water;
            this.Above.Previous.Type = (char)Symbols.Water;
            this.Score = 0;
            this.Above.Type = (char)Symbols.Water;
        }

        public void SetSideIcons()
        {
            this.Above.Next.Type = (char)Symbols.ShipRight;
            this.Above.Previous.Type = (char)Symbols.ShipLeft;
            this.Above.Type = char.Parse(Score.ToString());
        }
    }
}
