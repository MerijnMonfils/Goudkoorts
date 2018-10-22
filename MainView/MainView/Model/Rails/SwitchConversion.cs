using Goudkoorts.Enum;
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
        private IRail HoldRail;
        private Symbols TypeOfRail;

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail OnHold { get { return HoldRail; } set { HoldRail = value; } }
        public Symbols Type { get { return TypeOfRail; } set { TypeOfRail = value; } }

        public void Switch()
        {
            var temp = HoldRail; 
            HoldRail = Previous;
            Previous = temp;
        }

        public bool IsOnHold(IRail obj)
        {
            if (obj.Equals(OnHold))
                return true;
            return false;
        }
    }
}
