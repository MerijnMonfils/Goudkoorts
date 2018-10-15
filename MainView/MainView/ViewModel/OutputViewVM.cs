﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
