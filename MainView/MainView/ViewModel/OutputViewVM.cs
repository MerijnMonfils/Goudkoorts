using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model;
using Goudkoorts.View;

namespace Goudkoorts.View
{
    class OutputViewVM
    {
        private MainView _view;

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

        public void SetLevelSettings()
        {
            _view.SetLevelSettings();
        }

        public void RedrawLevel(MainModel _mainModel)
        {
            _view.Clear();
            
            var rows = _mainModel.EndOflevelLink;
            var columns = _mainModel.EndOflevelLink;

            while (rows != null)
            {
                while (columns != null)
                {
                    _view.Write(columns.Type + "");
                    columns = columns.Next;
                }
                _view.WriteLine("");
                rows = rows.Below;
                columns = rows;
            }
        }

        public void GameListener()
        {
            _view.GameListener();
        }
    }
}
