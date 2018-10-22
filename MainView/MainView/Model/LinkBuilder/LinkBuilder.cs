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
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);

            CreateDockRelation(new Dock(), Symbols.Dock, 1);

            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.CornerRailB);
            CreateObjectRelations(new NormalRail(), Symbols.StraightRail);
            CreateObjectRelations(new NormalRail(), Symbols.StraightRail);
            CreateObjectRelations(new NormalRail(), Symbols.CornerRailA);
            CreateObjectRelations(new NormalRail(), Symbols.CornerRailA);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);

            CreateConversionRelation(new SwitchConversion(), Symbols.SwitchDown, 3);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.CornerRailA);

            CreateDiversionRelation(new SwitchDiversion(), Symbols.SwitchDown, 2);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);

            CreateConversionRelation(new SwitchConversion(), Symbols.SwitchDown, 1);
            CreateObjectRelations(new NormalRail(), Symbols.CornerRailB);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);
            CreateObjectRelations(new NormalRail(), Symbols.NormalRail);

            CreateWarehouseRelation(new Warehouse(), Symbols.WarehouseA);
        }

        private IRail CreateObjectRelations(IRail newObj, Symbols type)
        {
            if (_mainModel.EndOflevelLink == null)
            {
                _mainModel.EndOflevelLink = newObj;
                _lastObject = newObj;
            }
            _lastObject.Previous = newObj;
            newObj.Next = _lastObject;
            _lastObject = newObj;
            return _lastObject;
        }

        private void CreateConversionRelation(ISwitchRail obj, Symbols type, int pos)
        {
            _mainModel.AddSwitch(pos, obj);
            obj.Next = _lastObject;
            obj.OnHold = CreateObjectRelations(new NormalRail(), Symbols.CornerRailB);
        }

        private void CreateDiversionRelation(ISwitchRail obj, Symbols type, int pos)
        {
            _mainModel.AddSwitch(pos, obj);
            obj.Next = _lastObject;
            obj.OnHold = CreateObjectRelations(new NormalRail(), Symbols.CornerRailA);
        }

        private void CreateWarehouseRelation(Warehouse obj, Symbols type) 
        {
            _mainModel.AddWarehouse(type, obj);
            obj.Next = _lastObject;
            _lastObject.Previous = obj;
            _lastObject = _mainModel.GetSwitch(1);
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
