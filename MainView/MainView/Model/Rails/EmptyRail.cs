using Goudkoorts.Model.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainView.Model.Rails
{
    class EmptyRail : IRail
    {
        IRail IRail.Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRail IRail.Previous { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
