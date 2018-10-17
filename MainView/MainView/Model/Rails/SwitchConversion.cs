using Goudkoorts.Model.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainView.Model.Rails
{
    // one input into two outputs
    class SwitchConversion : ISwitchRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail BelowRail;
        private IRail AboveRail;
        private IRail HoldRail;

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail OnHold { get { return HoldRail; } set { HoldRail = value; } }
    }
}
