using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    class NormalRail : IRail
    {
        public IRail Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRail Previous { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
