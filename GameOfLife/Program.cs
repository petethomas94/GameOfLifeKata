namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var gridDimensions = new GridDimensions(15, 30);

            var _grid = new GridFactory().CreateGrid(gridDimensions, new List<Coordinate>());

            var seed = new List<Coordinate>();

            var cursor = new Coordinate(0, 0);

            var instruction = Console.ReadKey();

            while (instruction.Key != ConsoleKey.Enter)
            {
                switch (instruction.Key)
                {
                    case ConsoleKey.LeftArrow:
                        cursor.XCoordinate--;
                        break;
                    case ConsoleKey.RightArrow:
                        cursor.XCoordinate++;
                        break;
                    case ConsoleKey.DownArrow:
                        cursor.YCoordinate++;
                        break;
                    case ConsoleKey.UpArrow:
                        cursor.YCoordinate--;
                        break;
                    case ConsoleKey.Spacebar:
                        seed.Add(new Coordinate(cursor.XCoordinate, cursor.YCoordinate));
                        break;
                }

                for (var i = 0; i < _grid[0].Count; i++)
                {
                    for (var j = 0; j < _grid.Count; j++)
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


                instruction = Console.ReadKey();

                Console.Clear();
            }

            var grid = new GridFactory().CreateGrid(gridDimensions, seed);

            var game = new Game(new NeighbourSelector(), new CellPositionCalculator(gridDimensions), grid);

            game.PrintBoard();

            do
            {
                while (!Console.KeyAvailable)
                {
                    game.GenerateNextIteration();
                    game.PrintBoard();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static bool CursorPosition(int j, Coordinate cursor, int i)
        {
            return j == cursor.XCoordinate && i == cursor.YCoordinate;
        }
    }
}
