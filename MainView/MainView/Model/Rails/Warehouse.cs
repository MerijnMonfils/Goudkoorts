using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    class Warehouse : IRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail AboveRail;
        private IRail BelowRail;
        private char TypeOfRail;
        private IMoveableObject ContainsCart;
        private bool Locked;

        public Warehouse(Symbols type)
        {
            TypeOfRail = (char)type;
        }

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public char Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IMoveableObject ContainsMoveableObject { get { return ContainsCart; } set { ContainsCart = value; } }
        public bool IsLocked { get { return Locked; } set { Locked = value; } }

        public bool IsOnHold(IRail obj)
        {
            return false;
        }

        public Cart SpawnCart()
        {
            Cart c = new Cart(Symbols.FullCart);
            c.IsOnRail = this.Next;
            Next.ContainsMoveableObject = c;
            return c;
        }
    }
}
