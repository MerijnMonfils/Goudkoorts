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
        public IRail OnHold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRail Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRail Previous { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
