using System;
using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using MainView.Model.Rails;

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
            System.Console.WriteLine();
            for (int row = 0; row < level.GetLength(0); row++)  // for each row
            {
                for (int coll = 0; coll < level.GetLength(1); coll++) // for each column of current row
                {
                    IRail rail = GetObject(level[row, coll]);
                    if (rail != null)
                    {
                        LinkLogic(rail, row);
                    }
                    System.Console.Write(level[row, coll] + " ");
                    continue;
                    IRail switchRail = CheckForSwitch(level[row, coll], level[row - 1, coll], level[row + 1, coll]);
                    if (switchRail != null)
                    {
                        LinkLogic(switchRail, row);
                    }
                }
                System.Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Creates all the links necessary for the functionality of the game
        /// </summary>
        public void LinkLogic(IRail obj, int posInRow)
        {
            // execute logic per instance of the IRail Object
            if (_mainModel.EndOflevelLink == null)
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
                    return new EmptyRail();
            }
        }

        public IRail CheckForSwitch(char posSwitch, char posAbove, char posBelow)
        {
            if(posSwitch.Equals((char)Symbols.SwitchDown) || posSwitch.Equals((char)Symbols.SwitchUp))
            {
                if (posAbove.Equals((char)Symbols.CornerRailB) && posBelow.Equals((char)Symbols.CornerRailA))
                {
                    System.Console.WriteLine("Conversion found");
                    return new SwitchConversion();
                } else if (posAbove.Equals((char)Symbols.CornerRailA) && posBelow.Equals((char)Symbols.CornerRailB))
                {
                    System.Console.WriteLine("Diversion found");
                    return new SwitchDiversion();
                }
            }
            return null;
        }

    }
}
