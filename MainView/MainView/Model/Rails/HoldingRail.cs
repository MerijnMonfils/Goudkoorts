﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Enum;

namespace Goudkoorts.Model.Rails
{
    class HoldingRail : IRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private IRail AboveRail;
        private IRail BelowRail;
        private char TypeOfRail;

        public HoldingRail(Symbols type)
        {
            TypeOfRail = (char)type;
        }

        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public IRail Above { get { return AboveRail; } set { AboveRail = value; } }
        public IRail Below { get { return BelowRail; } set { BelowRail = value; } }
        public char Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
    }
}
