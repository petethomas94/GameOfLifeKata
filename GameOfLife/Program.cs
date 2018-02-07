namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static GridDimensions _gridDimensions = new GridDimensions(15, 30);

        static void Main()
        {
            do
            {
                var seedGrid = GridFactory.CreateGrid(_gridDimensions, new List<Coordinate>());

                var seed = new List<Coordinate>();

                var cursor = new Coordinate(0, 0);

                PrintBoard(seedGrid, cursor, seed);

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

                    PrintBoard(seedGrid, cursor, seed);

                    instruction = Console.ReadKey();
                }

                var grid = GridFactory.CreateGrid(_gridDimensions, seed);

                var game = new Game(new NeighbourSelector(), new CellPositionCalculator(_gridDimensions), grid);

                while (!Console.KeyAvailable)
                {
                    game.GenerateNextIteration();
                    game.PrintBoard();
                }

                Console.Clear();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void PrintBoard(List<List<Cell>> _grid, Coordinate cursor, List<Coordinate> seed)
        {
            for (var i = 0; i < _grid.Count; i++)
            {
                for (var j = 0; j < _grid[i].Count; j++)
                {
                    if (CursorPosition(j, cursor, i) || seed.Any(c => c.XCoordinate == j && c.YCoordinate == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('x');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write('o');
                    }
                }

                Console.Write('\n');
            }
        }

        private static bool CursorPosition(int j, Coordinate cursor, int i)
        {
            return j == cursor.XCoordinate && i == cursor.YCoordinate;
        }
    }
}
