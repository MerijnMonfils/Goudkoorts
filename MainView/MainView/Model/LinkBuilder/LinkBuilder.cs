using System;
using Goudkoorts.Enum;
using Goudkoorts.Model.Rails;
using MainView.Model.Rails;

namespace Goudkoorts.Model.LinkBuilder
{
    class LinkBuilder
    {
        private MainModel _mainModel;
        private IRail _lastObject;
        
        public LinkBuilder(MainModel mainModel)
        {
            _mainModel = mainModel;
            CreateLinks();
        }

        public void CreateLinks()
        {
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateDockRelation(new Dock(), Symbols.Dock, 1);

            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailB);
            CreateNormalRelation(new NormalRail(), Symbols.StraightRail);
            CreateNormalRelation(new NormalRail(), Symbols.StraightRail);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateConversionRelation(new SwitchConversion(), Symbols.SwitchDown, 3);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailB);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);

            CreateDiversionRelation(new SwitchDiversion(), Symbols.SwitchDown, 2);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateConversionRelation(new SwitchConversion(), Symbols.SwitchDown, 1);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailB);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateWarehouseRelation(new Warehouse(), Symbols.WarehouseA);
            _lastObject = _mainModel.GetSwitch(1);
            _mainModel.GetSwitch(1).OnHold = _mainModel.GetSwitch(1).Previous;
            
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateWarehouseRelation(new Warehouse(), Symbols.WarehouseB);
            _lastObject = _mainModel.GetSwitch(3);
            _mainModel.GetSwitch(3).OnHold = _mainModel.GetSwitch(3).Previous;

            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);

            // SECOND PART
            CreateDiversionRelation(new SwitchDiversion(), Symbols.SwitchDown, 5);
            _mainModel.GetSwitch(5).OnHold = _mainModel.GetSwitch(5).Previous;
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateConversionRelation(new SwitchConversion(), Symbols.SwitchDown, 4);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailB);
            CreateNormalRelation(new NormalRail(), Symbols.CornerRailB);
            _mainModel.GetSwitch(4).OnHold = _mainModel.GetSwitch(4).Previous;
            _lastObject = _mainModel.GetSwitch(2);
            _lastObject.Previous = _mainModel.GetSwitch(2);
            _mainModel.GetSwitch(2).Next = _lastObject;
            _lastObject = _mainModel.GetSwitch(4);

            CreateNormalRelation(new NormalRail(), Symbols.CornerRailA);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);
            CreateNormalRelation(new NormalRail(), Symbols.NormalRail);

            CreateWarehouseRelation(new Warehouse(), Symbols.WarehouseC);
            _lastObject = _mainModel.GetSwitch(5);
            
            CreateBackwardsRelation(new NormalRail(), Symbols.CornerRailB);
            CreateBackwardsRelation(new NormalRail(), Symbols.StraightRail);
            CreateBackwardsRelation(new NormalRail(), Symbols.CornerRailA);

            CreateBackwardsRelation(new NormalRail(), Symbols.NormalRail);
            CreateBackwardsRelation(new NormalRail(), Symbols.NormalRail);
            CreateBackwardsRelation(new NormalRail(), Symbols.NormalRail);
            CreateBackwardsRelation(new NormalRail(), Symbols.NormalRail);

            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
            CreateBackwardsRelation(new HoldingRail(), Symbols.HoldingRail);
        }

        private IRail CreateNormalRelation(IRail newObj, Symbols type)
        {
            if (_mainModel.EndOflevelLink == null)
            {
                _mainModel.EndOflevelLink = newObj;
                _lastObject = newObj;
                return _lastObject;
            }
            _lastObject.Previous = newObj;
            newObj.Next = _lastObject;
            _lastObject = newObj;
            return _lastObject;
        }

        private IRail CreateBackwardsRelation(IRail newObj, Symbols type)
        {
            _lastObject.Next = newObj;
            newObj.Previous = _lastObject;
            _lastObject = newObj;
            return _lastObject;
        }

        private void CreateConversionRelation(ISwitchRail obj, Symbols type, int pos)
        {
            _mainModel.AddSwitch(pos, obj);
            obj.Next = _lastObject;
            _lastObject.Previous = obj;
        }

        private void CreateDiversionRelation(ISwitchRail obj, Symbols type, int pos)
        {
            _mainModel.AddSwitch(pos, obj);
            obj.Next = _lastObject;
            _lastObject.Previous = obj;
        }

        private void CreateWarehouseRelation(Warehouse obj, Symbols type) 
        {
            _mainModel.AddWarehouse(type, obj);
            obj.Next = _lastObject;
            _lastObject.Previous = obj;
        }

        private void CreateDockRelation(Dock obj, Symbols type, int pos)
        {
            _mainModel.AddDock(pos, obj);
            obj.Next = _lastObject;
            _lastObject.Previous = obj;
            _lastObject = obj;
        }
    }
}
