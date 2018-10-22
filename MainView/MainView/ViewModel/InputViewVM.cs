using Goudkoorts.Model;
using Goudkoorts.Model.FileReading;
using Goudkoorts.Model.LinkBuilder;
using System;

namespace Goudkoorts.View
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
            _mainModel = new MainModel();
            LinkBuilder builder = new LinkBuilder(_mainModel);
            _output.RedrawLevel(_mainModel);
            // set legenda
            // create controller for playercontrols
            _output.SetLevelSettings();
        }

        public void GameControls(ConsoleKey key)
        {
            if (key.Equals(ConsoleKey.Escape))
                Environment.Exit(0);

            if (key.Equals(ConsoleKey.D1))
            {

            }
            else if (key.Equals(ConsoleKey.D2))
            {

            }
            else if (key.Equals(ConsoleKey.D3))
            {

            }
            else if (key.Equals(ConsoleKey.D4))
            {

            }
            else if (key.Equals(ConsoleKey.D5))
            {

            }
            _output.RedrawLevel(_mainModel);
        }
    }
}
