using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Rails
{
    class Warehouse : IRail
    {
        public IRail Next { get { return Next; } set { Next = value; } }
        public IRail Previous { get { return Next; } set { Next = value; } }
        public IRail Below { get { return Next; } set { Next = value; } }
        public IRail Above { get { return Next; } set { Next = value; } }
    }
}
