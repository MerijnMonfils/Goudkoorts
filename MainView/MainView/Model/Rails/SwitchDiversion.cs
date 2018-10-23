using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model.MoveAbles;

namespace MainView.Model.Rails
{
    // one input into two outputs
    class SwitchDiversion : ISwitchRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail HoldRail;
        private Symbols TypeOfRail;

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public Symbols Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IMoveableObject ContainsMoveableObject { get; set; }
        public IRail OnHold { get { return HoldRail; } set { HoldRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }

        public void Switch()
        {
            var temp = HoldRail;
            HoldRail = Next;
            Next = temp;
            if (Type.Equals(Symbols.SwitchDown))
                Type = Symbols.SwitchUp;
            else
                Type = Symbols.SwitchDown;
        }

        public bool IsOnHold(IRail obj)
        {
            if (obj.Equals(OnHold))
                return true;
            return false;
        }
    }
}
