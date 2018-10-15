using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;

namespace Goudkoorts.Model.LinkBuilder
{
    class LinkBuilder
    {
        private MainModel _mainModel;

        public LinkBuilder(char[,] level, MainModel mainModel)
        {
            this._mainModel = mainModel;
            CreateLinks(level);
        }

        /// <summary>
        /// Loops through the multidimensional character array
        /// </summary>
        public void CreateLinks(char[,] level)
        {
            for (int row = 0; row < level.GetLength(0); row++)  // for each row
            {
                for (int coll = 0; coll < level.GetLength(1); coll++) // for each column of current row
                {
                    IRail obj = GetObject(level[row, coll]);
                    if (obj != null)
                        LinkLogic(obj);
                }
            }
        }

        /// <summary>
        /// Creates all the links necessary for the functionality of the game
        /// </summary>
        public void LinkLogic(IRail obj)
        {
            // execute logic per instance of the IRail Object
            if(_mainModel.EndOflevelLink == null)
            {
                _mainModel.EndOflevelLink = obj;
            }
        }

        /// <summary>
        /// Returns the corrosponding object equal to the parameter
        /// </summary>
        public IRail GetObject(char pos)
        {
            switch (pos)
            {
                // rail normal
                case (char)Symbols.NormalRail:
                    return new NormalRail();
                // rail holding
                case (char)Symbols.HoldingRail:
                    return new HoldingRail();
                // switches
                case (char)Symbols.SwitchDown:
                    return new SwitchRail();
                case (char)Symbols.SwitchUp:
                    return new SwitchRail();
                // warehouses
                case (char)Symbols.WarehouseA:
                    return new Warehouse();
                case (char)Symbols.WarehouseB:
                    return new Warehouse();
                case (char)Symbols.WarehouseC:
                    return new Warehouse();
                // dock
                case (char)Symbols.Dock:
                    return new Dock();
                // wrong or empty symbol
                default:
                    return null;
            }
        }

    }
}
