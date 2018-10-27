using Goudkoorts.Model;
using System;

namespace Goudkoorts.ViewModel
{
    class InputViewVM
    {
        private OutputViewVM _output;
        private MainModel _mainModel;

        public InputViewVM(OutputViewVM output)
        {
            _output = output;
        }

        public void StartGame(ConsoleKey input)
        {
            if (input.Equals(ConsoleKey.Escape))
                Environment.Exit(0);

            if (input.Equals(ConsoleKey.S))
            {
                StartPlaying();
            }
            _output.StartMenuListener();
        }

        private void StartPlaying()
        {
            _mainModel = new MainModel(this);
            _mainModel.StartAll();
            _output.RedrawLevel(_mainModel);
            _output.GameListener();
        }

        public void GameControls(ConsoleKey key)
        {
            if (key.Equals(ConsoleKey.Escape))
                Environment.Exit(0);

            if (_mainModel.IsLocked)
            {
                _output.RedrawLevel(_mainModel);
                _output.GameListener();
            }

            if (key.Equals(ConsoleKey.D1))
            {
                _mainModel.GetSwitch(1).Switch();
            }
            else if (key.Equals(ConsoleKey.D2))
            {
                _mainModel.GetSwitch(2).Switch();
            }
            else if (key.Equals(ConsoleKey.D3))
            {
                _mainModel.GetSwitch(3).Switch();
            }
            else if (key.Equals(ConsoleKey.D4))
            {
                _mainModel.GetSwitch(4).Switch();
            }
            else if (key.Equals(ConsoleKey.D5))
            {
                _mainModel.GetSwitch(5).Switch();
            }
            _output.RedrawLevel(_mainModel);
            _output.GameListener();
        }

        public void Redraw(MainModel main)
        {
            _output.RedrawLevel(main);
        }
    }
}
