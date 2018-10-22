using Goudkoorts.Model;
using Goudkoorts.Model.FileReading;
using Goudkoorts.Model.LinkBuilder;
using System;

namespace Goudkoorts.View
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
            if (input.Equals(ConsoleKey.Escape))
                Environment.Exit(0);

            if (input.Equals(ConsoleKey.S))
            {
                // START
                // Steps:
                // 1 - setup game objects
                // 2 - load boardw
                // 3 - await input
                SetLevelSettings();
                LinkBuilder builder = new LinkBuilder(new MainModel());
            }
            _output.StartMenuListener();
        }

        private void SetLevelSettings()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Goudkoorts";
            Console.Clear();
            Console.WindowHeight = 15;
            Console.WindowWidth = 35;
        }

        public void ExampleLevel()
        {
            Console.WriteLine("");
            Console.WriteLine("— — — — — — — — — K — — — \\      ");
            Console.WriteLine("                            |    ");
            Console.WriteLine("A: — — \\    / — — — \\       |    ");
            Console.WriteLine("        v — ^        v — — /     ");
            Console.WriteLine("B: — — /     \\      /            ");
            Console.WriteLine("              \\    /             ");
            Console.WriteLine("               v — ^             ");
            Console.WriteLine("C: — — — — — — /    \\ — — \\      ");
            Console.WriteLine("                           |     ");
            Console.WriteLine("_ _ _ _ _ _ _ _ — — — — — /      ");
        }
    }
}
