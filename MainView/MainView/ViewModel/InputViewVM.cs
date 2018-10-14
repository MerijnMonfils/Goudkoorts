using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainView.View
{
    class InputViewVM
    {
        private OutputViewVM _output;

        public InputViewVM(OutputViewVM output)
        {
            _output = output;
        }

        public void StartGame(ConsoleKey input)
        {
            if (input.Equals(ConsoleKey.S))
            {
                // START
                // Steps:
                // 1 - setup game objects
                // 2 - load board
                // 3 - await input
            }
            _output.StartMenuListener();
        }
    }
}
