using System;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private readonly IConsolePrinter _printer;

        private readonly Grid _grid;

        private Coordinate _cursor = new Coordinate(0, 0);

        public Game(IConsolePrinter printer, Grid grid)
        {
            _printer = printer;
            _grid = grid;
        }

        public void Start(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _grid.NextGeneration();

                _printer.OutputToConsole(_grid.GetDisplay());

                Thread.Sleep(600);

                _printer.ClearConsole();
            }
        }

        public void AddSeedStateToBoard()
        {
            _printer.OutputToConsole(_grid.GetDisplay());

            var instruction = Console.ReadKey();

            while (instruction.Key != ConsoleKey.Enter)
            {
                _grid.HandleUserInput(instruction.Key, _cursor);

                _printer.ClearConsole();

                _printer.OutputToConsole(_grid.GetDisplay(_cursor));

                instruction = Console.ReadKey();
            }
        }
    }
}