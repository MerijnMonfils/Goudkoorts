using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    class HoldingRail : IRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail BelowRail;
        private IRail AboveRail;

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
    }
}
