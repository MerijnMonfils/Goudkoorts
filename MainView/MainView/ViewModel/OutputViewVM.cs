﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainView.View;

namespace MainView.View
{
    class OutputViewVM
    {
        private MainView _view;

        public OutputViewVM()
        {
            _view = new MainView(this);
        }
    }
}