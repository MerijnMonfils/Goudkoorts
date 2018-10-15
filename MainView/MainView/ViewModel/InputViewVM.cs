using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // 2 - load board
                // 3 - await input
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
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
            _output.StartMenuListener();
        }
    }
}
