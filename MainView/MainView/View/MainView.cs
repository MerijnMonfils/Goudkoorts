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

        public MainView(OutputViewVM output)
        {
            _input = new InputViewVM(output);
        }

        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n\n\n");
            this.WriteInCenter("Welkom bij Goudkoorts!");
            this.WriteInCenter("Controls: ");
            this.WriteInCenter(" ");
            this.WriteInCenter("Druk op 'S' om te beginnen.");
            this.WriteInCenter("'Escape' om op elk punt af te sluiten.");
        }

        public void SetLevelSettings()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Goudkoorts";
            Console.Clear();
        }
        
        private void WriteInCenter(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        public void MenuListener()
        {
            Console.ForegroundColor = ConsoleColor.Black; 
            _input.StartGame(Console.ReadKey().Key);
        }

        public void GameListener()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            _input.GameControls(Console.ReadKey().Key);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
