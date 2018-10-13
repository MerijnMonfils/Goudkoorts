using MainView.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainView
{
    class MainView
    {
        private InputViewVM _input;

        public MainView(OutputViewVM output)
        {
            _input = new InputViewVM(output);
        }
    }
}
