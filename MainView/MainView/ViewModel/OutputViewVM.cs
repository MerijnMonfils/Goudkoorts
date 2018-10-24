using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Enum;
using Goudkoorts.Model;
using Goudkoorts.Model.Rails;
using Goudkoorts.ViewModel;

namespace Goudkoorts.ViewModel
{
    class OutputViewVM
    {
        private MainView _view;

        private readonly object syncLock = new object();

        public OutputViewVM()
        {
            _view = new MainView(this);
            OpenMenu();
        }

        private void OpenMenu()
        {
            _view.ShowMenu();
            _view.MenuListener();
        }

        public void StartMenuListener()
        {
            _view.MenuListener();
        }

        public void RedrawLevel(MainModel _mainModel)
        {
            lock (syncLock)
            {
                _view.Clear();
                _view.ShowTitle();

                var rows = _mainModel.EndOflevelLink;
                var columns = _mainModel.EndOflevelLink;

                int row = 0;

                while (rows != null)
                {
                    _view.WriteLine("");
                    while (columns != null)
                    {
                        if (columns.ContainsMoveableObject != null)
                            _view.DrawMoveable(columns.ContainsMoveableObject.Type + "");
                        else
                            _view.Write(columns.Type + "", row);
                        columns = columns.Next;
                    }
                    rows = rows.Below;
                    columns = rows;
                    row++;
                }
                _view.WriteLine("\n");
                _view.ShowControls(_mainModel.IsLocked);
                _view.ShowLegenda();
            }
        }

        public void GameListener()
        {
            _view.GameListener();
        }
    }
}
