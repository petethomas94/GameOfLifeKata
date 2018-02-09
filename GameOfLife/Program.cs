namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        private static GridDimensions _gridDimensions = new GridDimensions(15, 30);

        static void Main()
        {
            while (true)
            {
                var generator = new GridDisplayGenerator();

                var seedGrid = GridFactory.CreateGrid(_gridDimensions, new List<Coordinate>());

                var seed = new List<Coordinate>();

                var cursor = new Coordinate(0, 0);

                Console.Write(generator.GenerateGridDisplay(seedGrid));

                var instruction = Console.ReadKey();

                while (instruction.Key != ConsoleKey.Enter)
                {
                    switch (instruction.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (cursor.XCoordinate == 0)
                            {
                                cursor.XCoordinate = _gridDimensions.Width - 1;
                            }
                            else
                            {
                                cursor.XCoordinate--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (cursor.XCoordinate == _gridDimensions.Width - 1)
                            {
                                cursor.XCoordinate = 0;
                            }
                            else
                            {
                                cursor.XCoordinate++;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (cursor.YCoordinate == _gridDimensions.Height - 1)
                            {
                                cursor.YCoordinate = 0;
                            }
                            else
                            {
                                cursor.YCoordinate++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (cursor.YCoordinate == 0)
                            {
                                cursor.YCoordinate = _gridDimensions.Height - 1;
                            }
                            else
                            {
                                cursor.YCoordinate--;
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            seed.Add(new Coordinate(cursor.XCoordinate, cursor.YCoordinate));
                            break;
                    }

                    Console.Clear();

                    Console.Write(generator.GenerateGridDisplay(seedGrid, cursor, seed));

                    instruction = Console.ReadKey();
                }

                var grid = GridFactory.CreateGrid(_gridDimensions, seed);

                var gridGenerator = new GridGenerator(new NeighbourSelector(), new CellPositionCalculator(_gridDimensions));

                var game = new Game(gridGenerator, generator, new ConsolePrinter());

                var tcs = new CancellationTokenSource();

                var task = Task.Run(() => game.Start(grid, tcs.Token), tcs.Token);

                Console.ReadKey();

                tcs.Cancel();

                task.Wait();

                Console.Clear();
            }
        }
    }

    public class Game
    {
        private readonly GridGenerator _generator;
        private readonly IGridDisplayGenerator _displayGenerator;
        private readonly IConsolePrinter _printer;

        public Game(GridGenerator generator, IGridDisplayGenerator displayGenerator, IConsolePrinter printer)
        {
            _generator = generator;
            _displayGenerator = displayGenerator;
            _printer = printer;
        }

        public void Start(List<List<Cell>> grid, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                grid = _generator.GenerateNextIteration(grid);

                _printer.OutputToConsole(_displayGenerator.GenerateGridDisplay(grid));

                Thread.Sleep(600);

                _printer.ClearConsole();
            }
        }
    }

    public class ConsolePrinter : IConsolePrinter
    {
        public void OutputToConsole(string output)
        {
            Console.Write(output);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
