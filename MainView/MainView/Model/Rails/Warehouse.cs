using Goudkoorts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model.MoveAbles;

namespace Goudkoorts.Model.Rails
{
    class Warehouse : IRail
    {
        private IRail NextRail;
        private IRail PreviousRail;
        private Symbols TypeOfRail;
        
        public IRail Next { get { return NextRail; } set { NextRail = value; } }
        public IRail Previous { get { return PreviousRail; } set { PreviousRail = value; } }
        public Symbols Type { get { return TypeOfRail; } set { TypeOfRail = value; } }
        public IMoveableObject ContainsMoveableObject { get; set; }

        public void SpawnCarts()
        {

            NextRail.ContainsMoveableObject = new Cart();

        }
    }
}
