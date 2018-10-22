using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    interface ISwitchRail : IRail
    {
        IRail OnHold { get; set; }

        void Switch();

        bool IsOnHold(IRail obj);


    }
}
