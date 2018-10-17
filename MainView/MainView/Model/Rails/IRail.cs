using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    interface IRail
    {
        IRail Next { get; set; }
        IRail Previous { get; set; }
        IRail Below { get; set; }
        IRail Above { get; set; }
    }
}
