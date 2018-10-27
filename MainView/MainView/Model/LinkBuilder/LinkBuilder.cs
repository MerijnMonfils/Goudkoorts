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
        private IRail _firstInCurrentRow;
        private IRail _firstInPreviousRow;

        private int _prevPos;
        private int _currSwitch;

        public LinkBuilder(char[,] level, MainModel mainModel)
        {
            _mainModel = mainModel;
            CreateLinks(level);
        }

        public void CreateLinks(char[,] level)
        {
            for (int row = 0; row < level.GetLength(0); row++)  // for each row
            {
                for (int coll = 0; coll < level.GetLength(1); coll++) // for each column of current row
                {
                    if (level[row, coll].Equals((char)Symbols.SwitchDown)
                      || level[row, coll].Equals((char)Symbols.SwitchUp))
                    {
                        IRail switchRail = CheckForSwitch(level[row, coll], level[row - 1, coll], level[row + 1, coll]);
                        if (switchRail != null)
                        {
                            LinkLogic(switchRail, row, true);
                            continue;
                        }
                    }
                    LinkLogic(GetObject(level[row, coll]), row, false);
                }
            }
        }

        /// <summary>
        /// Creates all the links necessary for the functionality of the game
        /// </summary>
        public void LinkLogic(IRail obj, int posInRow, bool isSwitch)
        {
            // execute logic per instance of the IRail Object
            if (_mainModel.EndOflevelLink == null)
            {
                _mainModel.EndOflevelLink = obj;
                _prevObj = _mainModel.EndOflevelLink;
                _firstInCurrentRow = obj;
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

            // new row
            if (_prevPos != posInRow)
            {
                // reset first in current and previous
                _firstInPreviousRow = _firstInCurrentRow;
                _firstInCurrentRow = obj;
                // set links to above and below for first and previous
                _firstInCurrentRow.Above = _firstInPreviousRow;
                _firstInPreviousRow.Below = _firstInCurrentRow;
                // set previous row and object
                _prevObj = _firstInCurrentRow;
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
            var match = _firstInPreviousRow;
            for (int x = 0; x < counter; x++)
            {
                if (match.Next == null)
                {
                    break;
                }
                match = match.Next;
            }
            if (isSwitch)
                _mainModel.GetSwitch(_currSwitch).OnHold = match;

            obj.Above = match;
            match.Below = obj;
            _prevObj = obj;
        }

        /// <summary>
        /// Returns the corrosponding object equal to the parameter
        /// </summary>
        public IRail GetObject(char pos)
        {
            switch (pos)
            {
                // rails
                case (char)Symbols.HoldingRail:
                    return new HoldingRail(Symbols.HoldingRail);
                case (char)Symbols.NormalRail:
                    return new NormalRail(Symbols.NormalRail);
                case (char)Symbols.CornerRailA:
                    return new NormalRail(Symbols.CornerRailA);
                case (char)Symbols.CornerRailB:
                    return new NormalRail(Symbols.CornerRailB);
                case (char)Symbols.StraightRail:
                    return new NormalRail(Symbols.StraightRail);
                // warehouses
                case (char)Symbols.WarehouseA:
                    Warehouse wA = new Warehouse(Symbols.WarehouseA);
                    _mainModel.AddWarehouse(Symbols.WarehouseA, wA);
                    return wA;
                case (char)Symbols.WarehouseB:
                    Warehouse wB = new Warehouse(Symbols.WarehouseB);
                    _mainModel.AddWarehouse(Symbols.WarehouseB, wB);
                    return wB;
                case (char)Symbols.WarehouseC:
                    Warehouse wC = new Warehouse(Symbols.WarehouseC);
                    _mainModel.AddWarehouse(Symbols.WarehouseC, wC);
                    return wC;
                // dock
                case (char)Symbols.Dock:
                    Dock d = new Dock(Symbols.Dock);
                    _mainModel.AddDock(d);
                    return d;
                case (char)Symbols.Water:
                    return new ShipRail(Symbols.Water);
                // wrong or empty symbol
                default:
                    return new EmptyRail(Symbols.EmptyRail);
            }
        }

        public IRail CheckForSwitch(char posSwitch, char posAbove, char posBelow)
        {
            _currSwitch++;
            if (posSwitch.Equals((char)Symbols.SwitchDown) || posSwitch.Equals((char)Symbols.SwitchUp))
            {
                if (posAbove.Equals((char)Symbols.CornerRailB) && posBelow.Equals((char)Symbols.CornerRailA))
                {
                    SwitchConversion c = new SwitchConversion(Symbols.SwitchDown);
                    _mainModel.AddSwitch(_currSwitch, c);
                    return c;
                }
                else if (posAbove.Equals((char)Symbols.CornerRailA) && posBelow.Equals((char)Symbols.CornerRailB))
                {
                    SwitchDiversion c = new SwitchDiversion(Symbols.SwitchDown);
                    _mainModel.AddSwitch(_currSwitch, c);
                    return c;
                }
            }
            return null;
        }
    }
}
