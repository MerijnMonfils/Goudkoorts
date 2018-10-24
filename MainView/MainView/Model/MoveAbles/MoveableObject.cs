using Goudkoorts.Model.Rails;
using Goudkoorts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.MoveAbles
{
    interface IMoveableObject
    {
        IRail IsOnRail { get; set; }
        Direction CameFrom { get; set; }
    }
}
