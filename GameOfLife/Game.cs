using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{ 
    public class Game
    {
        private readonly GridGenerator _generator;
        private readonly IGridDisplayGenerator _displayGenerator;
        private readonly IConsolePrinter _printer;
        private readonly GridDimensions _gridDimensions;

        public Game(GridGenerator generator, IGridDisplayGenerator displayGenerator, IConsolePrinter printer, GridDimensions dimensions)
        {
            _generator = generator;
            _displayGenerator = displayGenerator;
            _printer = printer;
            _gridDimensions = dimensions;
        }

        public void Start(List<List<Cell>> grid, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                grid = _generator.GenerateNextIteration(grid, _gridDimensions);

                _printer.OutputToConsole(_displayGenerator.GenerateGridDisplay(grid));

                Thread.Sleep(600);

                _printer.ClearConsole();
            }
        }

        public List<Coordinate> GetSeedStateFromUser(){

            var seedGrid = GridFactory.CreateGrid(_gridDimensions, new List<Coordinate>());

            var seed = new List<Coordinate>();

            var cursor = new Coordinate(0, 0);

            _printer.OutputToConsole(_displayGenerator.GenerateGridDisplay(seedGrid));

            var instruction = Console.ReadKey();

            while (instruction.Key != ConsoleKey.Enter)
            {
                HandleUserInput(instruction.Key, cursor, seed);

                _printer.ClearConsole();

                _printer.OutputToConsole(_displayGenerator.GenerateGridDisplay(seedGrid, cursor, seed));

                instruction = Console.ReadKey();
            }

            return seed;
        }

        public void HandleUserInput(ConsoleKey instruction, Coordinate cursor, List<Coordinate> seed){
            switch (instruction)
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
        }
    }
}