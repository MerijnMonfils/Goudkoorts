using System;
using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using MainView.Model.Rails;

namespace Goudkoorts.Model.LinkBuilder
{
    class LinkBuilder
    {
        private MainModel _mainModel;
        private IRail _prevObj;
        private int _prevPos;

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
                    IRail rail = GetObject(level[row, coll]);
                    if (rail != null)
                    {
                        LinkLogic(rail, row);
                    }
                    if(level[row, coll].Equals((char)Symbols.SwitchDown) 
                        || level[row, coll].Equals((char)Symbols.SwitchUp))
                    {
                        IRail switchRail = CheckForSwitch(level[row, coll], level[row - 1, coll], level[row + 1, coll]);
                        if (switchRail != null)
                        {
                            LinkLogic(switchRail, row);
                        }
                    }
                }
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
                _prevObj = _mainModel.EndOflevelLink;
                _mainModel.FirstInCurrentRow = obj;
                return;
            }
            else if (posInRow == 0)
            {
                _prevObj.Next = obj;
                obj.Previous = _prevObj;
                _prevObj = obj;
                _prevPos = posInRow;
                return;
            }
            return;
            // new row
            if (_prevPos != posInRow)
            {
                _mainModel.FirstInPreviousRow = _mainModel.FirstInCurrentRow;
                _mainModel.FirstInCurrentRow = obj;
                _mainModel.FirstInCurrentRow.Above = _mainModel.FirstInPreviousRow;
                _mainModel.FirstInPreviousRow.Below = _mainModel.FirstInCurrentRow;
                _prevObj = _mainModel.FirstInCurrentRow;
                _prevPos = posInRow;
                return;
            }
            
            // set previous & next relation
            obj.Previous = _prevObj;
            _prevObj.Next = obj;

            // set above & below relation
            int counter = 0;
            var temp = obj;
            while (temp.Previous != null)
            {
                temp = temp.Previous;
                counter++;
            }

            var match = _mainModel.FirstInPreviousRow;

            for (int x = 0; x < counter; x++)
            {
                if (match.Next == null)
                {
                    break;
                }
                match = match.Next;
            }
            obj.Above = match;
            match.Below = obj;

            // set _prevObj to the current obj
            _prevObj = obj;
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
            if (posSwitch.Equals((char)Symbols.SwitchDown) || posSwitch.Equals((char)Symbols.SwitchUp))
            {
                if (posAbove.Equals((char)Symbols.CornerRailB) && posBelow.Equals((char)Symbols.CornerRailA))
                {
                    return new SwitchConversion();
                }
                else if (posAbove.Equals((char)Symbols.CornerRailA) && posBelow.Equals((char)Symbols.CornerRailB))
                {
                    return new SwitchDiversion();
                }
            }
            return null;
        }

    }
}
