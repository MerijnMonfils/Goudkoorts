using Goudkoorts.Enum;
using Goudkoorts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class MainView
    {
        private InputViewVM _input;

        private int _prevrow = -1;

        public MainView(OutputViewVM output)
        {
            Console.Title = "Goudkoorts";
            _input = new InputViewVM(output);
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n\n\n\n");
            this.WriteLineInCenter("Welkom bij Goudkoorts!", false);
            this.WriteLineInCenter("Controls: ", false);
            this.WriteLineInCenter(" ", false);
            this.WriteLineInCenter("Druk op 'S' om te beginnen.", false);
            this.WriteLineInCenter("'Escape' om op elk punt af te sluiten.", false);
        }

        public void Clear()
        {
            Console.Clear();
        }

        // Methods to draw in center of the console
        private void WriteLineInCenter(string text, bool space)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            if (space)
                Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void WriteInCenter(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // Show title
        public void ShowTitle()
        {
            Console.WriteLine("\n\n");
            WriteLineInCenter("Goudkoorts", true);
        }

        // Shows lengenda
        public void ShowLegenda()
        {
            Console.WriteLine("\n");
            WriteLineInCenter("Legenda:", true);
            WriteLineInCenter(" " + (char)Symbols.FullCart + " - Volle Kar ", true);
            WriteLineInCenter(" " + (char)Symbols.EmptyCart + " - Lege Kar ", true);
            WriteLineInCenter(" " + (char)Symbols.SwitchDown + " - Switch Down ", true);
            WriteLineInCenter(" " + (char)Symbols.SwitchUp + " - Switch Up ", true);
            WriteLineInCenter(" " + (char)Symbols.HoldingRail + " - Rangeer Rail ", true);
            WriteLineInCenter(" " + (char)Symbols.WarehouseA + ", " + (char)Symbols.WarehouseB + ", " + (char)Symbols.WarehouseC + " - Loods ", true);
            WriteLineInCenter(" " + (char)Symbols.Dock + " - Kade ", true);
        }

        // Draw methods for game
        public void DrawMoveable(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
        }

        public void Write(string text, int row)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (_prevrow != row)
            {
                WriteInCenter("█");
                _prevrow = row;
            }
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        // Listeners
        public void MenuListener()
        {
            _input.StartGame(Console.ReadKey().Key);
        }

        public void GameListener()
        {
            _input.GameControls(Console.ReadKey().Key);
        }
    }
}
