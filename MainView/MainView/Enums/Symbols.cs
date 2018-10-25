using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Enum
{
    public enum Symbols
    {
        // cart
        FullCart = 'Ü',
        EmptyCart = 'U',
        // rails
        NormalRail = '—',
        HoldingRail = '_',
        CornerRailA = '/',
        CornerRailB = '\\',
        StraightRail = '|',
       

        EmptyRail = ' ',
        // switch
        SwitchUp = '^',
        SwitchDown = 'v',
        // warehouses
        WarehouseA = 'A',
        WarehouseB = 'B',
        WarehouseC = 'C',
        // dock
        Dock = 'K',
    }
}
