using Goudkoorts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model.MoveAbles;

namespace Goudkoorts.Model.Rails
{
    interface IRail
    {
        IRail Next { get; set; }
        IRail Previous { get; set; }
        Symbols Type { get; set; }
        IMoveableObject ContainsMoveableObject { get; set; }
    }
}
