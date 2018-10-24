using Goudkoorts.Enum;
using Goudkoorts.Model.MoveAbles;
using Goudkoorts.Model.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainView.Model.Rails
{
    // two inputs into one output
    class SwitchConversion : ISwitchRail
    {

        private IRail NextRail;
        private IRail PreviousRail;
        private IRail AboveRail;
        private IRail BelowRail;
        private IRail HoldRail;
        private char TypeOfRail;
        private IMoveableObject ContainsCart;

        public SwitchConversion(Symbols type)
        {
            TypeOfRail = (char)type;
        }

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail OnHold { get { return HoldRail; } set { HoldRail = value; } }
        public char Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public IMoveableObject ContainsMoveableObject { get { return ContainsCart; } set { ContainsCart = value; } }
        public void Switch()
        {
            // SWITCH CONNECTIONS AND ONHOLD

            if (Type.Equals((char)Symbols.SwitchDown))
                Type = (char)Symbols.SwitchUp;
            else
                Type = (char)Symbols.SwitchDown;
        }

        public bool IsOnHold(IRail obj)
        {
            if (obj.Equals(OnHold))
                return true;
            return false;
        }
    }
}
